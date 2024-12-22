using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace SmartGreenhouse {
    internal class MqttListener {

        private MqttClient mqttClient;
        private String brokerAddress = "127.0.0.1";
        private Greenhouse greenhouseWindow;
        private String humidityTopic;
        private String temperatureTopic;
        private String lightTopic;
        byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };

        private List<TimeRangeConfig> timeRanges;

        public MqttListener(Greenhouse greenhouseWindow, String humidityTopic, String temperatureTopic, string lightTopic) {
            this.greenhouseWindow = greenhouseWindow;
            this.humidityTopic = humidityTopic;
            this.temperatureTopic = temperatureTopic;
            this.lightTopic = lightTopic;

            this.timeRanges = LoadTimeRanges();
        }

        public void Start() {
            mqttClient = new MqttClient(brokerAddress);
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Connect(Guid.NewGuid().ToString());
            string[] topics = { humidityTopic, temperatureTopic, lightTopic };
            mqttClient.Subscribe(topics, qosLevels);
        }

        public void Stop() {
            if (mqttClient.IsConnected) {
                mqttClient.Disconnect();
            }
        }

        private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) {
            string message = Encoding.UTF8.GetString(e.Message);
            string topic = e.Topic;
            CheckThreshold(message, topic);
        }

        private void CheckThreshold(string MqttMessage, string topic) {
            XmlDocument xmlDoc = new XmlDocument();
            try {
                xmlDoc.LoadXml(MqttMessage);
                XmlNode eventNode = xmlDoc.SelectSingleNode("//event");
                XmlNode contentNode = xmlDoc.SelectSingleNode("//record/content");

                if (eventNode.InnerText == "creation" && contentNode != null) {
                    int value;
                    bool isParsed = int.TryParse(contentNode.InnerText, out value);
                    if (isParsed) {
                        // Check if the message time is within the defined time ranges
                        DateTime currentTime = DateTime.Now;

                        foreach (var timeRange in timeRanges) {
                            if (currentTime >= timeRange.StartTime && currentTime <= timeRange.EndTime) {
                                // If the time is within the range, serialize the message
                                string outputFileName = timeRange.OutputFileName;
                                SerializeNotificationToXml(MqttMessage, outputFileName);
                                break;
                            }
                        }

                        // Update the greenhouse data
                        if (topic == humidityTopic) {
                            greenhouseWindow.updateHumidity(value);
                        }
                        else if (topic == temperatureTopic) {
                            greenhouseWindow.updateTemperature(value);
                        }
                        else if (topic == lightTopic) {
                            greenhouseWindow.updateLight(value);
                        }
                        else {
                            // Other topics - No implementation planned for now
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


        private void SerializeNotificationToXml(string notification, string outputFileName) {
            try {
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                // Save in project root, not in default .NET project (bin\Debug)
                string rootDirectory = Path.GetFullPath(Path.Combine(projectRoot, @"..\.."));
                string saveDirectory = Path.Combine(rootDirectory, "Notifications");

                if (!Directory.Exists(saveDirectory)) {
                    Directory.CreateDirectory(saveDirectory);
                }

                string fullOutputPath = Path.Combine(saveDirectory, outputFileName);

                XmlDocument xmlDoc = new XmlDocument();
                if (File.Exists(fullOutputPath)) {
                    xmlDoc.Load(fullOutputPath);
                }
                else {
                    XmlNode declaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    xmlDoc.AppendChild(declaration);
                    XmlNode rootNode = xmlDoc.CreateElement("notifications");
                    xmlDoc.AppendChild(rootNode);
                }

                XmlNode notificationNode = xmlDoc.CreateElement("notification");
                XmlNode messageNode = xmlDoc.CreateElement("message");
                messageNode.InnerXml = notification;

                notificationNode.AppendChild(messageNode);

                xmlDoc.DocumentElement.AppendChild(notificationNode);

                xmlDoc.Save(fullOutputPath);
            }
            catch (Exception ex) {
                Console.WriteLine("Error serializing notification: " + ex.Message);
            }
        }




        private List<TimeRangeConfig> LoadTimeRanges() {
            List<TimeRangeConfig> timeRanges = new List<TimeRangeConfig>();

            try {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("configuration.xml");

                // Select all <timeRange> nodes in the XML
                XmlNodeList timeRangeNodes = xmlDoc.SelectNodes("//configuration/timeRanges/timeRange");

                foreach (XmlNode timeRangeNode in timeRangeNodes) {
                    // Parse the start and end times
                    DateTime startTime = DateTime.Parse(timeRangeNode.SelectSingleNode("start").InnerText);
                    DateTime endTime = DateTime.Parse(timeRangeNode.SelectSingleNode("end").InnerText);
                    string outputFileName = timeRangeNode.SelectSingleNode("outputFileName").InnerText;

                    // Add the time range configuration to the list
                    timeRanges.Add(new TimeRangeConfig {
                        StartTime = startTime,
                        EndTime = endTime,
                        OutputFileName = outputFileName
                    });
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error loading time ranges: " + ex.Message);
            }

            return timeRanges;
        }



    }

    // Helper class to store time range configuration
    internal class TimeRangeConfig {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string OutputFileName { get; set; }
    }

}

