namespace apitechconecta_prototype.Configurations
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
        public string PostsCollectionName { get; set; } = null!;
        public string CommentsCollectionName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
        public string ImagesCollectionName { get; set; } = null!;
    }
}
