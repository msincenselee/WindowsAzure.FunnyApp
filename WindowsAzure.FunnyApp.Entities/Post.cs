namespace WindowsAzure.FunnyApp.Entities
{
    public class Post : EntityBase
    {
        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public string PostImage { get; set; }

        public string UserPartitionKey { get; set; }
    }
}
