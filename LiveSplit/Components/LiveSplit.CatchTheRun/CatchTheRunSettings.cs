using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;
using LiveSplit.Model;

namespace LiveSplit.UI.Components
{
    public partial class CatchTheRunSettings : UserControl
    {
        protected BindingList<ISegment> SegmentList { get; set; }

        public CatchTheRunSettings(LiveSplitState state)
        {
            InitializeComponent();
            SegmentList = new BindingList<ISegment>(state.Run);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Configuration");
            CreateSettingsNode(document, parent);
            return parent;
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Threshold", "test");
        }

        public void SetSettings(XmlNode settings)
        {
        }
    }
}
