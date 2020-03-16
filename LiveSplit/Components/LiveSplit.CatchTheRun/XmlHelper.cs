using System.Collections.Generic;
using System.Xml;
using LiveSplit.Model;
using System.IO;
using System.Windows.Forms;

namespace LiveSplit.CatchTheRun
{
    internal class XmlHelper
    {
        private string CREDENTIALS_FILEPATH { get; set; }

        internal XmlHelper(string splitDirectory)
        {
            CREDENTIALS_FILEPATH = $@"{splitDirectory}\CtrCredentials.xml";
        }

        internal ClientCredentials ReadClientCredentials()
        {
            if (!File.Exists(CREDENTIALS_FILEPATH))
            {
                CreateClientCredentialsFile();
                return new ClientCredentials() { ClientID = null, ClientKey = null };
            }

            var doc = new XmlDocument();
            doc.Load(CREDENTIALS_FILEPATH);

            var credsNode = doc.SelectSingleNode(Util.CREDENTIALS_ELEMENT_NAME);

            var clientId = credsNode.SelectSingleNode(Util.CLIENT_ID_ELEMENT_NAME).InnerText;
            var clientKey = credsNode.SelectSingleNode(Util.CLIENT_KEY_ELEMENT_NAME).InnerText;

            return new ClientCredentials() { ClientID = clientId, ClientKey = clientKey };
        }

        internal void WriteClientCredentials(string clientId, string clientKey)
        {
            if (!File.Exists(CREDENTIALS_FILEPATH))
                CreateClientCredentialsFile();

            var doc = new XmlDocument();
            doc.Load(CREDENTIALS_FILEPATH);

            var credsNode = doc.SelectSingleNode(Util.CREDENTIALS_ELEMENT_NAME);

            var clientIdNode = credsNode.SelectSingleNode(Util.CLIENT_ID_ELEMENT_NAME);
            clientIdNode.InnerText = clientId;

            var clientKeyNode = credsNode.SelectSingleNode(Util.CLIENT_KEY_ELEMENT_NAME);
            clientKeyNode.InnerText = clientKey;

            doc.Save(CREDENTIALS_FILEPATH);
        }

        internal void CreateClientCredentialsFile()
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement creds = doc.CreateElement(string.Empty, Util.CREDENTIALS_ELEMENT_NAME, string.Empty);
            doc.AppendChild(creds);

            XmlElement clientId = doc.CreateElement(string.Empty, Util.CLIENT_ID_ELEMENT_NAME, string.Empty);
            creds.AppendChild(clientId);

            XmlElement clientKey = doc.CreateElement(string.Empty, Util.CLIENT_KEY_ELEMENT_NAME, string.Empty);
            creds.AppendChild(clientKey);

            doc.Save(CREDENTIALS_FILEPATH);
        }

        internal List<Threshold> ReadThresholds(string filePath)
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

        internal void WriteThresholds(string filePath, Dictionary<string, string> thresholdValues)
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
        }
    }
}
