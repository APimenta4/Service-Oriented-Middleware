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
    public partial class FormContainer : Form
    {
        private const string ApiUrl = "http://localhost:52653/api/somiod/";
        private const string HeaderName = "somiod-locate";
        RestClient client = null;


        private string applicationName;
        private string appUrl;
        public FormContainer(string appName)
        {
            InitializeComponent();
            applicationName = appName;
            appUrl = ApiUrl + appName;
            client = new RestClient();

        }

        private void FormContainer_Load(object sender, EventArgs e)
        {
            lblApplicationName.Text = applicationName;
            LoadContainers();
        }

        private void LoadContainers()
        {
            try
            {
                var request = new RestRequest(appUrl, Method.Get);
                request.AddHeader(HeaderName, "container");
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
                    MessageBox.Show($"Error fetching data: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading containers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedContainer = listBox1.SelectedItem.ToString();
                GetContainerInfo(selectedContainer);
                ShowContainerDetails();
            }
        }

        private void ShowContainerDetails()
        {
            groupBox2.Visible = true;
            btnDelete.Visible = true;
            btnRecords.Visible = true;
            btnNotification.Visible = true;


        }

        private void btnCreateContainer_Click(object sender, EventArgs e)
        {
            string containerName = txtBoxCreateContainer.Text;
            if (string.IsNullOrEmpty(containerName))
            {
                MessageBox.Show("Please enter a container name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                XDocument xmlData = new XDocument(
                    new XElement("Container",
                        new XElement("name", containerName)
                    )
                );

                var request = new RestRequest(appUrl, Method.Post);
                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("Accept", "application/xml");
                request.AddParameter("application/xml", xmlData.ToString(), ParameterType.RequestBody);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show($"Container '{containerName}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadContainers();
                }
                else
                {
                    MessageBox.Show($"Error creating container: {response.Content}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating container: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void GetContainerInfo(string containerName)
        {
            try
            {
                var request = new RestRequest($"{appUrl}/{containerName}", Method.Get);
                request.AddHeader("Accept", "application/xml");
                RestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var xmlResponse = XDocument.Parse(response.Content);
                    var containerElement = xmlResponse.Element("Container");
                    if (containerElement != null)
                    {
                        string contId = containerElement.Element("id")?.Value;
                        string appName = containerElement.Element("name")?.Value;
                        string creationDateTimeRaw = containerElement.Element("creation_datetime")?.Value;

                        string formattedDateTime = string.Empty;
                        if (DateTime.TryParse(creationDateTimeRaw, out DateTime creationDateTime))
                        {
                            formattedDateTime = creationDateTime.ToString("HH:mm:ss dd-MM-yyyy");
                        }
                        else
                        {
                            formattedDateTime = "Invalid Date Format";
                        }

                        lblContID.Text = contId;
                        lblContName.Text = appName;
                        lblCreationContDate.Text = formattedDateTime;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string selectedContainer = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedContainer))
            {
                MessageBox.Show("Please select a container to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string newContainerName = txtBoxUpdate.Text;
            if (string.IsNullOrEmpty(newContainerName))
            {
                MessageBox.Show("Please enter a new container name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                XDocument xmlData = new XDocument(
                                       new XElement("Container",
                                                              new XElement("name", newContainerName)
                                                                                 )
                                                      );

                var request = new RestRequest($"{appUrl}/{selectedContainer}", Method.Put);
                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("Accept", "application/xml");
                request.AddParameter("application/xml", xmlData.ToString(), ParameterType.RequestBody);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show($"Container '{selectedContainer}' updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadContainers();
                }
                else
                {
                    MessageBox.Show($"Error updating container: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }catch(Exception ex)
            {
                MessageBox.Show($"Error updating container: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedContainer = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedContainer))
            {
                MessageBox.Show("Please select a container to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var request = new RestRequest($"{appUrl}/{selectedContainer}", Method.Delete);
                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("Accept", "application/xml");
                request.AddHeader(HeaderName, "container");

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    MessageBox.Show($"Container '{selectedContainer}' deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadContainers();
                }
                else
                {
                    MessageBox.Show($"Error deleting container: {response.StatusDescription}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting container: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            string selectedContainer = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedContainer))
            {
                MessageBox.Show("Please select a container to view records.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormRecords formRecords = new FormRecords(applicationName, selectedContainer);
            formRecords.ShowDialog();

        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            
            string selectedContainer = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedContainer))
            {
                MessageBox.Show("Please select a container to view notifications.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormNotifications formNotifications = new FormNotifications(applicationName, selectedContainer);
            formNotifications.ShowDialog();
        }
    }
}
