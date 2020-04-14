using System.Collections.Generic;
using System.Xml;
using System;
using System.Linq;

namespace LiveSplit.CatchTheRun
{
    internal static class Xml
    {
        private const string METADATA_CHILD_ELEMENT_NAME = "CatchTheRun";
        private const string IS_CATEGORY_REGISTERED_ATTRIBUTE_NAME = "isCategoryRegistered";
        private const string THRESHOLD_ELEMENT_NAME = "CtrThreshold";

        internal static bool ReadIsCategoryRegistered(string filePath)
        {
            var doc = LoadDocument(filePath);
            return doc.SelectSingleNode($"Run/Metadata/{METADATA_CHILD_ELEMENT_NAME}")?.Attributes[IS_CATEGORY_REGISTERED_ATTRIBUTE_NAME]?.Value == "True";
        }

        internal static void WriteIsCategoryRegistered(string filePath, bool value)
        {
            var doc = LoadDocument(filePath);

            var metadataNode = doc.SelectSingleNode($"Run/Metadata");
            var ctrNode = metadataNode?.SelectSingleNode(METADATA_CHILD_ELEMENT_NAME);

            if (ctrNode != null)
                ctrNode.Attributes[IS_CATEGORY_REGISTERED_ATTRIBUTE_NAME].Value = value ? "True" : "False";
            else
            {
                ctrNode = doc.CreateElement(string.Empty, METADATA_CHILD_ELEMENT_NAME, string.Empty);
                ctrNode.Attributes[IS_CATEGORY_REGISTERED_ATTRIBUTE_NAME].Value = value ? "True" : "False";
                metadataNode.AppendChild(ctrNode);
            }

            doc.Save(filePath);
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
                    var segmentName = segmentNode.SelectSingleNode("Name").InnerText;
                    var pbSplitTime = segmentNode
                                        .SelectNodes("SplitTimes/SplitTime")
                                        .Cast<XmlNode>()
                                        .FirstOrDefault(splitTimeNode => splitTimeNode.Attributes["name"].Value == "Personal Best")
                                        .FirstChild
                                        .InnerText;

                    var thresholdNodeText = segmentNode.SelectSingleNode(THRESHOLD_ELEMENT_NAME)?.InnerText;
                    var thresholdValue = !string.IsNullOrWhiteSpace(thresholdNodeText) ? thresholdNodeText : null;
                    return new Threshold() { SegmentName = segmentName, PersonalBestSplitTime = pbSplitTime, Value = thresholdValue };
                }
            }).ToList();
        }

        internal static void WriteThresholds(string filePath, Dictionary<string, string> values)
        {
            var doc = LoadDocument(filePath);

            XmlNodeList segmentNodes = doc.SelectNodes("/Run/Segments/Segment");

            foreach (XmlNode segmentNode in segmentNodes)
            {
                var segmentName = segmentNode.SelectSingleNode("Name").InnerText;

                var thresholdNode = segmentNode.SelectSingleNode(THRESHOLD_ELEMENT_NAME);

                if (thresholdNode != null)
                    thresholdNode.InnerText = values[segmentName];
                else
                {
                    thresholdNode = doc.CreateElement(string.Empty, THRESHOLD_ELEMENT_NAME, string.Empty);
                    thresholdNode.InnerText = values[segmentName];
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
