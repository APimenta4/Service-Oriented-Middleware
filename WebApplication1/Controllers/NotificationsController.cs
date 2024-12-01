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
    public class NotificationsController : ApiController
    {
        /*
        readonly string connectionString = WebApplication1.WebApiApplication.connectionString;
        SqlConnection conn = null;

        #region GETs
        [HttpGet]
        [Route("api/somiod/{applicationName}/{containerName}/notif/{notificationName}")]
        public IHttpActionResult GetNotificationByApplicationContainer(string applicationName, string containerName, string notificationName) {
            Notification notification = null;
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "SELECT n.* FROM notifications n " +
                        "JOIN containers c ON n.parent = c.id " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "AND c.name = @containerName " +
                        "AND n.name = @notificationName", conn)) {
                        command.Parameters.AddWithValue("@applicationName", applicationName);
                        command.Parameters.AddWithValue("@containerName", containerName);
                        command.Parameters.AddWithValue("@notificationName", notificationName);

                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                notification = new Notification {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    creation_datetime = (DateTime)reader["creation_datetime"],
                                    parent = (int)reader["parent"],
                                    @event = (string)reader["event"],
                                    endpoint = (string)reader["endpoint"],
                                    enabled = (bool)reader["enabled"]
                                };
                            }
                        }
                    }
                }

                if (notification == null) {
                    return NotFound(); 
                }

                return Ok(notification); 
            }
            catch (Exception) {
                return InternalServerError(); 
            }
        }


        #endregion

        #region DELETEs

        [HttpDelete]
        [Route("api/somiod/{applicationName}/{containerName}/notif/{notificationName}")]
        public IHttpActionResult DeleteNotificationByApplicationContainer(string applicationName, string containerName, string notificationName) {
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "DELETE n FROM notifications n " +
                        "JOIN containers c ON n.parent = c.id " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "AND c.name = @containerName " +
                        "AND n.name = @notificationName", conn)) {
                        command.Parameters.AddWithValue("@applicationName", applicationName);
                        command.Parameters.AddWithValue("@containerName", containerName);
                        command.Parameters.AddWithValue("@notificationName", notificationName);

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
        */
    }
}
