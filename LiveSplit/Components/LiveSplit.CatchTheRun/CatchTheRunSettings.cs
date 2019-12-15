using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
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
