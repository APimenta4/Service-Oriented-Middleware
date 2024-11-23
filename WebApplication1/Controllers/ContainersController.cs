using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContainersController : ApiController
    {
        readonly string connectionString = WebApplication1.WebApiApplication.connectionString;
        SqlConnection conn = null;

        #region GETs

        [Route("api/somiod/containers")]
        public IEnumerable<Container> GetAllContainers() {

            var containers = new List<Container>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT * FROM containers ORDER BY ID", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var container = new Container {
                                id = (int)reader["id"],
                                name = (string)reader["name"],
                                creation_datetime = (DateTime)reader["creation_datetime"],
                                parent = (int)reader["parent"]
                            };
                            containers.Add(container);
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
            return containers;
        }

        #endregion

    }
}
