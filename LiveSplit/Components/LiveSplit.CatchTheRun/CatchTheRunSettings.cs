using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;
using LiveSplit.Model;
using System.Drawing;
using LiveSplit.TimeFormatters;
using System.Collections.Generic;
using System.IO;
using LiveSplit.Model.RunFactories;
using LiveSplit.Model.Comparisons;

namespace LiveSplit.UI.Components
{
    public partial class CatchTheRunSettings : UserControl
    {
        private const int ICON_INDEX = 0;
        private const int SEGMENT_NAME_INDEX = 1;
        private const int SPLIT_TIME_INDEX = 2;
        private const int THRESHOLD_INDEX = 3;

        protected IRun Run { get; set; }
        protected BindingList<SegmentWithThreshold> SegmentList { get; set; }

        protected StandardFormatsRunFactory RunFactory { get; set; }
        protected StandardComparisonGeneratorsFactory ComparisonGeneratorsFactory { get; set; }

        public string NotificationMessage { get; set; }
        public bool ShowTriggerIndicator { get; set; }
        public List<SegmentWithThreshold> SegmentsWithThresholds { get; set; }

        public CatchTheRunSettings(LiveSplitState state)
        {
            InitializeComponent();
            Run = state.Run;
            SegmentsWithThresholds = GetSegmentsWithThresholds();
            SegmentList = new BindingList<SegmentWithThreshold>(SegmentsWithThresholds);
            RunFactory = new StandardFormatsRunFactory();
            ComparisonGeneratorsFactory = new StandardComparisonGeneratorsFactory();
            runGrid.DataSource = SegmentList;
            this.iconDataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            this.iconDataGridViewImageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.iconDataGridViewImageColumn.DefaultCellStyle.NullValue = new Bitmap(1, 1);
            runGrid.CellFormatting += runGrid_CellFormatting;
            runGrid.CellEndEdit += runGrid_CellEndEdit;
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "NotificationMessage", NotificationMessage) ^
            SettingsHelper.CreateSetting(document, parent, "ShowTriggerIndicator", ShowTriggerIndicator);
        }

        public void SetSettings(XmlNode settings)
        {
            NotificationMessage = SettingsHelper.ParseString(settings["NotificationMessage"]);
            ShowTriggerIndicator = SettingsHelper.ParseBool(settings["ShowTriggerIndicator"]);
        }

        private List<SegmentWithThreshold> GetSegmentsWithThresholds()
        {
            using (var stream = File.OpenRead(Run.FilePath))
            {
                XmlTextReader reader = new XmlTextReader(Run.FilePath);

                var segmentsWithThresholds = new List<SegmentWithThreshold>();

                var currentSegment = new SegmentWithThreshold();
                string currentXmlElement = null;

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "Segment")
                                currentSegment = new SegmentWithThreshold();
                            else if (reader.Name == "Name")
                                currentXmlElement = "Name";
                            else if (reader.Name == "SplitTime")
                            {
                                if (reader.GetAttribute("name") == "Personal Best")
                                    currentXmlElement = "SplitTime";
                            }
                            else if (currentXmlElement == "SplitTime" && reader.Name == "RealTime")
                                currentXmlElement = "RealTime";
                            else if (reader.Name == "Threshold")
                                currentXmlElement = "Threshold";
                            else
                                currentXmlElement = null;
                            break;
                        case XmlNodeType.Text:
                            if (currentXmlElement == "Name")
                                currentSegment.Name = reader.Value;
                            else if (currentXmlElement == "RealTime")
                                currentSegment.SplitTime = reader.Value;
                            else if (currentXmlElement == "Threshold")
                                currentSegment.Threshold = reader.Value;
                            break;
                        case XmlNodeType.EndElement:
                            if (reader.Name == "Segment")
                                segmentsWithThresholds.Add(currentSegment);
                            break;
                    }
                }

                return segmentsWithThresholds;
            }
        }

        private void SaveThresholdToSplitsFile(string splitName, string thresholdValue)
        {
            var doc = new XmlDocument();
            doc.Load(Run.FilePath);

            XmlNodeList segmentNodes = doc.SelectNodes("/Run/Segments/Segment");

            for (var i = 0; i < segmentNodes.Count; i++)
            {
                var segmentNode = segmentNodes[i];
                var nodeName = segmentNode.SelectSingleNode("Name").FirstChild.Value;

                if (splitName == nodeName)
                {
                    var thresholdNode = segmentNode.SelectSingleNode("Threshold");
                    thresholdNode.FirstChild.Value = thresholdValue;
                    break;
                }
            }

            doc.Save(Run.FilePath);
        }

        private void runGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void runGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var splitName = runGrid.Rows[e.RowIndex].Cells[1].Value as string;
            var thresholdValue = runGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as string;
            SaveThresholdToSplitsFile(splitName, thresholdValue);
        }
    }

    public class SegmentWithThreshold
    {
        public Image Icon { get; set; }
        public string Name { get; set; }
        public string SplitTime { get; set; }
        public string Threshold { get; set; }
    }
}
