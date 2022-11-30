using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Threading.Tasks;


namespace Proxy
{
    public class Station
    {
        public int Number { get; set; }
        public string ContractName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Position Position { get; set; }
        public bool Banking { get; set; }
        public bool Bonus { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Connected { get; set; }
        public bool Overflow { get; set; }
        public object Shape { get; set; }
        public TotalStands TotalStands { get; set; }
        public MainStands MainStands { get; set; }
        public object OverflowStands { get; set; }

    }

    public class Position
    {
        public double Lattitude { get; set; }
        public double Longitude { get; set; }

    }

    public class TotalStands
    {
        public Avaibilities Avaibilities { get; set; }
        public int Capacity { get; set; }

    }

    public class MainStands
    {
        public Avaibilities availabilities { get; set; }
        public int capacity { get; set; }
    }

    public class Avaibilities
    {
        public int Bikes { get; set; }
        public int Stands { get; set; }
        public int MechanicalBikes { get; set; }
        public int ElectricalBikes { get; set; }
        public int ElectricalInternalBatteryBikes { get; set; }
        public int ElectricalRemovableBatteryBikes { get; set; }
    }

    public class Contract
    {
        public string Name { get; set; }

    }

    class Objet
    {
        string json;

        public Objet(string url)
        {
            this.json = GetContracts(url).Result;
        }

        public async Task<String> GetContracts(string url)
        {
            HttpClient client = new HttpClient();
            string responseBody = "";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);

            }

            return responseBody;
        }

        public string getJson()
        {
            return this.json;
        }
    }

    

}
