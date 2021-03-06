﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace AutoDeploy.Application.Utilities
{
    public class WCFUtilities
    {
        public static class ServiceFactory<T> where T : class
        {
            private static T m_Service;

            public static  T GetService(string i_Address)
            {
                return m_Service ?? (m_Service = GetServiceInstance(i_Address));
              
            }

            private static T GetServiceInstance(string i_Address)
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress endpoint = new EndpointAddress(i_Address);

                return ChannelFactory<T>.CreateChannel(binding, endpoint);
            }
        }
    }
}
