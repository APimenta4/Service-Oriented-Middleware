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


        [Route("api/somiod/applications")]
        public IEnumerable<Application> GetAllApplications() {

            var applications = new List<Application>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT * FROM applications ORDER BY ID", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var app = new Application {
                                id = (int)reader["id"],
                                name = (string)reader["name"],
                                creation_datetime = (DateTime)reader["creation_datetime"]
                            };
                            applications.Add(app);
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
            return applications;
        }


        #endregion

    }
}
