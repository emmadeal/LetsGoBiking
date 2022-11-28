using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RootingService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "findPaths?origin={origin}&destination={destination}")]
        string GetItinerary(string origin, string destination);

    }

    [DataContract]
    public class CompositeType
    {
        [DataMember]
        public Station station { get; set; }
        [DataMember]
        public DateTime localDate { get; set; }

        [DataMember]
        public string date { get; set; }

        public CompositeType(Station s)
        {
            station = s;
            localDate = DateTime.Now;
            date = localDate.ToString(new CultureInfo("fr-FR"));
        }

        public Station getStation()
        {
            return this.station;
        }

    }
}
