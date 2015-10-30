
using AutoDeploy.Agent.BusinessLogic;
using AutoDeploy.Agent.Contract;
using Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;

namespace AutoDeploy.Agent.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AutoDeployService : IAutoDeployService
    {
        private AutoDeployManager m_autoDeployManager = new AutoDeployManager();
        public AutoDeployService()
        {
            //check invalid params
        }
        public void StartService()
        {

            m_autoDeployManager.StartService();
        }
        public void StopService()
        {

            m_autoDeployManager.StopService();

        }
        public string GetVersion()
        {
            return m_autoDeployManager.GetVersion();
        }
        public bool ServiceRunning()
        {
            return m_autoDeployManager.ServiceRunning();
        }
        public void Deploy()
        {
            m_autoDeployManager.Deploy();
        }
        public string GetName()
        {
            return m_autoDeployManager.GetName();
        }
        public bool ServiceExists()
        {
            return m_autoDeployManager.ServiceExists();
        }

        public string GetRemotePathUserName()
        {

            return m_autoDeployManager.GetRemotePathUserName();
        }

        public void SetRemotePathUserName(string i_UserName)
        {
            m_autoDeployManager.SetRemotePathPassword(i_UserName);
        }

        public string GetRemotePathPassword()
        {
            return m_autoDeployManager.GetRemotePathPassword();
        }

        public void SetRemotePathPassword(string i_Password)
        {
            m_autoDeployManager.SetRemotePathPassword(i_Password);
        }

        public string GetRemotePath()
        {
            return m_autoDeployManager.GetRemotePath();
        }

        public void SetRemotePath(string i_RemotePath)
        {
            m_autoDeployManager.SetRemotePath(i_RemotePath);
        }


        public string GetAdditionalExeParams()
        {
            return m_autoDeployManager.GetAdditionalExeParams();
        }

        public void SetAdditionalExeParams(string i_AdditionalParams)
        {
            m_autoDeployManager.SetAdditionalExeParams(i_AdditionalParams);
        }


        public void SetName(string i_Name)
        {
            m_autoDeployManager.SetName(i_Name);
        }


        public void SaveAppConfig()
        {
            m_autoDeployManager.SaveAppConfig();
        }


        public string GetServiceName()
        {
            return m_autoDeployManager.GetServiceName();
        }

        public void SetServiceName(string i_ServiceName)
        {
            m_autoDeployManager.SetAdditionalExeParams(i_ServiceName);
        }


        public string GetInstalltionPath()
        {
         return   m_autoDeployManager.GetInstalltionPath();
        }

        public void SetInstalltionPath(string i_InstallPath)
        {
            m_autoDeployManager.SetInstalltionPath(i_InstallPath);
        }
    }
}
