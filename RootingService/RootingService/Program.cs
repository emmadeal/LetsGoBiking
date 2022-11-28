﻿using System;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Net.Http;

namespace RootingService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Create a URI to serve as the base address
            //Be careful to run Visual Studio as Admistrator or to allow VS to open new port netsh command. 
            // Example : netsh http add urlacl url=http://+:80/MyUri user=DOMAIN\user
            Uri httpUrl = new Uri("https://api.openrouteservice.org/geocode/search?api_key=5b3ce3597851110001cf624857ddfd522faa498cb4d1d74518230dff&text=");

            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(Service1), httpUrl);

            // Multiple end points can be added to the Service using AddServiceEndpoint() method.
            // Host.Open() will run the service, so that it can be used by any client.

            // Example adding :
            // Uri tcpUrl = new Uri("net.tcp://localhost:8090/MyService/SimpleCalculator");
            // ServiceHost host = new ServiceHost(typeof(MyCalculatorService.SimpleCalculator), httpUrl, tcpUrl);

            //Add a service endpoint
            host.AddServiceEndpoint(typeof(IService1), new WSHttpBinding(), "");

            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            //Start the Service
            host.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");

            // Exemple : https://nominatim.openstreetmap.org/search/Unter%20den%20Linden%201%20Berlin?format=json&addressdetails=1&limit=1&polygon_svg=1
            //string url = "https://nominatim.openstreetmap.org/search/";
            //https://nominatim.openstreetmap.org/search?q=%2257%20Avenue%20de%20la%20gare%2006800%20Cagnes%20sur%20mer%22


            /*
            string url = "https://api.openrouteservice.org/geocode/search?api_key=5b3ce3597851110001cf624857ddfd522faa498cb4d1d74518230dff&text=";

            HttpClient client = new HttpClient();
            response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
            

            string adress = "57 avenue de la gare Cagnes sur mer";
            string result1 = OSMAPICall(url + formatUrl(adress)).Result;

            adress = "930 Rte des Colles, 06410 Biot";
            string result2 = OSMAPICall(url + formatUrl(adress)).Result;

            Console.WriteLine("My result" + result1);
            Console.ReadLine();

            //Test feature = JsonSerializer.Deserialize<Test>(result1);
            //Console.WriteLine("my feature : " + feature.ToString());

            Console.WriteLine("My result" + result2);
            Console.ReadLine();
            */


        }

        static public string formatUrl(string adress)
        {
            string url = "";
            foreach (char c in adress)
            {
                if (c == ' ')
                {
                    url = url + "%";
                    url = url + "2";
                    url = url + "0";
                }
                else
                {
                    url = url + c;
                }
            }
            Console.WriteLine(url);
            Console.ReadLine();
            return url;
        }

       
    }

    
}
