using AutoDeploy.Agent.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDeploy.Application.Objects
{
    public class AutoDeployAgent
    {
        public IAutoDeployService Service { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public bool ServiceRunning { get; set; }

        public AutoDeployAgent(IAutoDeployService i_Service)
        {
            Service = i_Service;
            Name = Service.GetName();
            RefreshInfo();
        }
        public void RefreshInfo()
        {
            Version = Service.GetVersion();
            ServiceRunning = Service.ServiceRunning();
        }
    }
}
