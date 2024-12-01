﻿using System;
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
        /*
        readonly string connectionString = WebApplication1.WebApiApplication.connectionString;
        SqlConnection conn = null;

        #region GETs


        [HttpGet]
        [Route("api/somiod/{applicationName}/{containerName}/record/{recordName}")]
        public IHttpActionResult GetRecordByApplicationContainer(string applicationName, string containerName, string recordName) {
            Record record = null;
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "SELECT r.* FROM records r " +
                        "JOIN containers c ON r.parent = c.id " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "AND c.name = @containerName " +
                        "AND r.name = @recordName", conn)) {
                        command.Parameters.AddWithValue("@applicationName", applicationName);
                        command.Parameters.AddWithValue("@containerName", containerName);
                        command.Parameters.AddWithValue("@recordName", recordName);

                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                record = new Record {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    content = (string)reader["content"],
                                    creation_datetime = (DateTime)reader["creation_datetime"],
                                    parent = (int)reader["parent"]
                                };
                            }
                        }
                    }
                }

                if (record == null) {
                    return NotFound(); 
                }

                return Ok(record);
            }
            catch (Exception) {
                return InternalServerError(); 
            }
        }


        #endregion

        #region DELETEs

        [HttpDelete]
        [Route("api/somiod/{applicationName}/{containerName}/record/{recordName}")]
        public IHttpActionResult DeleteRecordByApplicationContainer(string applicationName, string containerName, string recordName) {
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "DELETE r FROM records r " +
                        "JOIN containers c ON r.parent = c.id " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "AND c.name = @containerName " +
                        "AND r.name = @recordName", conn)) {
                        command.Parameters.AddWithValue("@applicationName", applicationName);
                        command.Parameters.AddWithValue("@containerName", containerName);
                        command.Parameters.AddWithValue("@recordName", recordName);

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
