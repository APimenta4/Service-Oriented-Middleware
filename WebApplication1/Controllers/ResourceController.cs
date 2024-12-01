using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
    public class ResourceController : ApiController {
        /*
        readonly string connectionString = WebApplication1.WebApiApplication.connectionString;
        SqlConnection conn = null;

        #region GET Resources

        // Get resouces using header "somiod-locate: <resouce>"
        [HttpGet]
        [Route("api/somiod")]
        public IHttpActionResult GetResourcesByHeader() {

            if (!Request.Headers.Contains("somiod-locate")) {
                return Ok("No 'somiod-locate' header found.");
            }

            var headerType = Request.Headers.GetValues("somiod-locate").First();

            switch (headerType) {
                case "application":
                    return GetAllApplicationsNames();
                case "container":
                    return GetAllContainersNames();
                case "record":
                    return GetAllRecordsNames();
                case "notification":
                    return GetAllNotificationsNames();
                default:
                    return Ok("Unsuported resource type.");

            }

        }

        #endregion

        #region POSTs

        [HttpPost]
        [Route("api/somiod")]
        public IHttpActionResult PostApplication(Application newApplication) {
            if (newApplication == null || string.IsNullOrEmpty(newApplication.name)) {
                return BadRequest();
            }

            newApplication.creation_datetime = DateTime.Now;

            try {
                do {
                    using (var connection = new SqlConnection(connectionString)) {
                        connection.Open();

                        try {
                            using (var command = new SqlCommand("INSERT INTO applications (name, creation_datetime) OUTPUT INSERTED.id VALUES (@name, @creation_datetime)", connection)) {
                                command.Parameters.AddWithValue("@name", newApplication.name);
                                command.Parameters.AddWithValue("@creation_datetime", newApplication.creation_datetime);
                                newApplication.id = (int)command.ExecuteScalar();
                                break;
                            }
                        }
                        catch (SqlException e) {
                            if (e.Number == 2627) {
                                using (var countCommand = new SqlCommand("SELECT COUNT(*) FROM applications WHERE name LIKE @name", connection)) {
                                    countCommand.Parameters.AddWithValue("@name", newApplication.name + "%");
                                    int count = (int)countCommand.ExecuteScalar();
                                    newApplication.name = $"{newApplication.name}_{count + 1}";
                                }
                            }
                            else {
                                throw;
                            }
                        }
                    }
                } while (true);
                return Ok(newApplication);
            }
            catch (Exception) {
                return InternalServerError();
            }
        }




        #endregion

        #region Helper methods
        public IHttpActionResult GetAllApplicationsNames() {
            var applicationsNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT name FROM applications ORDER BY name", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            applicationsNames.Add((string)reader["name"]);
                        }
                    }
                }
            }
            catch (Exception) {
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }

            return Ok(applicationsNames);
        }

        public IHttpActionResult GetAllContainersNames() {
            var containersNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT name FROM containers ORDER BY name", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            containersNames.Add((string)reader["name"]);
                        }
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }

            return Ok(containersNames);
        }

        public IHttpActionResult GetAllNotificationsNames() {
            var notificationsNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT name FROM notifications ORDER BY name", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            notificationsNames.Add((string)reader["name"]);
                        }
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }

            return Ok(notificationsNames);
        }

        public IHttpActionResult GetAllRecordsNames() {
            var recordsNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT name FROM records ORDER BY name", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            recordsNames.Add((string)reader["name"]);
                        }
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }

            return Ok(recordsNames);
        }

        #endregion
        */
    }
}
