using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static System.Collections.Specialized.BitVector32;
using System.Threading.Tasks;

namespace RootingService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        List<Station> stations;

        string KEY_ORS = "5b3ce3597851110001cf6248004f1953f2ae4127bf2018aef32a694e";
        string KEY_JC = "2865f4d44201b4cce8370d3b4b9081bbb21c4963";

        /**
         * Methode REST appelée par le client légé
         * paramètres : 
         *      location : adresse de départ
         *      destination : adresse d'arrivée
         */
        public string findPathsAsync(string location, string destination)
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

            if (this.stations == null)
            {
                this.stations = GetListStationAsync().Result;
            }

            Itineraire itineraire = calculateItineraire(location, destination);

            string json = JsonConvert.SerializeObject(itineraire);
            return json;
        }

        /**
         * Appel OpenRoutService
         * Converti une adresse en une position gps
         */
        async Task<string> convertAdressAsync(string adresse)
        {
            HttpClient client = new HttpClient();
            string responseBody = "";
            //this.wow = adresse;
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.openrouteservice.org/geocode/search?api_key=" + this.KEY_ORS + "&text=" + adresse + "&boundary.country=FR");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return "";
            }
        }

        /**
         * Retourne la station JCDecaux la plus proche du point renseigné 
         * Prend en compte s'il faut un vélo de libre ou un stand emplacement de dépot de libre
         */
        Station GetNearbyStationFrom(double latitude, double longitude, string type)
        {
            double distanceMin = this.stations[0].position.longitude + this.stations[0].position.latitude;
            Station stationCible = this.stations[0];

            foreach (var station in this.stations)
            {
                double a = Math.Abs(Math.Abs(longitude) - Math.Abs(station.position.longitude));
                double b = Math.Abs(Math.Abs(latitude) - Math.Abs(station.position.latitude));
                double distance = a + b;
                // Check des vélo available
                if (type == "start")
                {
                    if (distance < distanceMin && BikeDispo(station))
                    {
                        distanceMin = distance;
                        stationCible = station;
                    }
                }
                else
                {
                    if (distance < distanceMin && StandDispo(station))
                    {
                        distanceMin = distance;
                        stationCible = station;
                    }
                }

            }
            return stationCible;
        }


        /**
         * Appel JCDecaux
         * Retourne la liste des stations de vélo de la ville d'Amiens 
         */
        async Task<List<Station>> GetListStationAsync()
        {
            HttpClient client = new HttpClient();
            string responseBody = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v3/stations?contract=amiens&apiKey=" + this.KEY_JC);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            List<Station> listStation = JsonConvert.DeserializeObject<List<Station>>(responseBody);
            return listStation;

        }

        /**
         * Paramètres : nom du contrat | numéro de la station
         * Appel WebProxyService
         * Retourne une station en fonction de son numéro pour un certain contrat 
         */
        public async Task<Station> GetStationAsync(string contractName, string stationNumber)
        {
            HttpClient client = new HttpClient();

            string responseBody = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8733/Design_Time_Addresses/WebProxyService/ProxyService/Station?stationNumber=" + stationNumber + "&contractName=" + contractName);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            responseBody = responseBody.Replace("\\", string.Empty);
            int size = responseBody.Length;
            responseBody = responseBody.Remove(size - 1, 1);
            responseBody = responseBody.Remove(0, 1);
            Station station = JsonConvert.DeserializeObject<Station>(responseBody);

            return station;
        }


        /**
         * Return true si la station possède des vélos
         */
        Boolean BikeDispo(Station station)
        {
            string name = station.contractName;
            string number = "" + station.number;
            Station response = GetStationAsync(name, number).Result;

            if (response.mainStands.availabilities.bikes != 0)
            {
                return true;
            }
            return false;
        }

        /**
         * Return true si la station possède emplacements pour déposer le vélo
         */
        Boolean StandDispo(Station station)
        {
            string name = station.contractName;
            string number = "" + station.number;
            Station response = GetStationAsync(name, number).Result;

            if (response.mainStands.availabilities.stands != 0)
            {
                return true;
            }
            return false;
        }



        /**
         * Appel OpenRouteService
         * renvoie un object contenant le chemin entre deux points
         * Prend en compte le mode de déplacement (marche ou vélo)
         */
        async Task<OpenRouteService> Pathing(double startLongitude, double startLatitude, double endLongitude, double endLatitude, string type)
        {
            string startLong = ("" + startLongitude).Replace(",", ".");
            string startLat = ("" + startLatitude).Replace(",", ".");
            string endLong = ("" + endLongitude).Replace(",", ".");
            string endLat = ("" + endLatitude).Replace(",", ".");

            HttpClient client = new HttpClient();

            string responseBody = "";
            try
            {
                if (type == "walk")
                {
                    // Marche
                    HttpResponseMessage response = await client.GetAsync("https://api.openrouteservice.org/v2/directions/foot-walking?api_key=" + this.KEY_ORS + "&start=" + startLong + "," + startLat + "&end=" + endLong + "," + endLat);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Velo
                    HttpResponseMessage response = await client.GetAsync("https://api.openrouteservice.org/v2/directions/cycling-regular?api_key=" + this.KEY_ORS + "&start=" + startLong + "," + startLat + "&end=" + endLong + "," + endLat);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            OpenRouteService ors = JsonConvert.DeserializeObject<OpenRouteService>(responseBody);
            return ors;
        }

        /**
         * Retourne un objet itineraire avec tous les détails d'un trajet (indication de direction et chemin)
         * Paramètres : 
         *      location : adresse de départ 
         *      destination : adresse d'arrivée
         */
        public Itineraire calculateItineraire(string location, string destination)
        {
            //Converti adresse en json avec les informations de position
            string location_json = convertAdressAsync(location).Result;
            string destination_json = convertAdressAsync(destination).Result;

            //Parse pour récupérer l'objet
            dynamic location_object = JsonConvert.DeserializeObject(location_json);
            dynamic destination_object = JsonConvert.DeserializeObject(destination_json);

            //Affectation des latitudes longitudes pour le départ et l'arrivée
            double locationLatitude = location_object.features[0].geometry.coordinates[1];
            double locationLongitude = location_object.features[0].geometry.coordinates[0];
            double destinationLatitude = destination_object.features[0].geometry.coordinates[1];
            double destinationLongitude = destination_object.features[0].geometry.coordinates[0];

            //Récupère la station la plus proche du départ (stationA) et la plus proche de l'arrivée (stationB)
            Station stationA = GetNearbyStationFrom(locationLatitude, locationLongitude, "start");
            Station stationB = GetNearbyStationFrom(destinationLatitude, destinationLongitude, "end");

            //Affectation des latitudes longitudes des stations 
            double stationA_longitude = stationA.position.longitude;
            double stationA_latitude = stationA.position.latitude;
            double stationB_longitude = stationB.position.longitude;
            double stationB_latitude = stationB.position.latitude;

            //Initialisation des trois segments du trajet (marche | velo | marche) sous forme d'objet OpenRouteService (cf classe pour plus de détails)

            //Segment 1 : Départ -> StationA (marche)
            OpenRouteService start_stationA = Pathing(locationLongitude, locationLatitude, stationA_longitude, stationA_latitude, "walk").Result;
            List<List<double>> etapeUn = start_stationA.features[0].geometry.coordinates;
            List<Step> indicationUn = start_stationA.features[0].properties.segments[0].steps;

            //Segment 2 : StationA -> StationB (velo)
            OpenRouteService stationA_stationB = Pathing(stationA_longitude, stationA_latitude, stationB_longitude, stationB_latitude, "bike").Result;
            List<List<double>> etapeDeux = stationA_stationB.features[0].geometry.coordinates;
            List<Step> indicationDeux = stationA_stationB.features[0].properties.segments[0].steps;

            //Segment 3 : StationB -> arrivée (marche)
            OpenRouteService stationB_end = Pathing(stationB_longitude, stationB_latitude, destinationLongitude, destinationLatitude, "walk").Result;
            List<List<double>> etapeTroix = stationB_end.features[0].geometry.coordinates;
            List<Step> indicationTrois = stationB_end.features[0].properties.segments[0].steps;

            //Ajout des traces pour les statistiques
            Statistique.addReport(new Report(stationA));
            Statistique.addReport(new Report(stationB));

            //Initialisation de l'objet Itineraire qui sera return
            Itineraire itineraire = new Itineraire
            {
                Etape1 = etapeUn,
                Indication1 = indicationUn,
                Etape2 = etapeDeux,
                Indication2 = indicationDeux,
                Etape3 = etapeTroix,
                Indication3 = indicationTrois,
            };

            return itineraire;
        }

        /**
         * Retourne toutes les statistiques récupérées
         */
        public List<Report> getGlobalStat()
        {
            return Statistique.globalStatistique();
        }

        public List<Report> getStationStat(string number)
        {
            return Statistique.stationStatistique(number);
        }
    }
}
}
