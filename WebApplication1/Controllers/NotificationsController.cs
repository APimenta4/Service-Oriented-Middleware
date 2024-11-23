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
        readonly string connectionString = WebApplication1.WebApiApplication.connectionString;
        SqlConnection conn = null;

        #region GETs

        [Route("api/somiod/notifications")]
        public IEnumerable<Notification> GetAllNotifications() {

            var notifications = new List<Notification>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT * FROM notifications ORDER BY id", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var notification = new Notification {
                                id = (int)reader["id"],
                                name = (string)reader["name"],
                                creation_datetime = (DateTime)reader["creation_datetime"],
                                parent = (int)reader["parent"],
                                Event = (string)reader["Event"], 
                                endpoint = (string)reader["endpoint"],
                                enabled = (bool)reader["enabled"]
                            };
                            notifications.Add(notification);
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
            return notifications;
        }

        #endregion

    }
}
