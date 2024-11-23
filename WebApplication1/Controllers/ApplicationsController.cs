﻿using System;
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


        // Get resouces using header "somiod-locate: <resouce>"
        [HttpGet]
        [Route("api/somiod")]
        public IHttpActionResult GetResourcesByHeader() {

            if (!Request.Headers.Contains("somiod-locate")) {
                return Ok("No 'somiod-locate' header found.");
            }

            var headerType = Request.Headers.GetValues("somiod-locate").First();

            switch (headerType) {
                case "applications":
                    return GetAllApplicationsNames();
                case "containers":
                    ContainersController ContainersController = new ContainersController();
                    return ContainersController.GetAllContainersNames();
                case "records":
                    RecordsController RecordsController = new RecordsController();
                    return RecordsController.GetAllRecordsNames();
                case "notifications":
                    NotificationsController NotificationsController = new NotificationsController();
                    return NotificationsController.GetAllNotificationsNames();
                default:
                    throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);

            }

        }


        #region GETs

        [HttpGet]
        [Route("api/somiod/{applicationName}")]
        public IHttpActionResult GetApplication(string applicationName) {
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

        #endregion





    }
}
