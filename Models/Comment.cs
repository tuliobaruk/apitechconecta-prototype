using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace apitechconecta_prototype.Models
{
    public class Comment
    {
        [SwaggerSchema(Description = "Mongo Object ID", ReadOnly = true)]
        [BsonId]
        [JsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ObjectId { get; set; }

        [BsonElement("post-id")]
        public int PostId { get; set; }

        [BsonElement("creator-id")]
        public int CreatorId { get; set; }

        [BsonElement("creation-date")]
        public string? CreationDate { get; set; }

        [BsonElement("content")]
        public string? Content { get; set; }
    }
}
