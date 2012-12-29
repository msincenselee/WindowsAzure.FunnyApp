namespace WindowsAzure.FunnyApp.Web.Shared
{
    using System;
    using System.Web.UI;

    public partial class Main : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "Home";
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxSearch.Text))
            {
                Response.Redirect(string.Format("~/Result.aspx?q={0}", TextBoxSearch.Text));
            }
        }
    }
}