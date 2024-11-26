using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
    public class ApplicationsController : ApiController {

        readonly string connectionString = WebApplication1.WebApiApplication.connectionString;
        SqlConnection conn = null;


        #region GETs

        [HttpGet]
        [Route("api/somiod/{applicationName}")]
        public IHttpActionResult GetApplication(string applicationName) {

            // Get resouces using header "somiod-locate: <resouce>"
            if (Request.Headers.Contains("somiod-locate")) {
                return GetResourcesByHeader(applicationName);
            }

            Application application = null;
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT * FROM applications WHERE name = @applicationName", conn)) {
                        command.Parameters.AddWithValue("@applicationName", applicationName);

                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                application = new Application {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    creation_datetime = (DateTime)reader["creation_datetime"]
                                };
                            }
                        }
                    }
                }

                if (application == null) {
                    return NotFound();
                }

                return Ok(application);
            }
            catch (Exception) {
                return InternalServerError();
            }
        }


        #endregion

        #region POSTs

        [HttpPost]
        [Route("api/somiod/{applicationName}")]
        public IHttpActionResult PostContainer(string applicationName, Container newContainer) {
            if (newContainer == null || string.IsNullOrEmpty(newContainer.name) || newContainer.parent <= 0) {
                return BadRequest();
            }
            newContainer.creation_datetime = DateTime.Now;
            try {
                using (var connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT name FROM containers WHERE name = @name", connection)) {
                        command.Parameters.AddWithValue("@name", newContainer.name);
                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                newApplication.name = newApplication.name + "_1";  // TODO: improve this
                            }
                        }
                    }
                    using (var command = new SqlCommand("INSERT INTO applications (name, creation_datetime) OUTPUT INSERTED.id VALUES (@name, @creation_datetime)", connection)) {
                        command.Parameters.AddWithValue("@name", newApplication.name);
                        command.Parameters.AddWithValue("@creation_datetime", newApplication.creation_datetime);
                        newApplication.id = (int)command.ExecuteScalar();
                    }
                }

                return Ok(newApplication);
            }
            catch (Exception) {
                return InternalServerError();
            }
        }


        #endregion

        #region DELETEs

        [HttpDelete]
        [Route("api/somiod/{applicationName}")]
        public IHttpActionResult DeleteApplication(string applicationName) {
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "DELETE a FROM applications a " +
                        "WHERE a.name = @applicationName", conn)) {
                        command.Parameters.AddWithValue("@applicationName", applicationName);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0) {
                            return NotFound();
                        }
                    }
                }

                return Ok();
            }
            catch (Exception) {
                return InternalServerError();
            }
        }

        #endregion


        #region Helper methods


        public IHttpActionResult GetResourcesByHeader(string applicationName) {
            var headerType = Request.Headers.GetValues("somiod-locate").First();

            switch (headerType) {
                case "container":
                    return GetAllContainersNames(applicationName);
                case "record":
                    return GetAllRecordsNames(applicationName);
                case "notification":
                    return GetAllNotificationsNames(applicationName);
                default:
                    return Ok("Unsuported resource type.");
            }
        }

        public IHttpActionResult GetAllContainersNames(string applicationName) {
            var containersNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "SELECT c.name FROM containers c " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "ORDER BY c.name", conn)) {

                        command.Parameters.AddWithValue("@applicationName", applicationName);

                        using (var reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                containersNames.Add((string)reader["name"]);
                            }
                        }
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }

            return Ok(containersNames);
        }

        public IHttpActionResult GetAllNotificationsNames(string applicationName) {
            var notificationsNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "SELECT n.name FROM notifications n " +
                        "JOIN containers c ON n.parent = c.id " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "ORDER BY n.name", conn)) {

                        command.Parameters.AddWithValue("@applicationName", applicationName);

                        using (var reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                notificationsNames.Add((string)reader["name"]);
                            }
                        }
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }

            return Ok(notificationsNames);
        }

        public IHttpActionResult GetAllRecordsNames(string applicationName) {
            var recordsNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "SELECT r.name FROM records r " +
                        "JOIN containers c ON r.parent = c.id " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "ORDER BY r.name", conn)) {

                        command.Parameters.AddWithValue("@applicationName", applicationName);

                        using (var reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                recordsNames.Add((string)reader["name"]);
                            }
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



    }
}
