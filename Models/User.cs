using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace apitechconecta_prototype.Models
{
    public class User
    {
        [SwaggerSchema(Description = "Mongo Object ID", ReadOnly = true)]
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ObjectId { get; set; }

        [BsonElement("user-id")]
        public int UserId { get; set; }

        [BsonElement("username")]
        public string? Username { get; set; }

        [BsonElement("e-mail")]
        public string? Email { get; set; }

        [JsonIgnore]
        [BsonElement("password")]
        public string? Password { get; set; }
    }
}
