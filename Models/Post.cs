using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace apitechconecta_prototype.Models
{
    public class Post
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

        [BsonElement("category")]
        public string? Category { get; set; }
        
        [BsonElement("creation-date")]
        public string? CreatedAt { get; set; } = default;

        [BsonElement("title")]
        public string? Title { get; set; }

        [BsonElement("subtitle")]
        public string? Subtitle { get; set; }

        [BsonElement("content")]
        public string? Content { get; set; }

        [BsonElement("post-image")]
        public string? PostImage { get; set; } = null;

        [BsonElement("post-views")]
        public int? PostViews { get; set; }
    }
}
