using AutoDeploy.Agent.BusinessLogic;
using AutoDeploy.Agent.Services;
using AutoDeploy.Application.DataFileAccess;
using AutoDeploy.Application.Objects;
using AutoDeploy.Application.Utilities;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDeploy.Application.Engine
{
    public class AutoDeployManager
    {
        public List<AutoDeployAgent> Agents = new List<AutoDeployAgent>();

        private List<IAutoDeployService> GetAgentServices()
        {

            List<EndpointInfo> endPoints = EndpointRepository.GetEndPoints();
            List<IAutoDeployService> AutoDeployServices = new List<IAutoDeployService>();
            foreach (EndpointInfo endPoint in endPoints)
            {
                try
                {
                    AutoDeployServices.Add(WCFUtilities.ServiceFactory<IAutoDeployService>.GetService(endPoint.Address));
                    LogManager.Instance.WriteInfo("EndPoint Added : " + endPoint.Address);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteError("Couldnt add EndPoint : " + endPoint.Address + " Error Message : " + ex.Message + @"** \n You should check Endpoint address at Config\Agents.xml");

                }
            }
            return AutoDeployServices;
        }
        public AutoDeployManager()
        {
            List<IAutoDeployService> agentsServices = GetAgentServices();
            foreach (IAutoDeployService service in agentsServices)
            {
                try
                {
                    Agents.Add(new AutoDeployAgent(service));
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteError("Error occured while trying to connect to  endpoint , Error : " + ex.Message);
                }
            }

        }
    }
}
