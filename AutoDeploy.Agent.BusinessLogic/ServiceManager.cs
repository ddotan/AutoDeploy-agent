using AutoDeploy.Agent.Objects;
using AutoDeploy.Agent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDeploy.Agent.BusinessLogic
{
    public class ServiceManager : IServiceManager
    {
        IAppConfig m_AppConfig;
        public ServiceManager(IAppConfig i_AppConfig)
        {
            m_AppConfig = i_AppConfig.GetInstance();
        }
        public void InstallService()
        {
            ServiceUtilities.InstallService(m_AppConfig.ServiceName, m_AppConfig.ExecutablePath, m_AppConfig.ExeParams);
        }
        public void DeleteService()
        {
            ServiceUtilities.DeleteService(m_AppConfig.ServiceName);

        }
        public bool ServiceRunning()
        {
            return ServiceUtilities.IsRunning(m_AppConfig.ServiceName);
        }
        public bool ServiceExists()
        {
            return ServiceUtilities.ServiceExists(m_AppConfig.ServiceName);


        }
        public void StartService()
        {
            ServiceUtilities.StartService(m_AppConfig.ServiceName, 8000);
        }
        public void StopService()
        {
            ServiceUtilities.StopService(m_AppConfig.ServiceName, 8000);
        }
        public string GetServiceName()
        {
            return m_AppConfig.ServiceName;
        }


    
    }
}
