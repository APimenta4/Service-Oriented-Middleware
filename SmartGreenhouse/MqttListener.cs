using System;
using System.Collections.Generic;
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
        byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };

        public MqttListener(Greenhouse greenhouseWindow, String humidityTopic, String temperatureTopic, string lightTopic) {
            this.greenhouseWindow = greenhouseWindow;
            this.humidityTopic = humidityTopic;
            this.temperatureTopic = temperatureTopic;
            this.lightTopic = lightTopic;
        }

        public void Start() {
            mqttClient = new MqttClient(brokerAddress);
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Connect(Guid.NewGuid().ToString());
            string[] topics = { humidityTopic, temperatureTopic };
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
                        if (topic == "humidityTopic") {
                            greenhouseWindow.updateHumidity(value);
                        }
                        else if (topic == "temperatureTopic") {
                            greenhouseWindow.updateTemperature(value);
                        }
                        else if (topic == "lightTopic") {
                            greenhouseWindow.updateLight(value);
                        }
                        else {
                            // Others topics
                            // No implementation planned for now
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }
}
