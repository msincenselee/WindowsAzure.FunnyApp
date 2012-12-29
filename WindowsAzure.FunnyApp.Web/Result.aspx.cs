namespace WindowsAzure.FunnyApp.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    using WindowsAzure.FunnyApp.Data;
    using WindowsAzure.FunnyApp.Entities;
    using WindowsAzure.FunnyApp.Web.ViewDatas;

    public partial class Result : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = Request.QueryString["q"];
            if (!string.IsNullOrEmpty(queryString))
            {
                FunnyAppRepository<Post> postRepository = new FunnyAppRepository<Post>();
                List<PostViewData> viewDatas = new List<PostViewData>();
                postRepository.Get().Where(m => m.State == true)
                               .ToList()
                               .Where(m => m.PostTitle.StartsWith(queryString, StringComparison.OrdinalIgnoreCase))
                               .ToList()
                               .ForEach(post => viewDatas.Add(new PostViewData()
                                   {
                                       RowKey = post.RowKey,
                                       PostContent = post.PostContent,
                                       PostImage = post.PostImage,
                                       PostTitle = post.PostTitle
                                   }));
                this.RepeaterImages.DataSource = viewDatas;
                this.RepeaterImages.DataBind();
            }
        }
    }
}