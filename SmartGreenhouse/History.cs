using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SmartGreenhouse {
    public partial class History : Form {

        private String url;

        private String applicationName;
        private String containerName;
        public String ApplicationName { get { return applicationName; } }
        public String ContainerName { get { return containerName; } }


        public History(String url, String applicationName, String containerName) {
            InitializeComponent();
            this.url = url;
            labelTitle.Text = containerName;

            this.applicationName = applicationName;
            this.containerName = containerName;

            String[] items = FetchItems();
            // Reverse to array simulate history
            Array.Reverse(items);

            foreach (string item in items) {
                HistoryRow row = new HistoryRow(item, url, this);
                row.Dock = DockStyle.Top;
                panelHistory.Controls.Add(row);
            }
        }

        public string[] FetchItems() {
            string[] results;
            string endpoint = url + applicationName + "/" + containerName;

            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Accept", "application/xml");
            request.AddHeader("somiod-locate", "record");

            try {
                var response = client.Execute(request);
                if (response.IsSuccessful) {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(response.Content);
                    XmlNodeList itemNodes = xmlDoc.GetElementsByTagName("string");

                    results = new string[itemNodes.Count];
                    for (int i = 0; i < itemNodes.Count; i++) {
                        results[i] = itemNodes[i].InnerText.Trim();
                    }
                }
                else {
                    results = Array.Empty<string>();
                }
            }
            catch (Exception) {
                results = Array.Empty<string>();
            }

            return results;
        }



    }
}
