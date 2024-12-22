using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Sensors {
    public partial class Sensors : Form {

        private String url;
        private String applicationName;
        public Sensors() {
            InitializeComponent();
            numericHumidityValue.Value = 12;
            numericTemperatureValue.Value = 30;
            numericLightValue.Value = 1200;
            buttonHumidity.Enabled = false;
            buttonTemperature.Enabled = false;
            buttonLight.Enabled = false;
            numericHumidityValue.Enabled = false;
            numericTemperatureValue.Enabled = false;
            numericLightValue.Enabled = false;
            url = "http://localhost:52653/api/somiod/";
        }
        private void buttonConfirm_Click(object sender, EventArgs e) {
            applicationName = textBoxApplicatioName.Text;
            if (applicationName != "") {
                buttonHumidity.Enabled = true;
                buttonTemperature.Enabled = true;
                buttonLight.Enabled = true;
                numericHumidityValue.Enabled = true;
                numericTemperatureValue.Enabled = true;
                numericLightValue.Enabled = true;
            }
        }

        private void buttonHumidity_Click(object sender, EventArgs e) {
            registerValue(url, applicationName, "Humidity", numericHumidityValue.Value.ToString());
        }

        private void buttonTemperature_Click(object sender, EventArgs e) {
            registerValue(url, applicationName, "Temperature", numericTemperatureValue.Value.ToString());

        }

        private void buttonLight_Click(object sender, EventArgs e) {
            registerValue(url, applicationName, "Light", numericLightValue.Value.ToString());
        }

        private void registerValue(String url, String applicationName, String containerName, String value) {
            string endpoint = url + applicationName + "/" + containerName;
            var client = new RestClient(endpoint);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/xml");

            // Create and append the XML
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement recordElement = xmlDoc.CreateElement("Record");

            XmlElement nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = "record";
            recordElement.AppendChild(nameElement);

            XmlElement contentElement = xmlDoc.CreateElement("content");
            contentElement.InnerText = value;
            recordElement.AppendChild(contentElement);

            xmlDoc.AppendChild(recordElement);
            string xmlContent = xmlDoc.OuterXml;
            request.AddParameter("application/xml", xmlContent, ParameterType.RequestBody);

            var response = client.Execute(request);
            if (response.IsSuccessful) {
                return;
            }
            else {
                Console.WriteLine(response.ErrorMessage);
            }

        }


    }
}
