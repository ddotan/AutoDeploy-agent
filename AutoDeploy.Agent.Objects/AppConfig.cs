using AutoDeploy.Agent.Utilities;
using Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AutoDeploy.Agent.Objects
{
    public class AppConfig : IAppConfig
    {
        private  IAppConfig m_Appconfig;
        private  IFolderUtilities m_FolderUilities;
        private IFileUtilities m_FileUtilities;
        public AppConfig(IFileUtilities i_FileUtilities , IFolderUtilities i_FolderUtilities,IAppConfig i_AppConfig)
        {
            m_FileUtilities = i_FileUtilities;
            m_FolderUilities = i_FolderUtilities;
            m_Appconfig=i_AppConfig.GetInstance();
            updateAdditionalInfo();
        }
        private  readonly string r_FilePath = AppDomain.CurrentDomain.BaseDirectory + "Config\\AppConfig.xml";
        private  void updateAppConfigInstance()
        {
            updateAdditionalInfo();

        }
        private  void updateAdditionalInfo()
        {
            m_Appconfig.ExecutablePath = m_FolderUilities.GetExecutablePath(m_Appconfig.InstallationPath);
            if (Directory.Exists(m_Appconfig.InstallationPath))
            {
                try
                {
                    m_Appconfig.BackupPath = Directory.GetParent(m_Appconfig.ExecutablePath).FullName + "-" + m_FileUtilities.GetVersion(m_Appconfig.ExecutablePath);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteError("Installtion folder Doesnt include EXE File");

                    m_Appconfig.BackupPath = string.Empty;
                }
            }
            else
            {
                m_Appconfig.BackupPath = string.Empty;
            }
        }
        public void SaveInfo()
        {
            using (FileStream stream = new FileStream(r_FilePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                serializer.Serialize(stream, m_Appconfig);
            }
        }
        public string Name { get; set; }
        public string ServiceName { get; set; }
        public string InstallationPath { get; set; }
        public string ExeParams { get; set; }
        public string RemotePath { get; set; }
        public string RemotePathUserName { get; set; }
        public string RemotePathPassword { get; set; }


        [XmlIgnore]
        public string ExecutablePath { get; set; }
        [XmlIgnore]
        public string BackupPath { get; set; }
        private AppConfig()
        {
        }
        public IAppConfig GetInstance()
        {
            AppConfig appconfig = null; ;
            using (FileStream stream = new FileStream(r_FilePath, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                appconfig = (AppConfig)serializer.Deserialize(stream);
            }
            return appconfig;
        }
    }
}
