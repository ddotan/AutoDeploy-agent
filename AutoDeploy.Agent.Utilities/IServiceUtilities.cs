using System;
namespace AutoDeploy.Agent.Utilities
{
   public interface IServiceUtilities 
    {
        void DeleteService(string i_ServiceName);
        void ExecuteCmdCommand(params string[] i_Commands);
        void InstallService(string i_ServiceName, string i_ExecutablePath, string i_ExeParams);
        bool IsRunning(string i_ServiceName);
        void ResetService(string i_ServiceName, int i_TimeOutMiliSeconds);
        bool ServiceExists(string i_ServiceName);
        void StartService(string i_ServiceName, int i_TimeOutMiliSeconds);
        void StopService(string i_ServiceName, int i_TimeOutMiliSeconds);
    }
}
