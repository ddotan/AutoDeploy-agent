using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDeploy.Agent.Objects
{
    public interface IAppConfig
    {
        void SaveInfo();
        string Name { get; set; }
        string ServiceName { get; set; }
        string InstallationPath { get; set; }
        string ExeParams { get; set; }
        string RemotePath { get; set; }
        string RemotePathUserName { get; set; }
        string RemotePathPassword { get; set; }
        string ExecutablePath { get; set; }
        string BackupPath { get; set; }
        IAppConfig GetInstance();
    }
}
