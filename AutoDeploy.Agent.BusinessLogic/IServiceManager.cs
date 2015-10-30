using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDeploy.Agent.BusinessLogic
{
   public interface IServiceManager
    {
         void InstallService();

         void DeleteService();
     
         bool ServiceRunning();
      
         bool ServiceExists();
      
         void StartService();

         void StopService();
         string GetServiceName();
    }
}
