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
using Newtonsoft.Json.Linq;

namespace Test_Application
{
    public partial class FormApplication : Form
    {
        private const string ApiUrl = "http://localhost:52653/api/somiod";
        private const string HeaderName = "somiod-locate";
        RestClient client = null;
        List<Applications> apps = null;
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
                apps = new List<Applications>();
                var request = new RestRequest(ApiUrl, Method.Get);


                request.AddHeader(HeaderName, "application");

                RestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = JObject.Parse(response.Content);
                    listBox1.Items.Clear();
                    foreach (string appName in jsonResponse["applications"]["name"])
                    {
                        listBox1.Items.Add(appName);
                        apps.Add(new Applications { Name = appName });
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
                request.AddHeader(HeaderName, "application"); // DONT THIS HERE IS NECESSARY
                request.RequestFormat = DataFormat.Xml;
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

                request.AddHeader(HeaderName, "application");
                request.RequestFormat = DataFormat.Json;

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
                request.AddHeader(HeaderName, "application");
                request.RequestFormat = DataFormat.Xml;
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
            // Open a new form to display the containers
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedApp = listBox1.SelectedItem.ToString();
            Applications app = FindAppByName(selectedApp);
            lblAppName.Text = app.Name;


            lblAppName.Visible = true;
            txtBoxUpdateApp.Visible = true
            btnUpdate.Visible = true;
            btnContainers.Enabled = true;
            btnDelete.Enabled = true;

        }

        private Applications FindAppByName(string selectedApp)
        {
            foreach (Applications app in apps)
            {
                if (app.Name == selectedApp)
                {
                    return app;
                }
            }
            return null;
        }
    }
}