namespace WindowsAzure.FunnyApp.Web.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.UI;

    using WindowsAzure.FunnyApp.Data;
    using WindowsAzure.FunnyApp.Entities;

    public partial class TagControl : UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)return;
            FunnyAppRepository<Tag> _tagRepository = new FunnyAppRepository<Tag>();

            List<string> tags = new List<string>();

            foreach (var tag in _tagRepository.Get().ToList())
            {
                tags.Add(tag.TagName);
            }

            StringBuilder builder = new StringBuilder();
            foreach (var tag in tags.Distinct())
            {
                builder.Append(string.Format("<a href='/Tags.aspx?tag={0}'>{1}</a>", tag, tag));
            }

            LiteralTag.Text = builder.ToString();
        }
    }
}