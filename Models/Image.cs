using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace apitechconecta_prototype.Models
{
    public class Images
    {
        [SwaggerSchema(Description = "Mongo Object ID", ReadOnly = true)]
        [BsonId]
        [JsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ObjectId { get; set; }

        [BsonElement("image-name")]
        public string? Name { get; set; }

        [BsonElement("image-mime")]
        public string? TypeMIME { get; set; }

        [BsonElement("image-data")]
        public byte[] Data { get; set; }
    }
}
