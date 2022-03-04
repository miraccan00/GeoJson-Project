using System;
using System.Collections.Generic;

namespace Geomap.Models
{
    public partial class GeoTable1
    {
        public int Geoid { get; set; } // auto increment
        public string Id { get; set; } // features.id
        public string Geometry { get; set; } // features.geometry.coordinates.ToString() ! bu sayfada array olarak convert edilicek 
        public int? Propid { get; set; } // //features.properties.id
        public string Paftaadi { get; set; } // features.properties.PaftaAdi
        public string Long { get; set; } // features.properties.long
        public string Lat { get; set; } // features.properties.lat
        public int? Zo { get; set; } // features.properties.zo
        public string Sp { get; set; } // features.properties.sp.ToString() ! decimal cevirilecek
        public string Cur { get; set; } // features.properties.cur.ToString() ! integer cevirilecek
        public int? Ber { get; set; } // features.properties.ber ! önüne - konulacak( hepsinde var mı bilmiyorum )
        public string Kmetin { get; set; } // features.properties.KMetin
        public string Ometin { get; set; } // features.properties.OMetin
        public string Umetin { get; set; } // features.properties.UMetin
    }
    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }
    public class Properties
    {
        public int id { get; set; }
        public string PaftaAdi { get; set; }
        public string @long { get; set; }
        public string lat { get; set; }
        public int zo { get; set; }
        public double sp { get; set; }
        public int cur { get; set; }
        public int ber { get; set; }
        public string KMetin { get; set; }
        public string OMetin { get; set; }
        public string UMetin { get; set; }
    }
    public class Feature
    {
        public string type { get; set; }
        public string id { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
}
