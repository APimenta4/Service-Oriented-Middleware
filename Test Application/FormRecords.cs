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
    public partial class FormRecords : Form
    {
        private const string ApiUrl = "http://localhost:52653/api/somiod/";
        private const string HeaderName = "somiod-locate";
        RestClient client = null;

        private string containerName;
        private string contUrl;
        public FormRecords(string appName, string contName)
        {
            InitializeComponent();
            containerName = contName;
            contUrl = ApiUrl + appName + "/" + containerName;
            client = new RestClient();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedRecord = listBox1.SelectedItem.ToString();
                GetRecordInfo(selectedRecord);
                ShowRecordDetails();
            }
        }

        private void ShowRecordDetails()
        {
            btnDelete.Visible = true;
            groupBox2.Visible = true;
        }
        private void GetRecordInfo(string recordName)
        {
            try
            {
                var request = new RestRequest($"{contUrl}/record/{recordName}", Method.Get);
                request.AddHeader("Accept", "application/xml");
                RestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var xmlResponse = XDocument.Parse(response.Content);
                    var recordElement = xmlResponse.Element("Record");

                    if (recordElement != null)
                    {
                        string recordId = recordElement.Element("id")?.Value;
                        string name = recordElement.Element("name")?.Value;
                        string creationDateRaw = recordElement.Element("creation_datetime")?.Value;
                        string content = recordElement.Element("content")?.Value;

                        string formattedDate = string.Empty;
                        if (DateTime.TryParse(creationDateRaw, out DateTime creationDate))
                        {
                            formattedDate = creationDate.ToString("HH:mm:ss dd-MM-yyyy");
                        }
                        else
                        {
                            formattedDate = "Invalid Date Format";
                        }

                        lblIdFill.Text = recordId;
                        lblName.Text = name;
                        lblCreationDateFill.Text = formattedDate;
                        lblContentFill.Text = content;
                    }
                }
                else
                {
                    MessageBox.Show($"Error fetching record info: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching record info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormRecords_Load(object sender, EventArgs e)
        {
            lblContainerName.Text = containerName;
            LoadRecords();
        }

        private void LoadRecords()
        {
            try
            {
                var request = new RestRequest(contUrl, Method.Get);
                request.AddHeader(HeaderName, "record");
                request.AddHeader("Accept", "application/xml");
                RestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var xmlResponse = XDocument.Parse(response.Content);
                    listBox1.Items.Clear();

                    foreach (var appElement in xmlResponse.Descendants("name"))
                    {
                        string recordName = appElement.Value;
                        listBox1.Items.Add(recordName);
                    }
                }
                else
                {
                    MessageBox.Show($"Error fetching data: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedRecord = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedRecord))
            {
                MessageBox.Show("Please select a record to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var request = new RestRequest($"{contUrl}/record/{selectedRecord}", Method.Delete);
                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("Accept", "application/xml");
                request.AddHeader(HeaderName, "record");

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    MessageBox.Show($"Record '{selectedRecord}' deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
                else
                {
                    MessageBox.Show($"Error deleting record: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string recordName = txtBoxCreate.Text;
            string content = txtContent.Text;
            if (string.IsNullOrEmpty(recordName) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Please enter a record name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                XDocument xmlData = new XDocument(
                    new XElement("Record",
                        new XElement("name", recordName),
                        new XElement("content", content)
                    )
                );

                var request = new RestRequest(contUrl, Method.Post);
                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("Accept", "application/xml");
                request.AddParameter("application/xml", xmlData.ToString(), ParameterType.RequestBody);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show($"Record '{recordName}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
                else
                {
                    MessageBox.Show($"Error creating record: {response.Content}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
