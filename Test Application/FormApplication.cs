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
using RestSharp;

namespace Test_Application
{
    public partial class FormApplication : Form
    {
        private const string ApiUrl = "http://localhost:52653/api/somiod";
        private const string HeaderName = "somiod-locate";
        RestClient client = null;

        public FormApplication()
        {
            InitializeComponent();
            client = new RestClient(ApiUrl);


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadApplications();
        }

        private void LoadApplications()
        {
            try
            {
                var request = new RestRequest(ApiUrl, Method.Get);
                request.AddHeader(HeaderName, "application");
                request.AddHeader("Accept", "application/xml");
                RestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var xmlResponse = XDocument.Parse(response.Content);
                    listBox1.Items.Clear();

                    foreach (var appElement in xmlResponse.Descendants("name"))
                    {
                        string appName = appElement.Value;
                        listBox1.Items.Add(appName);
                    }
                }
                else
                {
                    MessageBox.Show($"Error fetching data: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading applications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateApplication_Click(object sender, EventArgs e)
        {
            string applicationName = txtBoxCreateApp.Text;
            if (string.IsNullOrEmpty(applicationName))
            {
                MessageBox.Show("Please enter an application name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                XDocument xmlData = new XDocument(
                    new XElement("Application",
                        new XElement("name", applicationName)
                    )
                );

                var request = new RestRequest(ApiUrl, Method.Post);
                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("Accept", "application/xml");
                request.AddHeader(HeaderName, "application");
                request.AddParameter("application/xml", xmlData.ToString(), ParameterType.RequestBody);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show($"Application '{applicationName}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadApplications();
                }
                else
                {
                    MessageBox.Show($"Error creating application: {response.Content}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedApplication = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedApplication))
            {
                MessageBox.Show("Please select an application to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try 
            {
                string url = ApiUrl + $"/{selectedApplication}";
                var request = new RestRequest(url, Method.Delete);

                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("Accept", "application/xml");
                request.AddHeader(HeaderName, "application");

                RestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    MessageBox.Show($"Application '{selectedApplication}' deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadApplications();
                }
                else
                {
                    MessageBox.Show($"Error deleting application: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string selectedApplication = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedApplication))
            {
                MessageBox.Show("Please select an application to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newApplicationName = txtBoxUpdateApp.Text;
            if (string.IsNullOrEmpty(newApplicationName))
            {
                MessageBox.Show("Please enter a new name for the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                XDocument xmlData = new XDocument(
                    new XElement("Application",
                        new XElement("name", newApplicationName)
                    )
                );

                string url = $"{ApiUrl}/{selectedApplication}";
                var request = new RestRequest(url, Method.Put);
                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("Accept", "application/xml");
                request.AddHeader(HeaderName, "application");
                request.AddParameter("application/xml", xmlData.ToString(), ParameterType.RequestBody);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show($"Application '{selectedApplication}' updated successfully to '{newApplicationName}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadApplications();
                }
                else
                {
                    MessageBox.Show($"Error updating application: {response.Content}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContainers_Click(object sender, EventArgs e)
        {
            string selectedApplication = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedApplication))
            {
                MessageBox.Show("Please select an application to view its containers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string url = $"{ApiUrl}/{selectedApplication}";
            var request = new RestRequest(url, Method.Get);
            request.AddHeader(HeaderName, "container");
            request.AddHeader("Accept", "application/xml");

            RestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var xmlResponse = XDocument.Parse(response.Content);

                if (!xmlResponse.Descendants("name").Any())
                {
                    //Dialog box with Return and Continue buttons
                    DialogResult result = MessageBox.Show(
                        "There are no containers available for this application.\nWould you like to continue?",
                        "No Containers Found",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Error fetching containers: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormContainer formContainers = new FormContainer(selectedApplication);
            formContainers.ShowDialog();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                string selectedApp = listBox1.SelectedItem.ToString();
                getApplicationInfo(selectedApp);
                ShowApplicationDetails();
            }


        }

        private void ShowApplicationDetails()
        {
            lblAppID.Visible = true;
            lblID.Visible = true;
            lblCreationDate.Visible = true;
            lblCreationAppDAte.Visible = true;
            lblAppName.Visible = true;
            txtBoxUpdateApp.Visible = true;
            btnUpdate.Visible = true;
            btnContainers.Visible = true;
            btnDelete.Visible = true;
            btnRecords.Visible = true;
            btnNotification.Visible = true;
        }


        private void getApplicationInfo(string applicationName)
        {
            try
            {

                var request = new RestRequest($"{ApiUrl}/{applicationName}", Method.Get);
                request.AddHeader("Accept", "application/xml");
                RestResponse response = client.Execute(request);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var xmlResponse = XDocument.Parse(response.Content);
                    var appElement = xmlResponse.Element("Application");
                    if (appElement != null)
                    {
                        string appId = appElement.Element("id")?.Value;
                        string appName = appElement.Element("name")?.Value;
                        string creationDateTimeRaw = appElement.Element("creation_datetime")?.Value;

                        string formattedDateTime = string.Empty;
                        if (DateTime.TryParse(creationDateTimeRaw, out DateTime creationDateTime))
                        {
                            formattedDateTime = creationDateTime.ToString("HH:mm:ss dd-MM-yyyy");
                        }
                        else
                        {
                            formattedDateTime = "Invalid Date Format";
                        }

                        lblAppID.Text = appId;
                        lblAppName.Text = appName;
                        lblCreationAppDAte.Text = formattedDateTime;
                    }

                }
                else
                {
                    MessageBox.Show($"Error fetching application info: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching application info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormApplication_Load(object sender, EventArgs e)
        {
            LoadApplications();
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            getNotifRecords("notification");
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            getNotifRecords("record");
        }

        private void getNotifRecords(string type)
        {
            string selectedApplication = listBox1.SelectedItem?.ToString();
            string url = $"{ApiUrl}/{selectedApplication}";
            if (string.IsNullOrEmpty(selectedApplication))
            {
                MessageBox.Show("Please select an application to view its records.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var request = new RestRequest(url, Method.Get);
                request.AddHeader(HeaderName, type);
                request.AddHeader("Accept", "application/xml");
                RestResponse response = client.Execute(request);
                if (response == null || response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show($"Error fetching {type}s: {response?.StatusDescription ?? "No response from server"}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var xmlResponse = XDocument.Parse(response.Content);
                if (!xmlResponse.Descendants("name").Any())
                {
                    MessageBox.Show($"There are no {type}s available for this application. Please select a different application.",
                                    $"No {type}s Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                FormNotifRecodsTable formNotifRecodsTable = new FormNotifRecodsTable(selectedApplication, type);
                formNotifRecodsTable.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching {type}s: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
