namespace WindowsAzure.FunnyApp.Entities
{
    public class Post : EntityBase
    {
        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public string PostImage { get; set; }

        public string UserId { get; set; }

        public bool State { get; set; }
    }
}
