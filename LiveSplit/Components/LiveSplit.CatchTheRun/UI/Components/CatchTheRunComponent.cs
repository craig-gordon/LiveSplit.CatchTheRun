using System;
using System.Collections.Generic;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using LiveSplit.Model;
using LiveSplit.CatchTheRun;
using LiveSplit.Options;

namespace LiveSplit.UI.Components
{
    public class CatchTheRunComponent : IComponent
    {
        public CatchTheRunSettings Settings { get; set; }
        protected LiveSplitState State { get; set; }

        private int SplitIndex { get; set; }
        private bool EventAlreadyTriggered { get; set; }

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
            this.EventAlreadyTriggered = false;
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
            if (state.CurrentPhase == TimerPhase.Running && this.SplitIndex == -1)
            {
                this.SplitIndex = 0;
                this.EventAlreadyTriggered = false;
            }
            else if (state.CurrentPhase == TimerPhase.Running && state.CurrentSplitIndex == this.SplitIndex + 1 && this.SplitIndex != -1)
            {
                var thresholdStringValue = Settings.Thresholds[this.SplitIndex].Value;
                double threshold = Convert.ToDouble(thresholdStringValue) * 1000;
                var split = state.Run[this.SplitIndex];
                double? splitDelta = split.SplitTime.RealTime?.TotalMilliseconds - split.PersonalBestSplitTime.RealTime?.TotalMilliseconds;

                if (thresholdStringValue != null && splitDelta < threshold && !this.EventAlreadyTriggered)
                {
                    var cmd = new EventCommand()
                    {
                        EventType = "speedrun.pb",
                        EventSource = "livesplit",
                        Producer = Credentials.TwitchUsername,
                        Game = State.Run.GameName,
                        Category = State.Run.CategoryName,
                        SplitName = State.Run[State.CurrentSplitIndex].Name,
                        Pace = State.Run[State.CurrentSplitIndex - 1].SplitTime.ToString(),
                        Message = Settings.NotificationMessage,
                        Timestamp = DateTime.Now.ToString("o")
                    };

                    try
                    {
                        Settings.ApiClient.PushEvent(Credentials.ProducerKey, cmd);
                        this.EventAlreadyTriggered = true;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }
                }

                this.SplitIndex++;
            }
            else if (state.CurrentPhase == TimerPhase.NotRunning || state.CurrentPhase == TimerPhase.Ended)
            {
                this.SplitIndex = -1;
                this.EventAlreadyTriggered = false;
            }
        }

        public void Dispose()
        {
            Settings.ApiClient.Dispose();
        }
    }
}
