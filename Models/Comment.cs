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

        [BsonElement("postId")]
        public int PostId { get; set; }
        
        [BsonElement("commentId")]
        public int CommentId { get; set; }

        [BsonElement("creator")]
        public User? Creator { get; set; }

        [BsonElement("createdAt")]
        public string? CreatedAt { get; set; }

        [BsonElement("content")]
        public string? Content { get; set; }
    }
}
