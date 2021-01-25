using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RUTAS_TEST2
{
    public class RutasInfo
    {
        public bool []Hollydays { get;  set; }
        public string Path1 { get; set; }
        public string Path2  { get; set; }
        public string RangodeDias { get; set; }
        public DateTime DiaInicial { get; set; }
        public List<string> ListadePerrosJac { get; set; }
        public List<string> PerrosJacEstado { get; set; }
        public List<string> PerrosJacSaleAM { get; set; }
        public List<string> ListadePerrosKia { get; set; }
        public List<string> PerrosKiaEstado { get; set; }
        public List<string> PerrosKiaSaleAM { get; set; }

    }

}
