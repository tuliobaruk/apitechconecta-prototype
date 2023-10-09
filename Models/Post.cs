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

        [BsonElement("postId")]
        public int PostId { get; set; }

        [BsonElement("creator")]
        public User? Creator { get; set; }

        [BsonElement("category")]
        public string? Category { get; set; }
        
        [BsonElement("createdAt")]
        public string? CreatedAt { get; set; } = default;

        [BsonElement("title")]
        public string? Title { get; set; }

        [BsonElement("subtitle")]
        public string? Subtitle { get; set; }

        [BsonElement("content")]
        public string? Content { get; set; }

        [BsonElement("postImage")]
        public string? PostImage { get; set; } = null;

        [BsonElement("postViews")]
        public int? PostViews { get; set; }
    }
}
