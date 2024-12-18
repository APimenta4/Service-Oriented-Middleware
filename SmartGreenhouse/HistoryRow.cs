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

namespace SmartGreenhouse {
    public partial class HistoryRow : UserControl {

        private String url;
        private History historyWindow;
        public HistoryRow(String name, String url, History historyWindow) {
            InitializeComponent();
            labelName.Text = name;
            this.url = url;
            this.historyWindow = historyWindow;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            sendRequest(Method.Delete);
            historyWindow.FetchItems();
        }

        private void btnGet_Click(object sender, EventArgs e) {
            RestResponse response = sendRequest(Method.Get);
            XmlDocument responseXml = new XmlDocument();
            responseXml.LoadXml(response.Content);
            MessageBox.Show(responseXml.OuterXml, labelName.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private RestResponse sendRequest(Method httpMethod) {
            string endpoint = url + historyWindow.ApplicationName + "/" + historyWindow.ContainerName + "/" + labelName.Text;
            var client = new RestClient(endpoint);
            var request = new RestRequest();
            request.Method = httpMethod;
            var response = client.Execute(request);
            if (response.IsSuccessful) {
                return response;
            }
            else {
                throw new Exception(response.ErrorMessage);
            }
        }
    }
}
