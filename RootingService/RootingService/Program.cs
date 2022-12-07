using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace RootingService
{
    class Program
    {
        public static void Main(string[] args)
        {
            BasicHttpBinding binding = new BasicHttpBinding();

            Uri HttpUrl = new Uri("http://localhost:8733/Design_Time_Addresses/RootingService/Service1/");

            ServiceHost serviceHost = new ServiceHost(typeof(Service1), HttpUrl);

            serviceHost.AddServiceEndpoint(typeof(IService1), binding, "");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpsGetEnabled = true;
            smb.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(smb);

            serviceHost.Open();

            Console.ReadLine();

        }
    }
}
