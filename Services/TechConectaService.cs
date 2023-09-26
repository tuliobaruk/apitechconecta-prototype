using apitechconecta_prototype.Models;
using apitechconecta_prototype.Configurations;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace apitechconecta_prototype.Services;

public class TechConectaService
{
    private readonly IMongoCollection<Post> _postCollection;
    private readonly IMongoCollection<Comment> _commentCollection;
    private readonly IMongoCollection<User> _userCollection;

    public TechConectaService(IOptions<DatabaseSettings> databaseSettings)
    {
        MongoClient client = new(databaseSettings.Value.ConnectionString);
        IMongoDatabase database = client.GetDatabase(databaseSettings.Value.DatabaseName);

        _postCollection = database.GetCollection<Post>(databaseSettings.Value.PostsCollectionName);
        _commentCollection = database.GetCollection<Comment>(databaseSettings.Value.CommentsCollectionName);
        _userCollection = database.GetCollection<User>(databaseSettings.Value.UsersCollectionName);
    }

    // Posts

    public async Task<List<Post>> GetPostsAsync() => 
        await _postCollection.Find(_ => true).ToListAsync();

    public async Task<Post> GetPostAsync(int postid) => 
        await _postCollection.Find(x => x.PostId == postid).FirstOrDefaultAsync();

    public async Task CreateAsync(Post post) =>
        await _postCollection.InsertOneAsync(post);

    public async Task UpdateAsync(Post post) =>
        await _postCollection.ReplaceOneAsync(x => x.PostId == post.PostId, post);

    public async Task RemoveAsync(int postid) =>
        await _postCollection.DeleteOneAsync(x => x.PostId == postid);

    // Comments

    public async Task<List<Comment>> GetCommentsAsync() =>
        await _commentCollection.Find(_ => true).ToListAsync();

    public async Task<List<Comment>> GetCommentAsync(int commentid) =>
        await _commentCollection.Find(x => x.PostId == commentid).ToListAsync();

    // Users

    public async Task<User> GetUserAsync(int userid) =>
        await _userCollection.Find(x => x.UserId == userid).FirstOrDefaultAsync();

    public async Task<List<User>> GetUsersAsync() =>
        await _userCollection.Find(_ => true).ToListAsync();
}
