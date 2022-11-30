using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Text.Json;

namespace Proxy
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        string KEY_ORS = "5b3ce3597851110001cf6248163f597ef3934a9eb52bb07f63f06669";
        string KEY_JC = "42a5d0191394c5fd5614f98bf07ce0fcfde8fc2d";

        Cache<Objet> proxy = new Cache<Objet>();

        
        //Get the json of a station
        public Station GetStationInfo(string contractName, string stationNumber)
        {
            //Mise à jour des jsons représentant les stations toutes les 60s
            int updateDuration = 60;
            string url = "https://api.jcdecaux.com/vls/v3/stations/" + stationNumber + "?contract=" + contractName + "&apiKey=" + KEY_JC;
            string response = proxy.Get(url, updateDuration).getJson();
            return JsonSerializer.Deserialize<Station>(response);
        }

        public List<Contract> GetListContract()
        {
            string url = "https://api.jcdecaux.com/vls/v3/contracts?" + "apiKey=" + KEY_JC;
            string response = proxy.Get(url).getJson();
            return JsonSerializer.Deserialize<List<Contract>>(response);
        }

        public List<Station> GetListStation(string contractName)
        {
            string url = "https://api.jcdecaux.com/vls/v3/stations?contract=" + contractName + "&apiKey=" + KEY_JC;
            string response = proxy.Get(url).getJson();
            return JsonSerializer.Deserialize<List<Station>>(response);
        }


        public List<Station> GetStations()
        {
            string url = "https://api.jcdecaux.com/vls/v3/stations?" + "apiKey=" + KEY_JC;
            string response = proxy.Get(url).getJson();
            return JsonSerializer.Deserialize<List<Station>>(response);
        }
    }
}
