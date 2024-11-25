using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Test_Application {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            comboBoxHeaderValue.Items.Add("application");
            comboBoxHeaderValue.Items.Add("container");
            comboBoxHeaderValue.Items.Add("record");
            comboBoxHeaderValue.Items.Add("notification");
            comboBoxMethodValue.Items.Add("GET");
            comboBoxMethodValue.Items.Add("POST");
            comboBoxMethodValue.Items.Add("PUT");
            comboBoxMethodValue.Items.Add("DELETE");
            comboBoxBodyType.Items.Add("application");
            comboBoxBodyType.Items.Add("container");
            comboBoxBodyType.Items.Add("record");
            comboBoxBodyType.Items.Add("notification");
        }

        private async void sendRequestClick(object sender, EventArgs e) {
            try {
                string fullUrl = "http://localhost:" + textBoxLocalHost.Text.Trim() + textBoxUrl.Text.Trim();
                string body = richTextBoxBody.Text;
                string method = comboBoxMethodValue.Text;

                using (HttpClient client = new HttpClient()) {
                    client.DefaultRequestHeaders.Add("Accept", "application/xml");

                    if (checkBoxIncludeHeader.Checked && !string.IsNullOrWhiteSpace(comboBoxHeaderValue.Text)) {
                        client.DefaultRequestHeaders.Add("somiod-locate", comboBoxHeaderValue.Text);
                    }

                    HttpContent content = null;
                    if ((method == "POST" || method == "PUT") && !string.IsNullOrWhiteSpace(body)) {
                        content = new StringContent(body, Encoding.UTF8, "application/json");
                    }

                    HttpResponseMessage response;
                    if (method == "GET" || method == "DELETE") {
                        response = await client.SendAsync(new HttpRequestMessage(new HttpMethod(method), fullUrl));
                    }
                    else {
                        response = await client.SendAsync(new HttpRequestMessage(new HttpMethod(method), fullUrl) { Content = content });
                    }

                    string responseBody = await response.Content.ReadAsStringAsync();
                    richTextBoxResponseBody.Text = responseBody;
                    textBoxStatusCode.Text = ((int)response.StatusCode).ToString();
                }
            }
            catch (Exception ex) {
                richTextBoxResponseBody.Text = $"Error: {ex.Message}";
                textBoxStatusCode.Text = "Error";
            }
        }

        private void comboBoxBodyType_SelectedIndexChanged(object sender, EventArgs e) {
            switch (comboBoxBodyType.SelectedItem.ToString()) {
                case "application":
                    richTextBoxBody.Text =
                        "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                        "<application>\n" +
                        "    <name>Appli1</name>\n" +
                        "</application>";
                    break;
                case "container":
                    richTextBoxBody.Text =
                        "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                        "<container>\n" +
                        "    <name>Contai1</name>\n" +
                        "    <parent>1</parent>\n" +
                        "</container>";
                    break;
                case "record":
                    richTextBoxBody.Text =
                        "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                        "<record>\n" +
                        "    <name>Record1</name>\n" +
                        "    <content>Content1</content>\n" +
                        "    <parent>1</parent>\n" +
                        "</record>";
                    break;
                case "notification":
                    richTextBoxBody.Text =
                        "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                        "<notification>\n" +
                        "    <name>Notification1</name>\n" +
                        "    <parent>1</parent>\n" +
                        "    <event>creation</event>\n" +
                        "    <endpoint>http://url:8080</endpoint>\n" +
                        "</notification>";
                    break;
                default:
                    richTextBoxBody.Text = "";
                    break;
            }
        }

    }


}
