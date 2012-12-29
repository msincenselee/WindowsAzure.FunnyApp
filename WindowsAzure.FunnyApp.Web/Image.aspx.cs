namespace WindowsAzure.FunnyApp.Web
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Text;
    using System.Collections.Generic;

    using WindowsAzure.FunnyApp.Data;
    using WindowsAzure.FunnyApp.Entities;

    public partial class Image : Page
    {
        private readonly FunnyAppRepository<Post> _postRepository = new FunnyAppRepository<Post>();
        private readonly FunnyAppRepository<Tag> _tagRepository = new FunnyAppRepository<Tag>();
        private readonly FunnyAppRepository<Comment> _commentRepository = new FunnyAppRepository<Comment>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = Request.QueryString["q"];
            if (!string.IsNullOrEmpty(queryString))
            {
                Post post =_postRepository.Get().Where(p => p.RowKey == queryString).ToList().FirstOrDefault();
                if (post != null)
                {
                    ImageYou.ImageUrl = post.PostImage;
                    LabelDescription.Text = post.PostContent;
                    LabelTitle.Text = post.PostTitle;
                    this.CommentLoad(queryString);
                    HiddenFieldPost.Value = queryString;
                }

                LiteralTag.Text = TagBuilder(post.RowKey);
            }
        }

        protected void ButtonCommentSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                _commentRepository.Create(new Comment()
                    {
                        Content = TextBoxCommet.Text,
                        UserName = TextBoxUserName.Text,
                        UserEmail = TextBoxEmail.Text,
                        PostRowKey = HiddenFieldPost.Value
                    });
                _commentRepository.SubmitChange();

                LabelResult.Text = "Comment Sended";
            }
            else
            {
                LabelResult.Text = "Comment Failed";
            }
        }

        public void CommentLoad(string postRowKey)
        {
            List<Comment> comments = _commentRepository.Get().Where(comment => comment.PostRowKey == postRowKey).ToList();
            this.RepeaterComments.DataSource = comments;
            this.RepeaterComments.DataBind();
        }

        public string TagBuilder(string postRowKey)
        {
            List<string> tags = new List<string>();
            List<Tag> result = _tagRepository.Get().Where(t => t.PostRowKey == postRowKey).ToList();
            foreach (var tag in result)
            {
                tags.Add(tag.TagName);
            }

            StringBuilder builder = new StringBuilder();
            foreach (var tag in tags.Distinct())
            {
                builder.Append(string.Format("<a href='/Tags.aspx?tag={0}'>{1}</a>", tag, tag));
            }

            return builder.ToString();
        }
    }
}