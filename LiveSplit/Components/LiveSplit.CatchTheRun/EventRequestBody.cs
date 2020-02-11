namespace LiveSplit.CatchTheRun
{
    internal class EventRequestBody
    {
        internal string Player { get; set; }
        internal string Game { get; set; }
        internal string Category { get; set; }
        internal string SplitName { get; set; }
        internal string CurrentPace { get; set; }
        internal string Message { get; set; }
    }
}
