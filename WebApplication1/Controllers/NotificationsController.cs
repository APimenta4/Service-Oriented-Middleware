using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class NotificationsController : ApiController
    {
        readonly string connectionString = WebApplication1.WebApiApplication.connectionString;
        SqlConnection conn = null;
    }
}
