using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BasicHttpBinding binding = new BasicHttpBinding();

            Uri HttpUrl = new Uri("http://localhost:8733/Design_Time_Addresses/Proxy/Proxy/");

            ServiceHost serviceHost = new ServiceHost(typeof(Proxy), HttpUrl);

            serviceHost.AddServiceEndpoint(typeof(IProxy), binding, "");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpsGetEnabled = true;
            smb.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(smb);

            serviceHost.Open();

            Console.ReadLine();

        }
    }
}
