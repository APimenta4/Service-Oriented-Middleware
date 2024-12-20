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
    public partial class FormNotifications : Form
    {
        private const string ApiUrl = "http://localhost:52653/api/somiod/";
        private const string HeaderName = "somiod-locate";
        RestClient client = null;

        private string containerName;
        private string contUrl;
        public FormNotifications(string appName, string contName)
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
                string selectedNotification = listBox1.SelectedItem.ToString();
                GetNotificationInfo(selectedNotification);
                ShowNotificationDetails();
            }
        }

        private void ShowNotificationDetails()
        {
            btnDelete.Visible = true;
            groupBox2.Visible = true;
        }

        private void GetNotificationInfo(string notificationName)
        {
            try
            {
                var request = new RestRequest($"{contUrl}/notif/{notificationName}", Method.Get);
                request.AddHeader("Accept", "application/xml");
                RestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var xmlResponse = XDocument.Parse(response.Content);
                    var notificationElement = xmlResponse.Element("Notification");

                    if (notificationElement != null)
                    {
                        string notificationId = notificationElement.Element("id")?.Value;
                        string name = notificationElement.Element("name")?.Value;
                        string creationDateRaw = notificationElement.Element("creation_datetime")?.Value;
                        string events = notificationElement.Element("event")?.Value;
                        string endpoint = notificationElement.Element("endpoint")?.Value;
                        string enabled = notificationElement.Element("enabled")?.Value;

                        string formattedDate = string.Empty;
                        if (DateTime.TryParse(creationDateRaw, out DateTime creationDate))
                        {
                            formattedDate = creationDate.ToString("HH:mm:ss dd-MM-yyyy");
                        }
                        else
                        {
                            formattedDate = "Invalid Date Format";
                        }

                        lblIdFill.Text = notificationId;
                        lblName.Text = name;
                        lblCreationDateFill.Text = formattedDate;
                        lblEventFill.Text = events;
                        lblEndpointFill.Text = endpoint;
                        lblEnableFill.Text = enabled;
                    }
                }
                else
                {
                    MessageBox.Show($"Error fetching notification info: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching notification info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormNotifications_Load(object sender, EventArgs e)
        {
            lblContainerName.Text = containerName;
            LoadNotifications();

            cmbEventType.Items.Clear();
            cmbEventType.Items.Add(new { Text = "1 - Creation", Value = "1" });
            cmbEventType.Items.Add(new { Text = "2 - Update", Value = "2" });
            cmbEventType.Items.Add(new { Text = "3 - Deletion", Value = "3" });
            cmbEventType.DisplayMember = "Text";
            cmbEventType.ValueMember = "Value";
        }

        private void LoadNotifications()
        {
            try
            {
                var request = new RestRequest(contUrl, Method.Get);
                request.AddHeader(HeaderName, "notification");
                request.AddHeader("Accept", "application/xml");
                RestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var xmlResponse = XDocument.Parse(response.Content);
                    listBox1.Items.Clear();

                    foreach (var element in xmlResponse.Descendants("name"))
                    {
                        string notificationName = element.Value;
                        listBox1.Items.Add(notificationName);
                    }
                }
                else
                {
                    MessageBox.Show($"Error fetching data: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading notifications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedNotification = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedNotification))
            {
                MessageBox.Show("Please select a notification to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var request = new RestRequest($"{contUrl}/notif/{selectedNotification}", Method.Delete);
                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("Accept", "application/xml");
                request.AddHeader(HeaderName, "notification");

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    MessageBox.Show($"Notification '{selectedNotification}' deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNotifications();
                }
                else
                {
                    MessageBox.Show($"Error deleting notification: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting notification: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string notificationName = txtBoxCreate.Text;
            string eventType = (cmbEventType.SelectedItem as dynamic)?.Value?.ToString(); // maybe needs to be changed
            string endpoint = txtEndpoint.Text;
            bool isEnabled = chkEnabled.Checked;

            if (string.IsNullOrEmpty(notificationName) || string.IsNullOrEmpty(eventType) || string.IsNullOrEmpty(endpoint))
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                XElement notificationElement = new XElement("Notification",
                 new XElement("name", notificationName),
                 new XElement("event", eventType),
                    new XElement("endpoint", endpoint),
                    new XElement("enabled", isEnabled.ToString())
);
                var request = new RestRequest($"{contUrl}", Method.Post);
                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("Accept", "application/xml");

                request.AddParameter("application/xml", notificationElement.ToString(), ParameterType.RequestBody);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show($"Notification '{notificationName}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNotifications();
                }
                else
                {
                    MessageBox.Show($"Error creating notification: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating notification: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
