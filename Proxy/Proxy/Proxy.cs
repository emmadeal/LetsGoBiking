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
    public class Proxy : IProxy
    {
        string KEY_JC = "42a5d0191394c5fd5614f98bf07ce0fcfde8fc2d";

        Cache<Objet> proxy = new Cache<Objet>();

        
        public Station GetStationInfo(string contractName, string stationNumber)
        {
            int updateDuration = 60;
            string url = "https://api.jcdecaux.com/vls/v3/stations/" + stationNumber + "?contract=" + contractName + "&apiKey=" + KEY_JC;
            string response = proxy.Get(url, updateDuration).getJson().Replace("\\", string.Empty);
            return JsonSerializer.Deserialize<Station>(response);
        }

        public List<Contract> GetListContract()
        {
            string url = "https://api.jcdecaux.com/vls/v3/contracts?apiKey=" + KEY_JC;
            string response = proxy.Get(url).getJson().Replace("\\", string.Empty);
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
            string url = "https://api.jcdecaux.com/vls/v3/stations?apiKey=" + KEY_JC;
            string response = proxy.Get(url).getJson();
            return JsonSerializer.Deserialize<List<Station>>(response);
        }
    }
}
