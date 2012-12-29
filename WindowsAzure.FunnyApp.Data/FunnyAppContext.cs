namespace WindowsAzure.FunnyApp.Data
{
    using System.Linq;
    
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;

    using WindowsAzure.FunnyApp.Common;
    using WindowsAzure.FunnyApp.Entities;
    
    public class FunnyAppContext : TableServiceContext
    {
        public FunnyAppContext(string baseAddress, StorageCredentials credentials) 
            : base(baseAddress, credentials)
        {
        }

        public IQueryable<Tag> Tag
        {
            get { return this.CreateQuery<Tag>(typeof(Tag).Name); }
        }

        public IQueryable<Post> Post
        {
            get { return this.CreateQuery<Post>(typeof(Tag).Name); }
        }

        public IQueryable<Comment> Comment
        {
            get { return this.CreateQuery<Comment>(typeof(Tag).Name); }
        }
    }
}
