using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private async void btnDelete_Click(object sender, EventArgs e) {
            await sendRequestAsync(Method.Delete);
            historyWindow.FetchAndDisplayItems();
        }

        private async void btnGet_Click(object sender, EventArgs e) {
            RestResponse response = await sendRequestAsync(Method.Get);
            XmlDocument responseXml = new XmlDocument();
            responseXml.LoadXml(response.Content);

            // Format the XML for better readability
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter) {
                Formatting = Formatting.Indented 
            };
            responseXml.WriteTo(xmlTextWriter);


            MessageBox.Show(stringWriter.ToString(), labelName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task<RestResponse> sendRequestAsync(Method httpMethod) {
            string endpoint = url + historyWindow.ApplicationName + "/" + historyWindow.ContainerName + "/record/" + labelName.Text;
            var client = new RestClient(endpoint);
            client.AddDefaultHeader("Accept", "application/xml");
            var request = new RestRequest {
                Method = httpMethod
            };
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful) {
                return response;
            }
            else {
                throw new Exception(response.ErrorMessage);
            }
        }

    }
}
