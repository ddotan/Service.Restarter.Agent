﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Restarter.Dashboard.Utilities
{
    public static class WCFUtils
    {
        public static class ServiceFactory<T> where T : class
        {
            //private static T m_Service;

            public static T GetService(string i_Address)
            {
                return  GetServiceInstance(i_Address);

            }

            private static T GetServiceInstance(string i_Address)
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.OpenTimeout = new TimeSpan(0, 5, 0);
                binding.CloseTimeout = new TimeSpan(0, 5, 0);
                binding.SendTimeout = new TimeSpan(0, 5, 0);
                EndpointAddress endpoint = new EndpointAddress(i_Address);
                return ChannelFactory<T>.CreateChannel(binding, endpoint);
            }
        }
    }
}
