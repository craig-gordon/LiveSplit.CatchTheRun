namespace LiveSplit.CatchTheRun
{
    internal class EventRequestBody
    {
        public string Player { get; set; }
        public string Game { get; set; }
        public string Category { get; set; }
        public string SplitName { get; set; }
        public string CurrentPace { get; set; }
        public string Message { get; set; }
    }
}
