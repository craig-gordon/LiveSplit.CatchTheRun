using System;

namespace LiveSplit.CatchTheRun
{
    internal class EventCommand
    {
        public string EventType { get; set; }
        public string EventSource { get; set; }
        public string Producer { get; set; }
        public string Game { get; set; }
        public string Category { get; set; }
        public string SplitName { get; set; }
        public string Pace { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
    }
}
