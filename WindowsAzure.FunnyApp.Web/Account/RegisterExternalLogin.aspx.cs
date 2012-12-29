using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WindowsAzure.FunnyApp.Web.Account
{
    public partial class RegisterExternalLogin : System.Web.UI.Page
    {

        protected string ProviderName
        {
            get { return (string)ViewState["ProviderName"] ?? String.Empty; }
            private set { ViewState["ProviderName"] = value; }
        }

        protected string ProviderDisplayName
        {
            get { return (string)ViewState["ProviderDisplayName"] ?? String.Empty; }
            private set { ViewState["ProviderDisplayName"] = value; }
        }

        protected string ProviderUserId
        {
            get { return (string)ViewState["ProviderUserId"] ?? String.Empty; }
            private set { ViewState["ProviderUserId"] = value; }
        }

        protected string ProviderUserName
        {
            get { return (string)ViewState["ProviderUserName"] ?? String.Empty; }
            private set { ViewState["ProviderUserName"] = value; }
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
            }
        }
    }
}