namespace WindowsAzure.FunnyApp.Entities
{
    using System;

    using Microsoft.WindowsAzure.StorageClient;

    public class EntityBase : TableServiceEntity
    {
        public EntityBase()
        {
            this.PartitionKey = DateTime.UtcNow.ToString("MMddyyyy");
            this.RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
        }
    }
}
