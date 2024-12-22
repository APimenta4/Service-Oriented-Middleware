using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Test_Application
{
    public partial class FormNotifRecodsTable : Form
    {
        private const string ApiUrl = "http://localhost:52653/api/somiod/";
        private const string HeaderName = "somiod-locate";
        RestClient client = null;

        private string applicationName;
        private string getUrl;
        private string headerValue;
        public FormNotifRecodsTable(string appName, string type)
        {
            InitializeComponent();
            client = new RestClient(ApiUrl);
            applicationName = appName;
            getUrl = ApiUrl + applicationName;
            headerValue = type;
        }

        private void FormNotifRecodsTable_Load(object sender, EventArgs e)
        {
            LoadInfo(headerValue);
            if(headerValue == "notification")
            {
                lblTitle.Text = "Notifications of:";
            }
            else if(headerValue == "record")
            {
                lblTitle.Text = "Records of:";
            }
            lblApplicationName.Text = applicationName;
        }

        private void LoadInfo(string headerValue)
        {
            try
            {
                var request = new RestRequest(getUrl, Method.Get);
                request.AddHeader(HeaderName, headerValue);
                request.AddHeader("Accept", "application/xml");
                RestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var xmlResponse = XDocument.Parse(response.Content);
                    listBox1.Items.Clear();

                    foreach (var element in xmlResponse.Descendants("name"))
                    {
                        string containerName = element.Value;
                        listBox1.Items.Add(containerName);
                    }
                }
                else
                {
                    MessageBox.Show($"Error fetching {headerValue} info: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching {headerValue} info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
