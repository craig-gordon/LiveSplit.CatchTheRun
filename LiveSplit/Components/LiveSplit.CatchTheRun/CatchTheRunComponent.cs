using System;
using System.Collections.Generic;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using LiveSplit.Model;
using LiveSplit.CatchTheRun;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace LiveSplit.UI.Components
{
    public class CatchTheRunComponent : IComponent
    {
        public CatchTheRunSettings Settings { get; set; }

        protected LiveSplitState State { get; set; }
        protected Form Form { get; set; }
        protected TimerModel Model { get; set; }

        private List<SegmentWithThreshold> SegmentThresholdList { get; set; }
        private int SplitIndex { get; set; }

        private HttpClient _HttpClient { get; set; }

        public string ComponentName => "Catch The Run";

        public float VerticalHeight => 0;
        public float MinimumWidth => 0;
        public float HorizontalWidth => 0;
        public float MinimumHeight => 0;

        public float PaddingTop => 0;
        public float PaddingBottom => 0;
        public float PaddingLeft => 0;
        public float PaddingRight => 0;

        public IDictionary<string, Action> ContextMenuControls => null;

        public CatchTheRunComponent(LiveSplitState state)
        {
            Settings = new CatchTheRunSettings(state);
            Model = new TimerModel();
            State = state;
            Form = state.Form;
            Model.CurrentState = State;
            _HttpClient = new HttpClient();
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            return Settings;
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return Settings.GetSettings(document);
        }


        public void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            if (state.CurrentPhase == TimerPhase.Running && this.SegmentThresholdList == null)
            {
                this.SplitIndex = 0;
                this.SegmentThresholdList = XmlHelper.GetSegmentsWithThresholds(state.Run.FilePath);
            }
            else if (state.CurrentPhase == TimerPhase.Running && state.CurrentSplitIndex == this.SplitIndex + 1)
            {
                var split = state.Run[this.SplitIndex];
                double threshold = Convert.ToDouble(this.SegmentThresholdList[this.SplitIndex].Threshold) * 1000;
                double? splitDelta = split.SplitTime.RealTime?.TotalMilliseconds - split.PersonalBestSplitTime.RealTime?.TotalMilliseconds;

                if (splitDelta < threshold)
                {
                    var message = JsonConvert.SerializeObject(new EventRequestBody()
                    {
                        Player = "cyghfer",
                        Game = "Super Mario World",
                        Category = "96 Exit",
                        SplitName = "Forest of Illusion",
                        CurrentPace = "-10.5",
                        Message = "Ya boy is on the hecking run"
                    });

                    var request = new StringContent(message, new UTF8Encoding(), "application/json");
                    _HttpClient.PostAsync("http://localhost:4000", request);
                }

                this.SplitIndex++;
            }
            else if (state.CurrentPhase == TimerPhase.NotRunning || state.CurrentPhase == TimerPhase.Ended)
            {
                this.SplitIndex = -1;
                this.SegmentThresholdList = null;
            }
        }

        public void Dispose()
        {
        }
    }
}
