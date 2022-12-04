using System;
using System.Threading.Tasks;
using System.Net.Http;
using RootingService.ServiceReference1;
using System.Text.Json;
using System.Collections.Generic;
using System.Device.Location;

namespace RootingService
{
   public class Service1 : IService1
    {
         
        string KEY_ORS = "5b3ce3597851110001cf6248163f597ef3934a9eb52bb07f63f06669";
        string KEY_GH = "759bc262-11f0-49da-bc17-986ebf79ce1c";


        ProxyClient client = new ProxyClient();
        public Itineraire GetItineraire(string origin, string destination)
        {

            Itineraire itineraire = calculeItineraire(origin, destination);

            return itineraire;
            
        }

        


        /**
         * Retourne un objet itineraire avec tous les détails d'un trajet (indication de direction et chemin)
         * Paramètres : 
         *      location : adresse de départ 
         *      destination : adresse d'arrivée
         */
        public Itineraire calculeItineraire(string origin, string destination)
        {
            //En cas d'erreur, on retourne cet itinéraire
            Itineraire erreur = new Itineraire(true, false, null, null, null);

            //Converti adresse en json avec les informations de position
            string origin_json = ConvertAdress(origin).Result;
            string destination_json = ConvertAdress(destination).Result;

            //Deserialize pour récupérer les coordonnées des adresses de départ et d'arrivée
            Places origin_places;
            Places destination_places;
            try
            {
                origin_places = JsonSerializer.Deserialize<Places>(origin_json);
                destination_places = JsonSerializer.Deserialize<Places>(destination_json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return erreur;
            }


            //Affectation des latitudes longitudes pour le départ et l'arrivée
            double origin_latitude;
            double origin_longitude;
            if (origin_places.hits.Length > 0)
            {
                origin_latitude = origin_places.hits[0].point.lat;
                origin_longitude = origin_places.hits[0].point.lng;

            }
            else
            {
                return erreur;
            }

            double destination_latitude;
            double destination_longitude;
            if (destination_places.hits.Length > 0)
            {
                destination_latitude = destination_places.hits[0].point.lat;
                destination_longitude = destination_places.hits[0].point.lng;

            }
            else
            {
                return erreur;
            }

            //Récupère la station la plus proche du départ (stationA) et la plus proche de l'arrivée (stationB)
            GeoCoordinate origin_coordinate = new GeoCoordinate(origin_latitude, origin_longitude);
            GeoCoordinate destination_coordinate = new GeoCoordinate(destination_latitude, destination_longitude);
            double distance_origin_min = -1;
            double distance_destination_min = -1;

            Station stationA = null;
            Station stationB = null;
            try
            {
                Contract[] contracts = GetContracts().Result;
                foreach (Contract c in contracts)
                {
                    var stations = GetStations(c.name).Result;
                    foreach (Station s in stations)
                    {

                        GeoCoordinate s_coordinate = new GeoCoordinate(s.position.latitude, s.position.longitude);
                        double distance_origin = s_coordinate.GetDistanceTo(origin_coordinate);
                        double distance_destination = s_coordinate.GetDistanceTo(destination_coordinate);


                        // Check des vélo available

                        if ((distance_origin_min == -1 || distance_origin <= distance_origin_min) && BikeDispo(s))
                        {
                            distance_origin_min = distance_origin;
                            stationA = s;
                        }


                        if ((distance_destination_min == -1 || distance_destination < distance_destination_min) && StandDispo(s))
                        {
                            distance_destination_min = distance_destination;
                            stationB = s;
                        }
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            //Affectation des latitudes longitudes des stations 
            double stationA_longitude = stationA.position.longitude;
            double stationA_lattitude = stationA.position.latitude;
            double stationB_longitude = stationB.position.longitude;
            double stationB_lattitude = stationB.position.latitude;

            //Initialisation des trois segments du trajet (marche | velo | marche) sous forme d'objet OpenRouteService (cf classe pour plus de détails)

            Etape Etape1;
            Etape Etape2;
            Etape Etape3;
            try
            {
                //Segment 1 : Départ -> StationA (marche)
                string itineraire1_json = Pathing(origin_longitude, origin_latitude, stationA_longitude, stationA_lattitude, "marche").Result;
                Etape1 = JsonSerializer.Deserialize<Etape>(itineraire1_json);
                
                //Segment 2 : StationA -> StationB (velo)
                string itineraire2_json = Pathing(stationA_longitude, stationA_lattitude, stationB_longitude, stationB_lattitude, "velo").Result;
                Etape2 = JsonSerializer.Deserialize<Etape>(itineraire2_json);

                //Segment 3 : StationB -> arrivée (marche)
                string itineraire3_json = Pathing(stationB_longitude, stationB_lattitude, destination_longitude, stationB_lattitude, "marche").Result;
                Etape3 = JsonSerializer.Deserialize<Etape>(itineraire3_json);

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return erreur;
            }

            int temps_velo = Etape1.paths[0].time + Etape2.paths[0].time + Etape3.paths[0].time;
            bool utile = IsUtile(origin_longitude, origin_latitude, destination_longitude, destination_latitude, temps_velo);

            //Retourne l'objet Itineraire avec les étape 1, 2 et 3
            return new Itineraire(false, true, Etape1, Etape2, Etape3);

        }

        /**
         * Appel OpenRouteService
         * Converti une adresse en une position gps
         */
        async Task<string> ConvertAdress(string adresse)
        {
            HttpClient client = new HttpClient();
            string responseBody;
           
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://graphhopper.com/api/1/geocode?q=" + adresse + "&locale=fr&key=" + KEY_GH);
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
        /*Station[] GetStationProche(double origin_latitude, double origin_longitude, double destination_latitude, double destination_longitude)
        {
            GeoCoordinate origin_coordinate = new GeoCoordinate(origin_latitude, origin_longitude);
            GeoCoordinate destination_coordinate = new GeoCoordinate(destination_latitude, destination_longitude);
            double distance_origin_min = -1;
            double distance_destination_min = -1;

            Station[] stationProche = null;

            try
            {

                Contract[] contracts = GetContracts().Result;
                foreach (Contract c in contracts)
                {
                    var stations = GetStations(c.name).Result;
                    foreach (Station s in stations)
                    {

                        GeoCoordinate s_coordinate = new GeoCoordinate(s.position.latitude, s.position.longitude);
                        double distance_origin = s_coordinate.GetDistanceTo(origin_coordinate);
                        double distance_destination = s_coordinate.GetDistanceTo(origin_coordinate);


                        // Check des vélo available
                        
                        if ((distance_origin_min == -1 || distance_origin <= distance_origin_min) && BikeDispo(s))
                        {
                            distance_origin_min = distance_origin;
                            stationProche[0] = s;
                        }
                        
                        
                        if (distance_destination < distance_destination_min && StandDispo(s))
                        {
                            distance_destination_min = distance_destination;
                            stationProche[1] = s;
                        }
                    }
                }
            
            } catch (AggregateException e) {
                Console.WriteLine(e.Message);
            }

            return stationProche;
        }*/



        async Task<Contract[]> GetContracts()
        {
            Contract[] response = await client.GetListContractAsync();
            return response;
        }
        async Task<Station[]> GetStations(string contractName)
        {
            var response = await client.GetListStationAsync(contractName);
            return response;
        }


        /**
         * Appel OpenStreetMap
         * renvoie un object contenant le chemin entre deux points
         * Prend en compte le mode de déplacement (marche ou vélo)
         */
        async Task<string> Pathing(double originLongitude, double originLatitude, double destinationLongitude, double destinationLatitude, string type)
        {
            string startLong = ("" + originLongitude).Replace(",", ".");
            string startLat = ("" + originLatitude).Replace(",", ".");
            string endLong = ("" + destinationLongitude).Replace(",", ".");
            string endLat = ("" + destinationLatitude).Replace(",", ".");

            HttpClient client = new HttpClient();

            string responseBody = "";
            try
            {
                if (type == "marche")
                {
                    // Marche
                    //HttpResponseMessage response = await client.GetAsync("https://api.openrouteservice.org/v2/directions/foot-walking?api_key=" + this.KEY_ORS + "&start=" + startLong + "," + startLat + "&end=" + endLong + "," + endLat);
                    HttpResponseMessage response = await client.GetAsync("https://graphhopper.com/api/1/route?vehicle=foot" + "&locale=fr&key=" + KEY_GH + "&type=json&points_encoded=false&point=" + startLat + "," + startLong + "&point=" + endLat + "," + endLong);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Velo
                    //HttpResponseMessage response = await client.GetAsync("https://api.openrouteservice.org/v2/directions/cycling-regular?api_key=" + this.KEY_ORS + "&start=" + startLong + "," + startLat + "&end=" + endLong + "," + endLat);
                    HttpResponseMessage response = await client.GetAsync("https://graphhopper.com/api/1/route?vehicle=bike" + "&locale=fr&key=" + KEY_GH + "&type=json&points_encoded=false&point=" + startLat + "," + startLong + "&point=" + endLat + "," + endLong);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return responseBody;
        }

        public bool IsUtile(double originLongitude, double originLattitude, double destinationLongitude, double destinationLattitude, int temps_velo)
        {            
            string itineraire_json = Pathing(originLongitude, originLattitude, destinationLongitude, destinationLattitude, "marche").Result;
            Etape etape = JsonSerializer.Deserialize<Etape>(itineraire_json);

            int temps_marche = etape.paths[0].time;

            if(temps_marche > temps_velo)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        /**
         * Return true si la station possède des vélos
         */
        Boolean BikeDispo(Station station)
        {
            if (station.totalStands.availabilities.bikes != 0)
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
            if (station.totalStands.availabilities.stands != 0)
            {
                return true;
            }
            return false;
        }



        

    }
}
