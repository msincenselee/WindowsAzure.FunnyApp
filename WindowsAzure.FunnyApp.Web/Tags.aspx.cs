namespace WindowsAzure.FunnyApp.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using WindowsAzure.FunnyApp.Data;
    using WindowsAzure.FunnyApp.Entities;
    using WindowsAzure.FunnyApp.Web.ViewDatas;

    public partial class Tags : System.Web.UI.Page
    {
        private readonly FunnyAppRepository<Post> _postRepository = new FunnyAppRepository<Post>();
        private readonly FunnyAppRepository<Tag> _tagRepository = new FunnyAppRepository<Tag>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = Request.QueryString["tag"];
            if (!string.IsNullOrEmpty(queryString))
            {
                List<Tag> result =
                    _tagRepository.Get()
                                  .Where(t => t.TagName.Equals(queryString, StringComparison.OrdinalIgnoreCase))
                                  .ToList();
                List<PostViewData> temp = new List<PostViewData>();
                foreach (Tag t in result)
                {
                    PostViewData post = PostRowByPost(t.PostRowKey, t.PostPartitionKey);
                    if (post != null)
                    {
                        temp.Add(post);
                    }
                }
                this.RepeaterImages.DataSource = temp;
                this.RepeaterImages.DataBind();
            }
        }

        public PostViewData PostRowByPost(string postRowKey, string postPartitionKey)
        {
            Post post = _postRepository.Find(postRowKey);
            
            if (post == null) return null;
            if (!post.State) return null;

            return new PostViewData
                {
                    PostContent = post.PostContent,
                    PostImage = post.PostImage,
                    PostTitle = post.PostTitle,
                    RowKey = post.RowKey
                };
        }
    }
}