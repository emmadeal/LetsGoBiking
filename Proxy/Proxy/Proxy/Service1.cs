using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Proxy
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        Service1<JCDecaux> proxy = new Service1<JCDecaux>();
        //Get the json of a station
        public string GetStationInfo(string contractName, string stationNumber)
        {
            //Mise à jour des jsons représentant les stations toutes les 60s
            int updateDuration = 60;
            string urlStation = "https://api.jcdecaux.com/vls/v3/stations/" + stationNumber + "?contract=" + contractName + "&apiKey=39571097c1e9b087e872bf8c82780a117c246f85";
            return proxy.Get(urlStation, updateDuration).getJson();
        }
    }
}
