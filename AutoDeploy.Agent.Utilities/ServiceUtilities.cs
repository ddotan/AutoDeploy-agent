using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration.Install;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AutoDeploy.Agent.Utilities
{
    public class ServiceUtilities : IServiceUtilities
    {
        public void StopService(string i_ServiceName, int i_TimeOutMiliSeconds)
        {
            if (!ServiceExists(i_ServiceName))
            {
                throw new Exception("Service : " + i_ServiceName + " not exists");

            }
            else if (!IsRunning(i_ServiceName))
            {
                throw new Exception("Service already stopped");

            }
            else
            {
                ServiceController service = new ServiceController(i_ServiceName);
                TimeSpan timeout = TimeSpan.FromMilliseconds(i_TimeOutMiliSeconds);
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
            }
        }
        public void StartService(string i_ServiceName, int i_TimeOutMiliSeconds)
        {

            if (!ServiceExists(i_ServiceName))
            {
                throw new Exception("Service : " + i_ServiceName + " not exists");

            }
            else if (IsRunning(i_ServiceName))
            {
                throw new Exception("Service already running");

            }
            else
            {
                ServiceController service = new ServiceController(i_ServiceName);
                TimeSpan timeout = TimeSpan.FromMilliseconds(i_TimeOutMiliSeconds);
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
        }
        public bool IsRunning(string i_ServiceName)
        {
            if (ServiceExists(i_ServiceName))
            {
                ServiceController service = new ServiceController(i_ServiceName);
                return (service.Status == ServiceControllerStatus.Running);
            }
            else
            {
                return false;
            }
        }
        public bool ServiceExists(string i_ServiceName)
        {
            try
            {
                ServiceController service = new ServiceController(i_ServiceName);
                return !string.IsNullOrEmpty(service.ServiceName);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void ResetService(string i_ServiceName, int i_TimeOutMiliSeconds)
        {
            StopService(i_ServiceName, i_TimeOutMiliSeconds);
            StartService(i_ServiceName, i_TimeOutMiliSeconds);
        }
        public void InstallService(string i_ServiceName, string i_ExecutablePath, string i_ExeParams)
        {


            string createService = string.Format(@"sc create {0} binpath=  ""{1} {2}"" start= delayed-auto", i_ServiceName, i_ExecutablePath, i_ExeParams);
            Console.WriteLine(createService);

            string failureConfiguration = string.Format("sc failure {0} reset= 60 actions= restart/5000", i_ServiceName);
            ExecuteCmdCommand(createService, failureConfiguration);
            Thread.Sleep(1000);
            if (!ServiceExists(i_ServiceName))
            {
                throw new Exception("Couldnt Install Service");
            }
        }
        public void DeleteService(string i_ServiceName)
        {
            ServiceInstaller ServiceInstallerObj = new ServiceInstaller();
            InstallContext Context = new InstallContext(AppDomain.CurrentDomain.BaseDirectory + "\\uninstalllog.log", null);
            ServiceInstallerObj.Context = Context;
            ServiceInstallerObj.ServiceName = i_ServiceName;
            ServiceInstallerObj.Uninstall(null);
        }
    }
}
