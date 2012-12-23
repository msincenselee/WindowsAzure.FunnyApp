namespace WindowsAzure.FunnyApp.Entities
{
    public class Tag : EntityBase
    {
        public string TagName { get; set; }

        public string PostPartitionKey { get; set; }

        public string PostRowKey { get; set; }
    }
}
