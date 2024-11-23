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
    public class RecordsController : ApiController
    {
        readonly string connectionString = WebApplication1.WebApiApplication.connectionString;
        SqlConnection conn = null;

        #region GETs

        [Route("api/somiod/records")]
        public IEnumerable<Record> GetAllRecords() {

            var records = new List<Record>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT * FROM records ORDER BY id", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var record = new Record {
                                id = (int)reader["id"],
                                name = (string)reader["name"],
                                content = (string)reader["content"],
                                creation_datetime = (DateTime)reader["creation_datetime"],
                                parent = (int)reader["parent"]
                            };
                            records.Add(record);
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
            return records;
        }

        #endregion


    }

}
