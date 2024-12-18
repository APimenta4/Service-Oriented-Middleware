using API.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using WebApplication1.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Controllers {

    [RoutePrefix("api/somiod")]

    public class SomiodController : ApiController {
        readonly string connectionString = WebApplication1.WebApiApplication.connectionString;
        SqlConnection conn = null;

        #region -- Notas --

        // Os métodos POST e Locate (<somiod-locate>, que no fundo é um GET com um header adicional) devem apontar para a "parent resource"
        // Os métodos GET, PUT e DELETE devem apontar para a própria resource

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

        // Para POSTs e PUTs dentro de um container deve ser mandado um res-type a dizer se é record ou notification
        // Ouvi outro grupo a falar com o professor e a dizer que também se pode ver se é um ou outro pelo XML e XSD, ele disse que "podia valorizar"

        // A professora disse que o name devia ser único no seu contexto, o professor disse que devia ser globamente único
        // Ele disse que podia ser assim porque nas operações de discover podem aparecer nomes iguais
        // Atualmente está implementado como a professora disse,
        // ou deixamos estar e justificamos no relatório
        // ou fazemos como o professor quer
        // Acho que faz mais sentido deixar

        // O professor disse que podíamos fazer extras
        // Como por exemplo o UPDATE notifications, que no enunciado está incompleto
        // No enunciado diz que não se pode dar update às notifications, mas elas têm de ter um campo "enabled"
        // Eu nas notificações já faço a validação se a notificação está "enabled", por isso é só mesmo fazer o método PUT

        #endregion

        #region Funcões Auxiliares

        /// <summary>
        /// Validates an XML document against an XSD schema file.
        /// </summary>
        /// <param name="xml">The XML document to validate.</param>
        /// <param name="xsdPath">The file path to the XSD schema.</param>
        /// <returns>True if the XML document is valid; otherwise, false.</returns>
        /// <exception cref="FileNotFoundException">Thrown if the XSD file is not found at the specified path.</exception>
        /// <exception cref="IOException">Thrown if there is an issue reading the XSD file.</exception>
        /// <exception cref="XmlSchemaValidationException">Thrown if the XML document fails schema validation.</exception>
        /// <exception cref="XmlException">Thrown if the XML schema or document is invalid.</exception>
        public bool ValidateXmlAgainstSchema(XmlDocument xml, string xsdPath) {
            string xsd;
            using (var reader = new StreamReader(xsdPath)) {
                xsd = reader.ReadToEnd();
            }
            try {
                var schemaSet = new XmlSchemaSet();
                schemaSet.Add(null, XmlReader.Create(new StringReader(xsd)));
                xml.Schemas = schemaSet;
                xml.Validate((sender, e) => {
                    throw new XmlSchemaValidationException(e.Message);
                });
                return true;
            }
            catch (XmlSchemaValidationException) {
                return false;
            }
        }

        /// <summary>
        /// Generates a unique name by appending a timestamp to the base name.
        /// </summary>
        /// <param name="baseName">The base name to which the timestamp will be appended.</param>
        /// <returns>A string combining the base name and the current timestamp in the format 'yyyyMMdd_HHmmss'.
        /// For example: If <paramref name="baseName"/> is "model", the result will be "model_20240617_103045".
        /// </returns>
        private string GenerateTimestampName(string baseName) {
            DateTime timestamp = DateTime.Now;
            return $"{baseName}_{timestamp:yyyyMMdd_HHmmss}";
        }

        #endregion

        #region Application

        [HttpGet]
        [Route("{applicationName}")]
        public IHttpActionResult GetApplication(string applicationName) {

            // Get resouces using header "somiod-locate: <resouce>"
            if (Request.Headers.Contains("somiod-locate")) {
                return GetResourcesByHeader(applicationName);
            }

            Models.Application application = null;
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (var command = new SqlCommand("SELECT * FROM applications WHERE name = @applicationName", conn)) {
                        command.Parameters.AddWithValue("@applicationName", applicationName);

                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                application = new Models.Application {
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


        [HttpPost]
        [Route()]
        public IHttpActionResult PostApplication([FromBody] XmlDocument xmlData) {
            try {
                // applicationName com o paramentro do url e o xmlData com o body que esta a ser enviado(onde mandamos o novo modelo)
                if (xmlData == null) {
                    return BadRequest("Invalid application data.");
                }

                // Validas o XML enviado no body com o XSD
                string xsdPath = HttpContext.Current.Server.MapPath("~/App_Data/ApplicationSchema.xsd");
                if (!ValidateXmlAgainstSchema(xmlData, xsdPath)) {
                    return BadRequest("Invalid XML data format.");
                }

                // passas o XML para o modelo Application
                Models.Application newApplication;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.Application));
                using (var xmlNodeReader = new XmlNodeReader(xmlData.DocumentElement)) {
                    newApplication = (Models.Application)xmlSerializer.Deserialize(xmlNodeReader);
                }

                // Acrecentas os valores que o sistema coloca
                newApplication.creation_datetime = DateTime.Now;

                using (var connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    // tenta inserir na BD uma nova aplicação
                    try {
                        return CreateApplication(newApplication, connection);
                    }

                    catch (SqlException e) when (e.Number == 2627) {
                        // Add timestamp in model name 
                        newApplication.name = GenerateTimestampName(newApplication.name);
                        return CreateApplication(newApplication, connection);
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }
        }

        private IHttpActionResult CreateApplication(Models.Application newApplication, SqlConnection conn) {
            string sqlQuery = @"
                INSERT INTO applications (name, creation_datetime) OUTPUT INSERTED.id 
                VALUES (@name, @creation_datetime)";

            using (var command = new SqlCommand(sqlQuery, conn)) {
                command.Parameters.AddWithValue("@name", newApplication.name);
                command.Parameters.AddWithValue("@creation_datetime", newApplication.creation_datetime);
                newApplication.id = (int)command.ExecuteScalar();

            }
            return Created("", newApplication);
        }

        [HttpPut]
        [Route("{applicationName}")]
        public IHttpActionResult PutApplication(string applicationName, [FromBody] XmlDocument xmlData) {
            try {
                if (xmlData == null) {
                    return BadRequest("Invalid application data.");
                }

                // Validate the XML data against the XSD schema
                string xsdPath = HttpContext.Current.Server.MapPath("~/App_Data/ApplicationSchema.xsd");
                if (!ValidateXmlAgainstSchema(xmlData, xsdPath)) {
                    return BadRequest("Invalid XML data format.");
                }

                // Deserialize XML data to model
                Models.Application updatedApplication;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.Application));
                using (var xmlNodeReader = new XmlNodeReader(xmlData.DocumentElement)) {
                    updatedApplication = (Models.Application)xmlSerializer.Deserialize(xmlNodeReader);
                }

                // Update model
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    try {
                        return UpdateApplication(applicationName, updatedApplication, conn);
                    }
                    catch (SqlException e) when (e.Number == 2627) {
                        // Add timestamp in model name 
                        updatedApplication.name = GenerateTimestampName(updatedApplication.name);
                        return UpdateApplication(applicationName, updatedApplication, conn);
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }
        }

        private IHttpActionResult UpdateApplication(string applicationName, Models.Application updatedApplication, SqlConnection conn) {
            string sqlQuery = @"
                UPDATE applications 
                SET name = @newName
                OUTPUT INSERTED.id, INSERTED.name, INSERTED.creation_datetime
                WHERE name = @applicationName";

            using (var updateCommand = new SqlCommand(sqlQuery, conn)) {
                updateCommand.Parameters.AddWithValue("@newName", updatedApplication.name);
                updateCommand.Parameters.AddWithValue("@applicationName", applicationName);
                using (var reader = updateCommand.ExecuteReader()) {
                    if (reader.Read()) {
                        updatedApplication.id = (int)reader["id"];
                        updatedApplication.name = (string)reader["name"];
                        updatedApplication.creation_datetime = (DateTime)reader["creation_datetime"];
                    }
                    else {
                        return NotFound();
                    }
                }
            }
            return Ok(updatedApplication);
        }


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
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception) {
                return InternalServerError();
            }
        }

        #endregion

        #region Container

        [HttpGet]
        [Route("{applicationName}/{containerName}")]
        public IHttpActionResult GetContainer(string applicationName, string containerName) {

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


        [HttpPost]
        [Route("{applicationName}")]
        public IHttpActionResult PostContainer(string applicationName, [FromBody] XmlDocument xmlData) {
            try {
                // containerName com o paramentro do url e o xmlData com o body que esta a ser enviado(onde mandamos o novo modelo)
                if (xmlData == null) {
                    return BadRequest("Invalid application data.");
                }

                // Validas o XML enviado no body com o XSD
                string xsdPath = HttpContext.Current.Server.MapPath("~/App_Data/ContainerSchema.xsd");
                if (!ValidateXmlAgainstSchema(xmlData, xsdPath)) {
                    return BadRequest("Invalid XML data format.");
                }

                // passas o XML para o modelo Container
                Models.Container newContainer;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.Container));
                using (var xmlNodeReader = new XmlNodeReader(xmlData.DocumentElement)) {
                    newContainer = (Models.Container)xmlSerializer.Deserialize(xmlNodeReader);
                }

                // Acrecentas os valores que o sistema coloca
                newContainer.creation_datetime = DateTime.Now;

                using (var connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    // tenta inserir na BD uma nova aplicação
                    try {
                        return CreateContainer(applicationName, newContainer, connection);
                    }

                    catch (SqlException e) when (e.Number == 2627) {
                        // Add timestamp in model name 
                        newContainer.name = GenerateTimestampName(newContainer.name);
                        return CreateContainer(applicationName, newContainer, connection);
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }
        }


        private IHttpActionResult CreateContainer(string applicationName, Container newContainer, SqlConnection conn) {
            string getApplicationIdQuery = "SELECT id FROM applications WHERE name = @applicationName";
            int applicationId;
            using (var getCommand = new SqlCommand(getApplicationIdQuery, conn)) {
                getCommand.Parameters.AddWithValue("@applicationName", applicationName);
                object result = getCommand.ExecuteScalar();
                if (result == null) {
                    return NotFound(); // Return 404 if the application name is not found
                }
                applicationId = (int)result;
            }

            // Set the application ID as the parent of the new container
            newContainer.parent = applicationId;

            // Query to insert the new container
            string sqlQuery = @"INSERT INTO containers (name, creation_datetime, parent) OUTPUT INSERTED.id 
                        VALUES (@name, @creation_datetime, @parent)";

            using (var command = new SqlCommand(sqlQuery, conn)) {
                command.Parameters.AddWithValue("@name", newContainer.name);
                command.Parameters.AddWithValue("@creation_datetime", newContainer.creation_datetime);
                command.Parameters.AddWithValue("@parent", newContainer.parent);
                newContainer.id = (int)command.ExecuteScalar();
            }

            return Created("", newContainer);
        }


        [HttpPut]
        [Route("{applicationName}/{containerName}")]
        public IHttpActionResult PutContainer(string applicationName, string containerName, [FromBody] XmlDocument xmlData) {
            try {
                if (xmlData == null) {
                    return BadRequest("Invalid container data.");
                }

                // Validate the XML data against the XSD schema
                string xsdPath = HttpContext.Current.Server.MapPath("~/App_Data/ContainerSchema.xsd");
                if (!ValidateXmlAgainstSchema(xmlData, xsdPath)) {
                    return BadRequest("Invalid XML data format.");
                }

                // Deserialize XML data to model
                Container updatedContainer;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Container));
                using (var xmlNodeReader = new XmlNodeReader(xmlData.DocumentElement)) {
                    updatedContainer = (Container)xmlSerializer.Deserialize(xmlNodeReader);
                }

                // Update model
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    try {
                        return UpdateContainer(applicationName, containerName, updatedContainer, conn);
                    }
                    catch (SqlException e) when (e.Number == 2627) {
                        // Add timestamp in model name 
                        updatedContainer.name = GenerateTimestampName(updatedContainer.name);
                        return UpdateContainer(applicationName, containerName, updatedContainer, conn);
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }
        }

        private IHttpActionResult UpdateContainer(string applicationName, string containerName, Container updatedContainer, SqlConnection conn) {
            string sqlQuery = @"
                UPDATE containers
                SET name = @newName
                OUTPUT INSERTED.id, INSERTED.name, INSERTED.creation_datetime, INSERTED.parent
                FROM containers c
                JOIN applications a ON c.parent = a.id
                WHERE c.name = @containerName
                AND a.name = @applicationName";

            using (var updateCommand = new SqlCommand(sqlQuery, conn)) {
                updateCommand.Parameters.AddWithValue("@newName", updatedContainer.name);
                updateCommand.Parameters.AddWithValue("@containerName", containerName);
                updateCommand.Parameters.AddWithValue("@applicationName", applicationName);

                using (var reader = updateCommand.ExecuteReader()) {
                    if (reader.Read()) {
                        updatedContainer.id = (int)reader["id"];
                        updatedContainer.name = (string)reader["name"];
                        updatedContainer.creation_datetime = (DateTime)reader["creation_datetime"];
                        updatedContainer.parent = (int)reader["parent"];
                    }
                    else {
                        return NotFound();
                    }
                }
            }
            return Ok(updatedContainer);
        }

        [HttpDelete]
        [Route("{applicationName}/{containerName}")]
        public IHttpActionResult DeleteContainer(string applicationName, string containerName) {
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
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception) {
                return InternalServerError();
            }
        }

        #endregion

        #region Record

        [HttpGet]
        [Route("{applicationName}/{containerName}/record/{recordName}")]
        public IHttpActionResult GetRecord(string applicationName, string containerName, string recordName) {
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

        // Handles both notifications and records

        [HttpPost]
        [Route("{applicationName}/{containerName}")]
        public IHttpActionResult PostData(string applicationName, string containerName, [FromBody] XmlDocument xmlData) {
            try {
                if (xmlData == null) {
                    return BadRequest("Invalid application data.");
                }

                // Determine the appropriate schema and model based on the XML content
                string notificationXsdPath = HttpContext.Current.Server.MapPath("~/App_Data/NotificationSchema.xsd");
                string recordXsdPath = HttpContext.Current.Server.MapPath("~/App_Data/RecordSchema.xsd");

                if (ValidateXmlAgainstSchema(xmlData, recordXsdPath))
                {
                    return HandleRecord(applicationName, containerName, xmlData);
                }
                else if (ValidateXmlAgainstSchema(xmlData, notificationXsdPath))
                {
                    return HandleNotification(applicationName, containerName, xmlData);
                }
                else {
                    return BadRequest("Invalid XML data format.");
                }
            }
            catch (Exception) {
                return InternalServerError();
            }
        }

        private IHttpActionResult HandleRecord(string applicationName, string containerName, XmlDocument xmlData) {
            try {
                Models.Record newRecord;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.Record));
                using (var xmlNodeReader = new XmlNodeReader(xmlData.DocumentElement)) {
                    newRecord = (Models.Record)xmlSerializer.Deserialize(xmlNodeReader);
                }

                newRecord.creation_datetime = DateTime.Now;

                using (var connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    try {
                        return CreateRecord(applicationName, containerName, newRecord, connection);
                    }
                    catch (SqlException e) when (e.Number == 2627) {
                        newRecord.name = GenerateTimestampName(newRecord.name);
                        return CreateRecord(applicationName, containerName, newRecord, connection);
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }
        }


        private IHttpActionResult CreateRecord(string applicationName, string containerName, Models.Record newRecord, SqlConnection conn) {
            // Query to get the application ID based on applicationName
            string getApplicationIdQuery = "SELECT id FROM applications WHERE name = @applicationName";
            int applicationId;

            using (var getCommand = new SqlCommand(getApplicationIdQuery, conn)) {
                getCommand.Parameters.AddWithValue("@applicationName", applicationName);
                object result = getCommand.ExecuteScalar();
                if (result == null) {
                    return NotFound(); // Return 404 if the application name is not found
                }
                applicationId = (int)result;
            }

            // Query to get the container ID based on containerName and application ID
            string getContainerIdQuery = "SELECT id FROM containers WHERE name = @containerName AND parent = @applicationId";
            int containerId;

            using (var getCommand = new SqlCommand(getContainerIdQuery, conn)) {
                getCommand.Parameters.AddWithValue("@containerName", containerName);
                getCommand.Parameters.AddWithValue("@applicationId", applicationId);
                object result = getCommand.ExecuteScalar();
                if (result == null) {
                    return NotFound(); // Return 404 if the container name is not found
                }
                containerId = (int)result;
            }

            // Set the container ID as the parent for the new record
            newRecord.parent = containerId;

            // Query to insert the new record
            string sqlQuery = @"INSERT INTO records (name, content, creation_datetime, parent) OUTPUT INSERTED.id 
                        VALUES (@name, @content, @creation_datetime, @parent)";

            using (var command = new SqlCommand(sqlQuery, conn)) {
                command.Parameters.AddWithValue("@name", newRecord.name);
                command.Parameters.AddWithValue("@content", newRecord.content);
                command.Parameters.AddWithValue("@creation_datetime", newRecord.creation_datetime);
                command.Parameters.AddWithValue("@parent", newRecord.parent);
                newRecord.id = (int)command.ExecuteScalar();
            }

            // Fetch the newly inserted record
            Record newRecordInserted = null; // This will hold the record details including database alterations
            string selectQuery = "SELECT * FROM records WHERE id = @id";

            using (var command = new SqlCommand(selectQuery, conn)) {
                command.Parameters.AddWithValue("@id", newRecord.id);
                using (var reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        newRecordInserted = new Record {
                            id = (int)reader["id"],
                            name = (string)reader["name"],
                            content = (string)reader["content"],
                            creation_datetime = (DateTime)reader["creation_datetime"],
                            parent = (int)reader["parent"]
                        };
                    }
                }
            }

            // Notifications
            using (var command = new SqlCommand(
                "SELECT * FROM notifications n " +
                "JOIN containers c on n.parent = c.id " +
                "WHERE c.name = @containerName " +
                "AND n.event = 1 " +
                "AND n.enabled = 1", conn)) {
                command.Parameters.AddWithValue("@containerName", containerName);

                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Console.WriteLine("Notification: " + reader["name"]);
                        EventNotification eventNotification = new EventNotification {
                            record = newRecordInserted,
                            @event = "creation"
                        };
                        // HTTP
                        if (((string)reader["endpoint"]).StartsWith("http://")) {
                            SendHTTPNotification((string)reader["endpoint"], eventNotification);
                        }
                        // MQTT
                        else {
                            string channelName = "api/somiod/" + applicationName + "/" + containerName;
                            SendMQTTNotification(channelName, (string)reader["endpoint"], eventNotification);
                        }
                    }
                }
            }
            return Created("", newRecord);
        }



        [HttpDelete]
        [Route("{applicationName}/{containerName}/record/{recordName}")]
        public IHttpActionResult DeleteRecord(string applicationName, string containerName, string recordName) {
            Record deletedRecord = null;
            try {
                using (var conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    // Vai buscar à base de dados o record que vai ser apagado. Não se apaga logo porque é preciso guardar uma cópia para envinar na notificação
                    using (var selectCommand = new SqlCommand(
                        "SELECT r.id, r.name, r.content, r.creation_datetime, r.parent " +
                        "FROM records r " +
                        "JOIN containers c ON r.parent = c.id " +
                        "JOIN applications a ON c.parent = a.id " +
                        "WHERE a.name = @applicationName " +
                        "AND c.name = @containerName " +
                        "AND r.name = @recordName", conn)) {
                        selectCommand.Parameters.AddWithValue("@applicationName", applicationName);
                        selectCommand.Parameters.AddWithValue("@containerName", containerName);
                        selectCommand.Parameters.AddWithValue("@recordName", recordName);

                        using (var reader = selectCommand.ExecuteReader()) {
                            if (reader.Read()) {
                                // Guarda o record que vai ser apagado numa variável
                                deletedRecord = new Record {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    content = (string)reader["content"],
                                    creation_datetime = (DateTime)reader["creation_datetime"],
                                    parent = (int)reader["parent"]
                                };
                            }
                        }
                    }

                    if (deletedRecord == null) {
                        return NotFound();
                    }

                    // Apaga o record
                    using (var deleteCommand = new SqlCommand(
                        "DELETE FROM records " +
                        "WHERE id = @recordId", conn)) {
                        deleteCommand.Parameters.AddWithValue("@recordId", deletedRecord.id);
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Mandar as notificações
                    using (var notificationCommand = new SqlCommand(
                        "SELECT * FROM notifications n " +
                        "JOIN containers c ON n.parent = c.id " +
                        "WHERE c.name = @containerName " +
                        "AND n.event = 2 " +
                        "AND n.enabled = 1", conn)) {
                        notificationCommand.Parameters.AddWithValue("@containerName", containerName);

                        using (var reader = notificationCommand.ExecuteReader()) {
                            while (reader.Read()) {
                                EventNotification eventNotification = new EventNotification {
                                    record = deletedRecord,
                                    @event = "deletion"
                                };
                                // HTTP
                                if (((string)reader["endpoint"]).StartsWith("http://")) {
                                    SendHTTPNotification((string)reader["endpoint"], eventNotification);
                                }
                                // MQTT
                                else {
                                    string channelName = "api/somiod/" + applicationName + "/" + containerName;
                                    SendMQTTNotification(channelName, (string)reader["endpoint"], eventNotification);
                                }
                            }
                        }
                    }
                }

                return StatusCode(HttpStatusCode.NoContent);
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
        public IHttpActionResult GetNotification(string applicationName, string containerName, string notificationName) {
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

        private IHttpActionResult HandleNotification(string applicationName, string containerName, XmlDocument xmlData) {
            try {
                Models.Notification newNotification;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.Notification));
                using (var xmlNodeReader = new XmlNodeReader(xmlData.DocumentElement)) {
                    newNotification = (Models.Notification)xmlSerializer.Deserialize(xmlNodeReader);
                }

                newNotification.creation_datetime = DateTime.Now;

                using (var connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    try {
                        return CreateNotification(applicationName, containerName, newNotification, connection);
                    }
                    catch (SqlException e) when (e.Number == 2627) {
                        newNotification.name = GenerateTimestampName(newNotification.name);
                        return CreateNotification(applicationName, containerName, newNotification, connection);
                    }
                }
            }
            catch (Exception) {
                return InternalServerError();
            }
        }


        private IHttpActionResult CreateNotification(String applicationName, String containerName, Models.Notification newNotification, SqlConnection conn) {
            // Query to get the application ID based on applicationName
            string getApplicationIdQuery = "SELECT id FROM applications WHERE name = @applicationName";
            int applicationId;

            using (var getCommand = new SqlCommand(getApplicationIdQuery, conn)) {
                getCommand.Parameters.AddWithValue("@applicationName", applicationName);
                object result = getCommand.ExecuteScalar();
                if (result == null) {
                    return NotFound(); // Return 404 if the application name is not found
                }
                applicationId = (int)result;
            }

            // Query to get the container ID based on containerName and application ID
            string getContainerIdQuery = "SELECT id FROM containers WHERE name = @containerName AND parent = @applicationId";
            int containerId;

            using (var getCommand = new SqlCommand(getContainerIdQuery, conn)) {
                getCommand.Parameters.AddWithValue("@containerName", containerName);
                getCommand.Parameters.AddWithValue("@applicationId", applicationId);
                object result = getCommand.ExecuteScalar();
                if (result == null) {
                    return NotFound(); // Return 404 if the container name is not found
                }
                containerId = (int)result;
            }

            // Set the container ID as the parent for the new notification
            newNotification.parent = containerId;


            string sqlQuery = @"INSERT INTO notifications (name, creation_datetime, parent, event, endpoint, enabled) OUTPUT INSERTED.id 
                                VALUES (@name, @creation_datetime, @parent, @event, @endpoint, @enabled)";

            using (var command = new SqlCommand(sqlQuery, conn)) {
                command.Parameters.AddWithValue("@name", newNotification.name);
                command.Parameters.AddWithValue("@creation_datetime", newNotification.creation_datetime);
                command.Parameters.AddWithValue("@parent", newNotification.parent);
                command.Parameters.AddWithValue("@event", newNotification.@event);
                command.Parameters.AddWithValue("@endpoint", newNotification.endpoint);
                command.Parameters.AddWithValue("@enabled", newNotification.enabled);
                newNotification.id = (int)command.ExecuteScalar();

            }
            return Created("", newNotification);
        }

        // DELETE

        [HttpDelete]
        [Route("{applicationName}/{containerName}/notif/{notificationName}")]
        public IHttpActionResult DeleteNotification(string applicationName, string containerName, string notificationName) {
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

                return StatusCode(HttpStatusCode.NoContent);
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
            var xmlResponse = new XElement("applications", applicationsNames.Select(name => new XElement("name", name)));
            return Ok(xmlResponse);
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
            var xmlResponse = new XElement("containers", containersNames.Select(name => new XElement("name", name)));
            return Ok(xmlResponse);
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
            var xmlResponse = new XElement("notifications", notificationsNames.Select(name => new XElement("name", name)));
            return Ok(xmlResponse);
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
            var xmlResponse = new XElement("records", recordsNames.Select(name => new XElement("name", name)));
            return Ok(xmlResponse);
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
            var xmlResponse = new XElement("containers", containersNames.Select(name => new XElement("name", name)));
            return Ok(xmlResponse);
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
            var xmlResponse = new XElement("notifications", notificationsNames.Select(name => new XElement("name", name)));
            return Ok(xmlResponse);
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
            var xmlResponse = new XElement("records", recordsNames.Select(name => new XElement("name", name)));
            return Ok(xmlResponse);
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
            var xmlResponse = new XElement("notifications", notificationsNames.Select(name => new XElement("name", name)));
            return Ok(xmlResponse);
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
            var xmlResponse = new XElement("records", recordsNames.Select(name => new XElement("name", name)));
            return Ok(xmlResponse);
        }

        #endregion

        #endregion

        #region HTTP/MQTT Notifications
        private void SendHTTPNotification(string endpoint, EventNotification notification) {
            try {
                var client = new RestClient(endpoint);
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddParameter("application/xml", notification, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Xml;
                var response = client.Execute(request);

                // TODO isto provavelmente não é suposto mandar exceção
                if (!response.IsSuccessful) {
                    throw new Exception("Error sending HTTP notification");
                }
            }
            catch (Exception ex) {
                return;
            }
        }


        public void SendMQTTNotification(string channelName, string brokerEndpoint, EventNotification notification) {
            try {
                MqttClient mClient = new MqttClient(IPAddress.Parse(brokerEndpoint));
                mClient.Connect(Guid.NewGuid().ToString());

                #region Define XML to send
                XmlDocument xmlDoc = new XmlDocument();

                XmlElement root = xmlDoc.CreateElement("EventNotification");
                xmlDoc.AppendChild(root);

                XmlElement recordElement = xmlDoc.CreateElement("record");

                XmlElement idElement = xmlDoc.CreateElement("id");
                idElement.InnerText = notification.record.id.ToString();
                recordElement.AppendChild(idElement);

                XmlElement nameElement = xmlDoc.CreateElement("name");
                nameElement.InnerText = notification.record.name;
                recordElement.AppendChild(nameElement);

                XmlElement contentElement = xmlDoc.CreateElement("content");
                contentElement.InnerText = notification.record.content;
                recordElement.AppendChild(contentElement);

                XmlElement creationDateTimeElement = xmlDoc.CreateElement("creation_datetime");
                creationDateTimeElement.InnerText = notification.record.creation_datetime.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
                recordElement.AppendChild(creationDateTimeElement);

                XmlElement parentElement = xmlDoc.CreateElement("parent");
                parentElement.InnerText = notification.record.parent.ToString();
                recordElement.AppendChild(parentElement);

                root.AppendChild(recordElement);

                XmlElement eventElement = xmlDoc.CreateElement("event");
                eventElement.InnerText = notification.@event;
                root.AppendChild(eventElement);

                string payload = xmlDoc.OuterXml;

                #endregion

                // Adiciona um evento para disconectar quando a mensagem é publicada. Isto é importante porque assim garante que o Publish tem de ser concluído antes de chamar o Disconnect
                mClient.MqttMsgPublished += (sender, e) => {
                    mClient.Disconnect();
                };
                mClient.Publish(channelName, Encoding.UTF8.GetBytes(payload));
            }
            catch (Exception ex) {
                return;
            }
        }

        #endregion

    }
}
