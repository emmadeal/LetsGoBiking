using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootingService
{
    public class Itineraire
    {
        public List<List<Double>> Etape1 { get; set; }
        public List<Step> Indication1 { get; set; }
        public List<List<Double>> Etape2 { get; set; }
        public List<Step> Indication2 { get; set; }
        public List<List<Double>> Etape3 { get; set; }
        public List<Step> Indication3 { get; set; }
    }
}
