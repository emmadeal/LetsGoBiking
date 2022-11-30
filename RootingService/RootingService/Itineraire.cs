using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RootingService
{
    [DataContract]
    public class Itineraire
    {
        [DataMember]
        public Etape Etape1 { get; set; }
        
        [DataMember]
        public Etape Etape2 { get; set; }
        [DataMember]
        public Etape Etape3 { get; set; }
        [DataMember]
        public bool Erreur { get; set; }
        [DataMember]
        public bool Utile { get; set; }


        public Itineraire(bool Erreur, bool Utile, Etape Etape1, Etape Etape2, Etape Etape3)
        {
            this.Erreur = Erreur;
            this.Utile = Utile;
            this.Etape1 = Etape1;
            this.Etape2 = Etape2;
            this.Etape3 = Etape3;

        }
    }

    [DataContract]
    public class Etape
    {
        [DataMember]
        public Chemin[] Chemins { get; set; }

    }

    [DataContract]
    public class Chemin
    {
        [DataMember]
        public double Distance { get; set; }
        [DataMember]
        public int Temps { get; set; }
        [DataMember]
        public List<Instruction> Instruction { get; set; }

    }

    [DataContract]
    public class Instruction
    {
        [DataMember]
        public string Texte { get; set; }
        [DataMember]
        public double Distance { get; set; }

    }

    public class Place
    {
        public string Nom { get; set; }
        public Position Position { get; set; }
    }

    public class Position
    {
        public double Longitude { get; set; }
        public double Lattitude { get; set; }

    }

    public class Places
    {
        public Place[] Hits { get; set; }

    }

}
