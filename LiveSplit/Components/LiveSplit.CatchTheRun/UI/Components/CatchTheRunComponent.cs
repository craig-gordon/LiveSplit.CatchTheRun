using System;
using System.Collections.Generic;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using LiveSplit.Model;
using LiveSplit.CatchTheRun;

namespace LiveSplit.UI.Components
{
    public class CatchTheRunComponent : IComponent
    {
        public CatchTheRunSettings Settings { get; set; }
        protected LiveSplitState State { get; set; }

        private int SplitIndex { get; set; }

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
            State = state;
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
            if (state.CurrentPhase == TimerPhase.Running && Settings.Thresholds == null)
            {
                this.SplitIndex = 0;
            }
            else if (state.CurrentPhase == TimerPhase.Running && state.CurrentSplitIndex == this.SplitIndex + 1)
            {
                var split = state.Run[this.SplitIndex];
                double threshold = Convert.ToDouble(Settings.Thresholds[this.SplitIndex].Value) * 1000;
                double? splitDelta = split.SplitTime.RealTime?.TotalMilliseconds - split.PersonalBestSplitTime.RealTime?.TotalMilliseconds;

                if (splitDelta < threshold)
                {
                    var cmd = new EventCommand()
                    {
                        Type = "speedrun.pb",
                        Source = "livesplit",
                        Producer = Credentials.TwitchUsername,
                        Game = State.Run.GameName,
                        Category = State.Run.CategoryName,
                        SplitName = State.Run[State.CurrentSplitIndex].Name,
                        CurrentPace = State.Run[State.CurrentSplitIndex - 1].SplitTime.ToString(),
                        Message = Settings.NotificationMessage
                    };

                    Settings.ApiClient.PushEvent(Credentials.ProducerKey, cmd);
                }

                this.SplitIndex++;
            }
            else if (state.CurrentPhase == TimerPhase.NotRunning || state.CurrentPhase == TimerPhase.Ended)
            {
                this.SplitIndex = -1;
                Settings.Thresholds = null;
            }
        }

        public void Dispose()
        {
        }
    }
}
