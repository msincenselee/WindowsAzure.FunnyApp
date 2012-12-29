namespace WindowsAzure.FunnyApp.Web.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "Login";

            RegisterHyperLink.NavigateUrl = "Register.aspx";

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }
    }
}