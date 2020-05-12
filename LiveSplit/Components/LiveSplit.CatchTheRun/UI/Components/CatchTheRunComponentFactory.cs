using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;

[assembly: ComponentFactory(typeof(CatchTheRunComponentFactory))]

namespace LiveSplit.UI.Components
{
    public class CatchTheRunComponentFactory : IComponentFactory
    {
        public string ComponentName => "Catch The Run";

        public string Description => "Allows stream viewers to receive notifications when speedrunners get on-pace during attempts.";

        public ComponentCategory Category => ComponentCategory.Other;

        public IComponent Create(LiveSplitState state) => new CatchTheRunComponent(state);

        public string UpdateName => ComponentName;

        public string XMLURL => "http://livesplit.org/update/Components/update.LiveSplit.CatchTheRun.xml";

        public string UpdateURL => "placeholder";

        public Version Version => Version.Parse("0.0.1");
    }
}
