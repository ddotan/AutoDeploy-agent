using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace AutoDeploy.Agent.Contract
{
    [ServiceContract]
    public interface IAutoDeployService
    {
        [OperationContract]
        void StartService();
        [OperationContract]
        void StopService();
        [OperationContract]
        string GetVersion();
        [OperationContract]
        bool ServiceExists();
        [OperationContract]
        bool ServiceRunning();
        [OperationContract]
        void Deploy();
        [OperationContract]
        string GetName();


        [OperationContract]
        string GetRemotePathUserName();
        [OperationContract]
        void SetRemotePathUserName(string i_UserName);
        [OperationContract]
        string GetRemotePathPassword();
        [OperationContract]
        void SetRemotePathPassword(string i_Password);
        [OperationContract]

        string GetRemotePath();
        [OperationContract]
        void SetRemotePath(string i_RemotePath);

        [OperationContract]

        string GetAdditionalExeParams();
        [OperationContract]
        void SetAdditionalExeParams(string i_AdditionalParams);

        [OperationContract]
        void SetName(string i_Name);
        [OperationContract]
        void SaveAppConfig();

        [OperationContract]
        string GetServiceName();
        [OperationContract]
        void SetServiceName(string i_ServiceName);
        [OperationContract]
        string GetInstalltionPath();
        [OperationContract]
        void SetInstalltionPath(string i_InstallPath);
    }
}
