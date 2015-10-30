using AutoDeploy.Application.Objects;
using AutoDeploy.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AutoDeploy.Application.DataFileAccess
{
    public class EndpointRepository
    {
        private static readonly string r_FilePath = AppDomain.CurrentDomain.BaseDirectory + "Config\\Agents.xml";
        public static List<EndpointInfo>GetEndPoints()
        {
            return XmlUtilities.Serilize<List<EndpointInfo>>(r_FilePath);
        }
    }
}
