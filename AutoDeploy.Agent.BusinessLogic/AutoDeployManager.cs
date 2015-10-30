using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Logger;
using AutoDeploy.Agent.Objects;
using AutoDeploy.Agent.Utilities;

namespace AutoDeploy.Agent.BusinessLogic
{
    public class AutoDeployManager
    {

        private ICMDUtilities m_CMDUtilities;
        private IFileUtilities m_FileUtilities;
        private IServiceManager m_ServiceManager;
        private enum eDeployment
        {
            Upgrade,
            NewInstall,
            VersionAlreadyExists
        }
        private ILogManager m_LogManager;
        private IAppConfig m_AppConfig;
        private void refreshAppConfig()
        {
            m_AppConfig = m_AppConfig.GetInstance();
        }
        //Function to check on startup
        public AutoDeployManager(IServiceManager i_ServiceManager, ILogManager i_LogManager, IAppConfig i_AppConfig, IFileUtilities i_FileUtilities, ICMDUtilities i_CMDUtilities)
        {
            m_ServiceManager = i_ServiceManager;
            m_FileUtilities = i_FileUtilities;
            m_CMDUtilities = i_CMDUtilities;
            m_LogManager = i_LogManager;
            m_AppConfig = i_AppConfig.GetInstance();
            string netUsePath = string.Format("NET USE {0} /USER:{1} {2}", m_AppConfig.RemotePath, m_AppConfig.RemotePathUserName, m_AppConfig.RemotePathPassword);
            m_CMDUtilities.ExecuteCmdCommand(netUsePath);
        }

        public void Deploy()
        {
            eDeployment deployType = eDeployment.NewInstall;
            try
            {
                string currentVer = FileUtilities.GetVersion(m_AppConfig.ExecutablePath);
                string upgradeVer = FileUtilities.GetVersion(FolderUtilities.GetExecutablePath(m_AppConfig.RemotePath));
                if (currentVer == upgradeVer && !string.IsNullOrEmpty(currentVer))
                {
                    deployType = eDeployment.VersionAlreadyExists;
                    throw new Exception("current version is :" + currentVer + ", trying to deploy : " + upgradeVer + " [Same Version]");
                }

                m_LogManager.WriteInfo("Deploy Started");
                m_LogManager.WriteInfo("Current Version : " + currentVer + " , Deploying Version : " + upgradeVer);
                if (m_ServiceManager.service())
                {
                    m_LogManager.WriteInfo("Service Already Exists.");
                    if (m_ServiceManager.ServiceRunning())
                    {
                        m_ServiceManager.StopService();
                        m_ServiceManager.DeleteService();
                    }
                    else
                    {
                        m_ServiceManager.DeleteService();


                    }
                }
                //new install
                if (FolderUtilities.Exists(m_AppConfig.InstallationPath))
                {
                    m_LogManager.WriteInfo("Folder Already Exists.");

                    deployType = eDeployment.Upgrade;
                    if (FolderUtilities.Exists(m_AppConfig.BackupPath))
                    {
                        throw new Exception("You are trying to install older version(Backup already exists)");
                    }
                    FolderUtilities.RenameFolder(m_AppConfig.InstallationPath, m_AppConfig.BackupPath);
                }
                m_LogManager.WriteInfo("Copying remote folder.");

                FolderUtilities.CopyFolder(m_AppConfig.RemotePath, m_AppConfig.InstallationPath);
                refreshAppConfig();
                m_ServiceManager.InstallService();
                m_ServiceManager.StartService();
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
                switch (deployType)
                {
                    case eDeployment.NewInstall:
                        DeleteInstalltion();

                        exception += "[Installtion aborted]";

                        break;

                    case eDeployment.Upgrade:
                        RollBack();
                        exception += "[RollBack Preformed]";
                        break;
                    case eDeployment.VersionAlreadyExists:
                        exception += "[Idle]";

                        break;

                }
                throw new Exception(exception);
            }
        }
        public string GetVersion()
        {
            string version = FileUtilities.GetVersion(m_AppConfig.ExecutablePath);


            return version;
        }
        public string GetName()
        {
            return m_AppConfig.Name;
        }
        public string GetRemotePathUserName()
        {
            return m_AppConfig.RemotePathUserName;
        }
        public void SetRemotePathUserName(string i_RemotePathUserName)
        {
            m_AppConfig.RemotePathUserName = i_RemotePathUserName;

        }
        public string GetRemotePathPassword()
        {
            return m_AppConfig.RemotePathPassword;

        }
        public void SetRemotePathPassword(string i_Password)
        {
            m_AppConfig.RemotePathPassword = i_Password;
        }
        public string GetRemotePath()
        {
            return m_AppConfig.RemotePath;

        }
        public void SetRemotePath(string i_RemotePath)
        {
            m_AppConfig.RemotePath = i_RemotePath;

        }
        public string GetAdditionalExeParams()
        {
            return m_AppConfig.ExeParams;
        }
        public void SetAdditionalExeParams(string i_AdditionalParams)
        {
            m_AppConfig.ExeParams = i_AdditionalParams;

        }

        //API-Helpers
        private void RollBack()
        {
            FolderUtilities.RenameFolder(m_AppConfig.BackupPath, m_AppConfig.InstallationPath);
            m_LogManager.WriteInfo("Performing RollBack : ");

            if (!m_ServiceManager.ServiceExists())
            {
                m_ServiceManager.InstallService();
                m_ServiceManager.StartService();
            }
            else
            {
                m_ServiceManager.StartService();
            }

        }
        private void DeleteInstalltion()
        {
            m_LogManager.WriteInfo("Deleteing Installtion : ");

            if (FolderUtilities.Exists(m_AppConfig.InstallationPath))
            {
                FolderUtilities.DeleteFolder(m_AppConfig.InstallationPath);
            }
            if (m_ServiceManager.ServiceRunning())
            {
                m_ServiceManager.StopService();
            }
            if (m_ServiceManager.ServiceExists())
            {
                m_ServiceManager.DeleteService();
            }
        }

        //additional function
        public void SetName(string i_Name)
        {
            m_AppConfig.Name = i_Name;
        }
        public void SaveAppConfig()
        {
            m_AppConfig.SaveInfo();
        }

        void SetServiceName(string i_ServiceName)
        {
            m_AppConfig.ServiceName = i_ServiceName;
        }
        public string GetInstalltionPath()
        {
            return m_AppConfig.InstallationPath;
        }

        public void SetInstalltionPath(string i_InstallPath)
        {
            m_AppConfig.InstallationPath = i_InstallPath;
        }
    }

}
