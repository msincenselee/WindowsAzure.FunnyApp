namespace WindowsAzure.FunnyApp.Web.Account
{
    using System;
    using System.Web.UI;

    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "Register";
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            //if (!OpenAuth.IsLocalUrl(continueUrl))
            //{
            //    continueUrl = "~/";
            //}
            //Response.Redirect(continueUrl);
        }
    }
}