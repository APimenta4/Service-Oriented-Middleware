using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers {

    [RoutePrefix("api/somiod")]

    public class SomiodController : ApiController {
        readonly string connectionString = WebApplication1.WebApiApplication.connectionString;
        SqlConnection conn = null;

        #region -- Notas --

        // Os métodos POST e Locate (<somiod-locate>, que no fundo é um GET com um header adicional) devem apontar para a "parent resource"
        // Os métodos GET, PUT e DELETE devem apontar para a "child resource"

        // Quando se apaga algum recurso, a BD imediatamente apaga todos os recursos filhos

        // Nomes alternativos gerados automaticamente (quando o utilizador tenta criar um recurso com um nome já existente no seu contexto)
        // são gerados quando se tenta fazer um POST e a BD devolve o erro 2627
        // Exemplos:
        // Não podem existir aplicações com nomes iguais de todo
        // Podem existir containers com nomes iguais, desde que pertençam a aplicações diferentes
        // Podem existir records/notifications com nomes iguais, desde que pertençam a containers diferentes

        // Records e notifications não devem suportar PUT

        // Segundo o stor, quando se envia pedidos XML, tem-se que mandar os campos todos (mesmo que usemos id's e creation_datetime internos (??)
        // Não percebo o fim disto, mas foi o que ele disse

        // Como temos o RoutePrefix("api/somiod"), não é necessário colocar "api/somiod" em cada Route

        // O url para notifications é /notif

        #endregion 

        #region Application

        [HttpGet]
        [Route("{applicationName}")]
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


        // POST

        [HttpPost]
        [Route()]
        public IHttpActionResult PostApplication(Application newApplication) {
            if (newApplication == null || string.IsNullOrEmpty(newApplication.name)) {
                return BadRequest();
            }

            newApplication.creation_datetime = DateTime.Now;

            try {
                do {
                    using (var connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        // tenta inserir na BD uma nova aplicação
                        try {
                            using (var command = new SqlCommand("INSERT INTO applications (name, creation_datetime) OUTPUT INSERTED.id VALUES (@name, @creation_datetime)", connection)) {
                                command.Parameters.AddWithValue("@name", newApplication.name);
                                command.Parameters.AddWithValue("@creation_datetime", newApplication.creation_datetime);
                                newApplication.id = (int)command.ExecuteScalar();
                                break;
                            }
                        }
                        // caso apanhe a exceção 2627 (violar unique constraint), adiciona um identificador único (neste caso, _X) com base no número de aplicações com o nome semelhante (select count(*))
                        // pode haver uma maneira mais "limpa" de fazer isto, mas o professor da Isa disse que bastava
                        catch (SqlException e) {
                            if (e.Number == 2627) {
                                using (var countCommand = new SqlCommand("SELECT COUNT(*) FROM applications WHERE name LIKE @name", connection)) {
                                    countCommand.Parameters.AddWithValue("@name", newApplication.name + "%");
                                    int count = (int)countCommand.ExecuteScalar();
                                    newApplication.name = $"{newApplication.name}_{count + 1}";
                                }
                            }
                            else {
                                throw; // para outros erros de sql, manda uma exception normal que depois é apanhada algumas linhas abaixo e é enviado um InternalServerError
                            }
                        }
                    }
                } while (true);
                return Ok(newApplication); // aqui apesar de ser um POST, acho que faz sentido devolver a resource criada ao utilizador porque pode acabar por ter um nome diferente do que ele escolheu
            }
            catch (Exception) {
                return InternalServerError();
            }
        }

        // PUT



        // DELETE

        [HttpDelete]
        [Route("{applicationName}")]
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

        #region Container

        // GET

        [HttpGet]
        [Route("{applicationName}/container/{containerName}")]
        public IHttpActionResult GetContainerByApplication(string applicationName, string containerName) {

            // Get resouces using header "somiod-locate: <resouce>"
            if (Request.Headers.Contains("somiod-locate")) {
                return GetResourcesByHeader(applicationName, containerName);
            }

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

        // POST
        // TODO
        // INCOMPLETO, COPIEI DO POSTAPPLICATION E COMECEI A MUDAR

        [HttpPost]
        [Route("{applicationName}")]
        public IHttpActionResult PostContainer(string applicationName, Container newContainer) {
            if (newContainer == null || string.IsNullOrEmpty(newContainer.name) || newContainer.parent <= 0) {
                return BadRequest();
            }
            newContainer.creation_datetime = DateTime.Now;

            try {
                do {
                    using (var connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        try {
                            using (var command = new SqlCommand("INSERT INTO containers (name, creation_datetime, parent) OUTPUT INSERTED.id VALUES (@name, @creation_datetime, @parent)", connection)) {
                                command.Parameters.AddWithValue("@name", newContainer.name);
                                command.Parameters.AddWithValue("@creation_datetime", newContainer.creation_datetime);
                                command.Parameters.AddWithValue("@parent", newContainer.parent);
                                newContainer.id = (int)command.ExecuteScalar();
                                break;
                            }
                        }
                        catch (SqlException e) {
                            if (e.Number == 2627) {
                                using (var countCommand = new SqlCommand("SELECT COUNT(*) FROM containers WHERE name LIKE @name", connection)) {
                                    countCommand.Parameters.AddWithValue("@name", newContainer.name + "%");
                                    int count = (int)countCommand.ExecuteScalar();
                                    newContainer.name = $"{newContainer.name}_{count + 1}";
                                }
                            }
                            else {
                                throw;
                            }
                        }
                    }
                } while (true);

                return Ok(newContainer);
            }
            catch (Exception) {
                return InternalServerError();
            }
        }

        // PUT

        // DELETE

        [HttpDelete]
        [Route("{applicationName}/container/{containerName}")]
        public IHttpActionResult DeleteContainerByApplication(string applicationName, string containerName) {
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "DELETE c FROM containers c " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "AND c.name = @containerName ", conn)) {
                        command.Parameters.AddWithValue("@applicationName", applicationName);
                        command.Parameters.AddWithValue("@containerName", containerName);

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

        #region Record

        // GET

        [HttpGet]
        [Route("{applicationName}/{containerName}/record/{recordName}")]
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

        // POST

        // DELETE

        [HttpDelete]
        [Route("{applicationName}/{containerName}/record/{recordName}")]
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

        #region Notification

        // GET

        [HttpGet]
        [Route("{applicationName}/{containerName}/notif/{notificationName}")]
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

        // POST

        // DELETE

        [HttpDelete]
        [Route("{applicationName}/{containerName}/notif/{notificationName}")]
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

        #region <somiod-locate> operations

        // Locate on base url (/api/somiod)
        [HttpGet]
        [Route()]
        public IHttpActionResult GetResourcesByHeader() {

            if (!Request.Headers.Contains("somiod-locate")) {
                return Ok("No 'somiod-locate' header found.");
            }

            var headerType = Request.Headers.GetValues("somiod-locate").First();

            switch (headerType) {
                case "application":
                    return GetAllApplicationsNames();
                case "container":
                    return GetAllContainersNames();
                case "record":
                    return GetAllRecordsNames();
                case "notification":
                    return GetAllNotificationsNames();
                default:
                    return Ok("Unsuported resource type.");

            }

        }


        #region <somiod-locate> Helper methods (Base url)
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

        public IHttpActionResult GetAllContainersNames() {
            var containersNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT name FROM containers ORDER BY name", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            containersNames.Add((string)reader["name"]);
                        }
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }

            return Ok(containersNames);
        }

        public IHttpActionResult GetAllNotificationsNames() {
            var notificationsNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT name FROM notifications ORDER BY name", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            notificationsNames.Add((string)reader["name"]);
                        }
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }

            return Ok(notificationsNames);
        }

        public IHttpActionResult GetAllRecordsNames() {
            var recordsNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT name FROM records ORDER BY name", conn))
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            recordsNames.Add((string)reader["name"]);
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

        #region <somiod-locate> Helper methods (Application)

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

        #region <somiod-locate> Helper methods (Container)
        public IHttpActionResult GetResourcesByHeader(string applicationName, string containerName) {
            var headerType = Request.Headers.GetValues("somiod-locate").First();

            switch (headerType) {
                case "record":
                    return GetAllRecordsNames(applicationName, containerName);
                case "notification":
                    return GetAllNotificationsNames(applicationName, containerName);
                default:
                    return Ok("Unsuported resource type.");
            }
        }

        public IHttpActionResult GetAllNotificationsNames(string applicationName, string containerName) {
            var notificationsNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "SELECT n.name FROM notifications n " +
                        "JOIN containers c ON n.parent = c.id " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "AND c.name = @containerName " +
                        "ORDER BY n.name", conn)) {

                        command.Parameters.AddWithValue("@applicationName", applicationName);
                        command.Parameters.AddWithValue("@containerName", containerName);

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

        public IHttpActionResult GetAllRecordsNames(string applicationName, string containerName) {
            var recordsNames = new List<string>();
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand(
                        "SELECT r.name FROM records r " +
                        "JOIN containers c ON r.parent = c.id " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "AND c.name = @containerName " +
                        "ORDER BY r.name", conn)) {

                        command.Parameters.AddWithValue("@applicationName", applicationName);
                        command.Parameters.AddWithValue("@containerName", containerName);

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

        #endregion


    }
}
