using System.Collections.Generic;
using System.Xml;
using System;
using System.IO;
using System.Windows.Forms;

namespace LiveSplit.CatchTheRun
{
    internal static class Xml
    {
        internal static List<Threshold> ReadThresholds(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                XmlTextReader reader = new XmlTextReader(filePath);

                var thresholds = new List<Threshold>();

                var currentSegment = new Threshold();
                string currentXmlElement = null;

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "Segment")
                                currentSegment = new Threshold();
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
                                currentSegment.SplitName = reader.Value;
                            else if (currentXmlElement == "RealTime")
                                currentSegment.SplitTime = reader.Value;
                            else if (currentXmlElement == "Threshold")
                                currentSegment.ThresholdValue = reader.Value;
                            break;
                        case XmlNodeType.EndElement:
                            if (reader.Name == "Segment")
                                thresholds.Add(currentSegment);
                            break;
                    }
                }

                return thresholds;
            }
        }

        internal static bool WriteThresholds(string filePath, Dictionary<string, string> thresholdValues, out string errorMessage)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(filePath);

                XmlNodeList segmentNodes = doc.SelectNodes("/Run/Segments/Segment");

                foreach (XmlNode segmentNode in segmentNodes)
                {
                    var nodeName = segmentNode.SelectSingleNode("Name").InnerText;

                    var thresholdNode = segmentNode.SelectSingleNode(Util.THRESHOLD_ELEMENT_NAME);

                    if (thresholdNode != null)
                        thresholdNode.InnerText = thresholdValues[nodeName];
                    else
                    {
                        thresholdNode = doc.CreateElement(string.Empty, Util.THRESHOLD_ELEMENT_NAME, string.Empty);
                        thresholdNode.InnerText = thresholdValues[nodeName];
                        segmentNode.AppendChild(thresholdNode);
                    }
                }

                doc.Save(filePath);

                errorMessage = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
