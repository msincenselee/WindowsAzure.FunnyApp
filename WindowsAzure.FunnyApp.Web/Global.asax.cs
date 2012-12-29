namespace WindowsAzure.FunnyApp.Web
{
    using System;
    using System.Web;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.ServiceRuntime;

    public class Global : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
                configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)));
        }

        public void Application_End(object sender, EventArgs e)
        {
        }

        public void Application_Error(object sender, EventArgs e)
        {
        }
    }
}
