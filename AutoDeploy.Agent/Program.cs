using Logger;
using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;

namespace AutoDeploy.Agent
{
    public class Program : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public Program()
        {
            ServiceName = "AutoDeploy.Agent";
        }

        public static void Main(string[] args)
        {


            if (System.Environment.UserInteractive)
            {
                string parameter = string.Concat(args);
                switch (parameter.ToLower())
                {
                    case "-install":
                        ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                        LogManager.Instance.WriteInfo("Service Installed.");

                        break;
                    case "-console":
                        ServiceHost serviceHost = new ServiceHost(typeof(AutoDeployService));
                        try
                        {
                            serviceHost.Open();
                            LogManager.Instance.WriteInfo("AutoDeploy Server Starting...........");

                        }
                        catch (Exception ex)
                        {
                            LogManager.Instance.WriteError(ex.Message);
                        }
                        while (true) { }
                        break;
                }
            }
            else
            {

                ServiceBase.Run(new Program());

            }



        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            try
            {
                serviceHost = new ServiceHost(typeof(AutoDeployService));
                serviceHost.Open();
                LogManager.Instance.WriteInfo("AutoDeploy Server Starting...........");

            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteError(ex.Message);
            }
        }


    }

}
