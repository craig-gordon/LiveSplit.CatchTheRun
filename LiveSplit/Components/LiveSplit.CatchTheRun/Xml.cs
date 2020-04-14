using System.Collections.Generic;
using System.Xml;
using System;
using System.Linq;

namespace LiveSplit.CatchTheRun
{
    internal static class Xml
    {
        internal const string IS_REGISTERED_ELEMENT_NAME = "CtrIsRegistered";
        internal const string THRESHOLD_ELEMENT_NAME = "CtrThreshold";

        internal static bool ReadIsRegistered(string filePath)
        {
            var doc = LoadDocument(filePath);
            return doc.SelectSingleNode($"Run/Metadata/{IS_REGISTERED_ELEMENT_NAME}")?.InnerText == "True";
        }

        internal static List<Threshold> ReadThresholds(string filePath)
        {
            var doc = LoadDocument(filePath);

            XmlNodeList segmentNodes = doc.SelectNodes("/Run/Segments/Segment");
            return segmentNodes.Cast<XmlNode>().Select(segmentNode =>
            {
                if (segmentNode == null)
                    return null;
                else
                {
                    var splitName = segmentNode.SelectSingleNode("Name").InnerText;
                    var splitTime = segmentNode
                                        .SelectNodes("SplitTimes/SplitTime")
                                        .Cast<XmlNode>()
                                        .FirstOrDefault(splitTimeNode => splitTimeNode.Attributes["name"].Value == "Personal Best")
                                        .FirstChild
                                        .InnerText;

                    var thresholdNodeText = segmentNode.SelectSingleNode(THRESHOLD_ELEMENT_NAME)?.InnerText;
                    var thresholdValue = !string.IsNullOrWhiteSpace(thresholdNodeText) ? thresholdNodeText : null;
                    return new Threshold() { SegmentName = splitName, SplitTime = splitTime, Value = thresholdValue };
                }
            }).ToList();
        }

        internal static void WriteIsRegistered(string filePath, bool value)
        {
            var doc = LoadDocument(filePath);

            XmlNode metadataNode = doc.SelectSingleNode($"Run/Metadata");
            XmlNode isRegisteredNode = metadataNode?.SelectSingleNode(IS_REGISTERED_ELEMENT_NAME);

            if (isRegisteredNode != null)
                isRegisteredNode.InnerText = value ? "True" : "False";
            else
            {
                isRegisteredNode = doc.CreateElement(string.Empty, IS_REGISTERED_ELEMENT_NAME, string.Empty);
                isRegisteredNode.InnerText = value ? "True" : "False";
                metadataNode.AppendChild(isRegisteredNode);
            }

            doc.Save(filePath);
        }

        internal static void WriteThresholds(string filePath, Dictionary<string, string> values)
        {
            var doc = LoadDocument(filePath);

            XmlNodeList segmentNodes = doc.SelectNodes("/Run/Segments/Segment");

            foreach (XmlNode segmentNode in segmentNodes)
            {
                var name = segmentNode.SelectSingleNode("Name").InnerText;

                var thresholdNode = segmentNode.SelectSingleNode(THRESHOLD_ELEMENT_NAME);

                if (thresholdNode != null)
                    thresholdNode.InnerText = values[name];
                else
                {
                    thresholdNode = doc.CreateElement(string.Empty, THRESHOLD_ELEMENT_NAME, string.Empty);
                    thresholdNode.InnerText = values[name];
                    segmentNode.AppendChild(thresholdNode);
                }
            }

            doc.Save(filePath);
        }

        private static XmlDocument LoadDocument(string filePath)
        {
            var doc = new XmlDocument();
            doc.Load(filePath);
            return doc;
        }
    }
}
