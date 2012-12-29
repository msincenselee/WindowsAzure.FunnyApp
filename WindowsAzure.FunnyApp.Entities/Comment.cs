namespace WindowsAzure.FunnyApp.Entities
{
    public class Comment : EntityBase
    {
        public string Content { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string PostRowKey { get; set; }
    }
}
