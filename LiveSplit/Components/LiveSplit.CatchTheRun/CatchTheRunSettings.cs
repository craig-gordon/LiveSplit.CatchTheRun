using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;
using LiveSplit.Model;
using System.Drawing;
using LiveSplit.TimeFormatters;

namespace LiveSplit.UI.Components
{
    public partial class CatchTheRunSettings : UserControl
    {
        private const int ICON_INDEX = 0;
        private const int SEGMENT_NAME_INDEX = 1;
        private const int SPLIT_TIME_INDEX = 2;
        private const int THRESHOLD_INDEX = 3;

        protected IRun Run { get; set; }
        protected BindingList<ISegment> SegmentList { get; set; }

        public CatchTheRunSettings(LiveSplitState state)
        {
            InitializeComponent();
            Run = state.Run;
            SegmentList = new BindingList<ISegment>(Run);
            runGrid.DataSource = SegmentList;
            this.iconDataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            this.iconDataGridViewImageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.iconDataGridViewImageColumn.DefaultCellStyle.NullValue = new Bitmap(1, 1);
            runGrid.CellFormatting += runGrid_CellFormatting;
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

        void runGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < Run.Count)
            {
                switch (e.ColumnIndex)
                {
                    case ICON_INDEX:
                        e.Value = Run[e.RowIndex].Icon;
                        break;
                    case SEGMENT_NAME_INDEX:
                        e.Value = Run[e.RowIndex].Name;
                        break;
                    case SPLIT_TIME_INDEX:
                        e.Value = new ShortTimeFormatter().Format(Run[e.RowIndex].PersonalBestSplitTime[TimingMethod.RealTime]);
                        break;
                    default:
                        break;
                }
            }
        }

        private void runGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
