using System.Collections.Generic;
using System.Xml;
using LiveSplit.Model;
using System.IO;

namespace LiveSplit.CatchTheRun
{
    internal static class XmlHelper
    {
        private readonly static string CREDENTIALS_FILEPATH = $@"{Directory.GetCurrentDirectory()}\CtrCredentials.xml";

        internal static ClientCredentials ReadClientCredentials()
        {
            var doc = new XmlDocument();
            doc.Load(CREDENTIALS_FILEPATH);

            var clientId = doc.SelectSingleNode("TwitchUsername").FirstChild.Value;
            var clientKey = doc.SelectSingleNode("ClientKey").FirstChild.Value;

            return new ClientCredentials() { ClientID = clientId, ClientKey = clientKey };
        }

        internal static List<SegmentWithThreshold> GetSegmentsWithThresholds(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                XmlTextReader reader = new XmlTextReader(filePath);

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

        internal static void SaveThresholdToSplitsFile(string filePath, string splitName, string thresholdValue)
        {
            var doc = new XmlDocument();
            doc.Load(filePath);

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

            doc.Save(filePath);
        }
    }
}
