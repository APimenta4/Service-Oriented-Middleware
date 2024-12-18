using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace SmartGreenhouse {
    public partial class Greenhouse : Form {

        private MqttListener mqttListener;

        private String applicationName;
        private String humidityContainerName;
        private String temperatureContainerName;
        private String lightContainerName;
        private string url;

        private int latestHumidityValue;
        private int latestTemperatureValue;
        private int latestLightValue;

        public Greenhouse() {
            InitializeComponent();
            dateLabel.Text = DateTime.Now.ToString("dddd   dd/MM/yyyy");
            btnHistoryHumidity.Enabled = false;
            btnHistoryTemperature.Enabled = false;
            btnHistoryLight.Enabled = false;
            btnSettings.Enabled = false;
            url = "http://localhost:52653/api/somiod/";
        }
        private void Greenhouse_Load(object sender, EventArgs e) {
            MessageBox.Show("Welcome to Smart Greenhouse!\n" +
                            "Before you start using the application, please click the 'Mount Application' button.\n" +
                            "This will communicate with SOMIOD to create the necessary resources.\n\n" +
                            "After mounting the application:\n" +
                            "In the settings button, you may change the value threshold to activate the different equipments (Watering, AC and Lights).\n\n" +                          
                            "You may also see the sensors' measures history, aswell as inspect and delete any specific record.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Greenhouse_FormClosing(object sender, FormClosingEventArgs e) {
            mqttListener.Stop();
        }

        private void btnMountApplication_Click(object sender, EventArgs e) {
            try {
                btnMountApplication.Enabled = false;
                applicationName = MountApplication();
                labelApplicationName.Text = applicationName;

                //humidityContainerName = MountContainer(applicationName, "Humidity");
                //temperatureContainerName = MountContainer(applicationName, "Temperature");
                //lightContainerName = MountContainer(applicationName, "Light");
                // TODO: messagging logic
                //MountNotification(applicationName, humidityContainerName, "HumidityNotif", 1, 127.0.0.1);
                //MountNotification(applicationName, temperatureContainerName, "TemperatureNotif", 1, 127.0.0.1);
                //MountNotification(applicationName, lightContainerName, "TemperatureNotif", 1, 127.0.0.1);

                mqttListener = new MqttListener(this, "testeHumidade", "testeTemperatura", "testeLuz");
                mqttListener.Start();

                btnHistoryHumidity.Enabled = true;
                btnHistoryTemperature.Enabled = true;
                btnHistoryLight.Enabled = true;
                btnSettings.Enabled = true;
            }
            catch (Exception ex) {
                btnMountApplication.Enabled = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("An error occurred while mounting the application. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region Windows 

        private Settings settingsWindow;
        private History humidityHistoryWindow;
        private History temperatureHistoryWindow;
        private History lightHistoryWindow;

        private void settings_Click(object sender, EventArgs e) {
            if (settingsWindow == null || settingsWindow.IsDisposed) {
                settingsWindow = new Settings(this);
                settingsWindow.StartPosition = FormStartPosition.Manual;
                settingsWindow.Location = new Point(this.Location.X + this.Width - 12, this.Location.Y);
                settingsWindow.Show();
            }
            else {
                settingsWindow.Close();
                settingsWindow = null;
            }
        }

        private void btnHistoryHumidity_Click(object sender, EventArgs e) {
            if (humidityHistoryWindow == null || humidityHistoryWindow.IsDisposed) {
                humidityHistoryWindow = new History(url, applicationName, humidityContainerName);
                humidityHistoryWindow.StartPosition = FormStartPosition.Manual;
                humidityHistoryWindow.Location = new Point(this.Location.X + this.Width - 12, this.Location.Y);
                humidityHistoryWindow.Show();
            }
            else {
                humidityHistoryWindow.Close();
                humidityHistoryWindow = null;
            }
        }

        private void btnHistoryTemperature_Click(object sender, EventArgs e) {
            if (temperatureHistoryWindow == null || temperatureHistoryWindow.IsDisposed) {
                temperatureHistoryWindow = new History(url, applicationName, temperatureContainerName);
                temperatureHistoryWindow.StartPosition = FormStartPosition.Manual;
                temperatureHistoryWindow.Location = new Point(this.Location.X + this.Width - 12, this.Location.Y + 30);
                temperatureHistoryWindow.Show();
            }
            else {
                temperatureHistoryWindow.Close();
                temperatureHistoryWindow = null;
            }
        }

        private void btnHistoryLight_Click(object sender, EventArgs e) {
            if (lightHistoryWindow == null || lightHistoryWindow.IsDisposed) {
                lightHistoryWindow = new History(url, applicationName, lightContainerName);
                lightHistoryWindow.StartPosition = FormStartPosition.Manual;
                lightHistoryWindow.Location = new Point(this.Location.X + this.Width - 12, this.Location.Y + 60);
                lightHistoryWindow.Show();
            }
            else {
                lightHistoryWindow.Close();
                lightHistoryWindow = null;
            }
        }


        #endregion

        #region Update Methods
        public void updateHumidity(int value) {
            // Need this "if" to update the UI from the MQTT class
            if (this.InvokeRequired) {
                this.Invoke(new Action<int>(updateHumidity), value);
            }
            latestHumidityValue = value;
            humidityLabel.Text = "Latest Value: " + latestHumidityValue + "%";
            reloadHumidityPicture();
        }

        public void reloadHumidityPicture() {
            if(latestHumidityValue > 0 && latestHumidityValue < humidityThreshold) {
                pictureBoxHumidity.Image = Properties.Resources.on;
            }
            else {
                pictureBoxHumidity.Image = Properties.Resources.off;
            }
        }

        public void updateTemperature(int value) {
            // Need this "if" to update the UI from the MQTT class
            if (this.InvokeRequired) {
                this.Invoke(new Action<int>(updateHumidity), value);
            }
            latestTemperatureValue = value;
            temperatureLabel.Text = "Latest Value: " + latestTemperatureValue + "°C";
            reloadTemperaturePicture();
        }

        public void reloadTemperaturePicture() {
            if (latestTemperatureValue > 0 && latestTemperatureValue < temperatureThreshold) {
                pictureBoxTemperature.Image = Properties.Resources.on;
            }
            else {
                pictureBoxTemperature.Image = Properties.Resources.off;
            }
        }

        public void updateLight(int value) {
            // Need this "if" to update the UI from the MQTT class
            if (this.InvokeRequired) {
                this.Invoke(new Action<int>(updateHumidity), value);
            }
            latestLightValue = value;
            lightsLabel.Text = "Latest Value: " + latestLightValue + " lux";
            reloadLightPicture();
        }

        public void reloadLightPicture() {
            if (latestLightValue > 0 && latestLightValue < lightsThreshold) {
                pictureBoxLights.Image = Properties.Resources.on;
            }
            else {
                pictureBoxLights.Image = Properties.Resources.off;
            }
        }

        #endregion

        #region Thresholds

        // Default thresholds
        private int humidityThreshold = 15;
        private int temperatureThreshold = 25;
        private int lightsThreshold = 1500;

        public int HumidityThreshold {
            get { return humidityThreshold; }
            set { humidityThreshold = value; }
        }

        public int TemperatureThreshold {
            get { return temperatureThreshold; }
            set { temperatureThreshold = value; }
        }

        public int LightsThreshold {
            get { return lightsThreshold; }
            set { lightsThreshold = value; }
        }

        #endregion

        #region Helper Methods

        private string MountApplication() {
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/xml");
            request.AddHeader("Accept", "application/xml");

            // Create and append the xml
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement applicationElement = xmlDoc.CreateElement("Application");
            XmlElement nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = "Greenhouse";
            applicationElement.AppendChild(nameElement);
            xmlDoc.AppendChild(applicationElement);
            string xmlContent = xmlDoc.OuterXml;
            request.AddParameter("application/xml", xmlContent, ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.IsSuccessful) {
                XmlDocument responseXml = new XmlDocument();
                responseXml.LoadXml(response.Content);
                XmlNode nameNode = responseXml.GetElementsByTagName("name")[0];
                return nameNode.InnerText;
            }
            else {
                throw new Exception(response.ErrorMessage);
            }
        }

        private string MountContainer(String applicationName, String containerName) {
            string endpoint = url + applicationName;
            var client = new RestClient(endpoint);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/xml");
            request.AddHeader("Accept", "application/xml");

            // Create and append the xml
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement containerElement = xmlDoc.CreateElement("Container");
            XmlElement nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = containerName;
            containerElement.AppendChild(nameElement);
            xmlDoc.AppendChild(containerElement);
            string xmlContent = xmlDoc.OuterXml;
            request.AddParameter("application/xml", xmlContent, ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.IsSuccessful) {
                XmlDocument responseXml = new XmlDocument();
                responseXml.LoadXml(response.Content);
                XmlNode nameNode = responseXml.GetElementsByTagName("name")[0];
                return nameNode.InnerText;
            }
            else {
                throw new Exception(response.ErrorMessage);
            }
        }

        private void MountNotification(string applicationName, string containerName, string notificationName, int @event, string messageEndpoint) {
            string endpoint = url + applicationName;
            var client = new RestClient(endpoint);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/xml");
            request.AddHeader("Accept", "application/xml");

            // Create and append the XML
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement notificationElement = xmlDoc.CreateElement("Notification");

            XmlElement nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = notificationName;
            notificationElement.AppendChild(nameElement);

            XmlElement eventElement = xmlDoc.CreateElement("event");
            eventElement.InnerText = @event.ToString();
            notificationElement.AppendChild(eventElement);

            XmlElement endpointElement = xmlDoc.CreateElement("endpoint");
            endpointElement.InnerText = messageEndpoint;
            notificationElement.AppendChild(endpointElement);

            xmlDoc.AppendChild(notificationElement);
            string xmlContent = xmlDoc.OuterXml;
            request.AddParameter("application/xml", xmlContent, ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.IsSuccessful) {
                return;
            }
            else {
                throw new Exception(response.ErrorMessage);
            }
        }


        #endregion



    }
}

