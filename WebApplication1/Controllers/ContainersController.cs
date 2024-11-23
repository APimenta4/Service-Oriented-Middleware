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


        [HttpGet]
        [Route("api/somiod/{applicationName}/container/{containerName}")]
        public IHttpActionResult GetContainerByApplicationAndName(string applicationName, string containerName) {
            Container container = null;
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "SELECT c.* FROM containers c " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "AND c.name = @containerName", conn)) {
                        command.Parameters.AddWithValue("@applicationName", applicationName);
                        command.Parameters.AddWithValue("@containerName", containerName);

                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                container = new Container {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    creation_datetime = (DateTime)reader["creation_datetime"],
                                    parent = (int)reader["parent"]
                                };
                            }
                        }
                    }
                }

                if (container == null) {
                    return NotFound(); 
                }

                return Ok(container); 
            }
            catch (Exception) {
                return InternalServerError(); 
            }
        }

        #endregion


    }
}
