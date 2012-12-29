namespace WindowsAzure.FunnyApp.Web.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Security;
    using System.Web.UI;

    using WindowsAzure.FunnyApp.Data;
    using WindowsAzure.FunnyApp.Entities;
    using WindowsAzure.FunnyApp.Web.ViewDatas;

    public partial class MyUploads : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            FunnyAppRepository<Post> _postRepository = new FunnyAppRepository<Post>();
            List<PostViewData> viewDatas = new List<PostViewData>();
            _postRepository.Get().Where(post => post.UserId == Membership.GetUser(Page.User.Identity.Name).ProviderUserKey.ToString()).ToList()
                           .Where(post=> post.State)
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