using System.Collections.Generic;
using System.Xml;
using LiveSplit.Model;
using System.IO;

namespace LiveSplit.CatchTheRun
{
    internal static class XmlHelper
    {
        private const string CREDENTIALS_ELEMENT_NAME = "Credentials";
        private const string CLIENT_ID_ELEMENT_NAME = "ClientID";
        private const string CLIENT_KEY_ELEMENT_NAME = "ClientKey";
        private readonly static string CREDENTIALS_FILEPATH = $@"{Directory.GetCurrentDirectory()}\CtrCredentials.xml";

        internal static ClientCredentials ReadClientCredentials()
        {
            if (!File.Exists(CREDENTIALS_FILEPATH))
            {
                CreateClientCredentialsFile();
                return new ClientCredentials() { ClientID = null, ClientKey = null };
            }

            var doc = new XmlDocument();
            doc.Load(CREDENTIALS_FILEPATH);

            var creds = doc.SelectSingleNode(CREDENTIALS_ELEMENT_NAME);

            var clientId = creds.SelectSingleNode(CLIENT_ID_ELEMENT_NAME).FirstChild?.Value;
            var clientKey = creds.SelectSingleNode(CLIENT_KEY_ELEMENT_NAME).FirstChild?.Value;

            return new ClientCredentials() { ClientID = clientId, ClientKey = clientKey };
        }

        internal static void CreateClientCredentialsFile()
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement creds = doc.CreateElement(string.Empty, CREDENTIALS_ELEMENT_NAME, string.Empty);
            doc.AppendChild(creds);

            XmlElement clientId = doc.CreateElement(string.Empty, CLIENT_ID_ELEMENT_NAME, string.Empty);
            creds.AppendChild(clientId);

            XmlElement clientKey = doc.CreateElement(string.Empty, CLIENT_KEY_ELEMENT_NAME, string.Empty);
            creds.AppendChild(clientKey);

            doc.Save(CREDENTIALS_FILEPATH);
        }

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

        internal static void WriteThreshold(string filePath, string splitName, string thresholdValue)
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
