namespace WindowsAzure.FunnyApp.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    using WindowsAzure.FunnyApp.Data;
    using WindowsAzure.FunnyApp.Entities;
    using WindowsAzure.FunnyApp.Web.ViewDatas;

    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Home";

            if(IsPostBack)return;
            FunnyAppRepository<Post> _postRepository = new FunnyAppRepository<Post>();
            List<PostViewData> viewDatas = new List<PostViewData>();
            _postRepository.Get().Where(post => post.State == true).ToList()
                           .OrderByDescending(post => post.Timestamp)
                           .Take(20).ToList().ForEach(post => viewDatas.Add(new PostViewData()
                               {
                                   PostContent = post.PostContent,
                                   PostImage = post.PostImage,
                                   RowKey = post.RowKey,
                                   UserId = post.UserId
                               }));
            this.RepeaterImages.DataSource = viewDatas;
            this.RepeaterImages.DataBind();
        }
    }
}