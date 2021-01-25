using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SpreadsheetLight;

namespace RUTAS_TEST2
{
    class ReadingExcel
    {
        public List<string> PerrosJac = new List<string>();
        public List<string> PerrosKia = new List<string>();
        public ReadingExcel(string path)
        {
            int JacRow = 8;
            int KiaRow = 10;

            SLDocument RutaJac = new SLDocument(path, "JAC");
            SLDocument RutaKia = new SLDocument(path, "KIA");
            
            

            while (!string.IsNullOrEmpty(RutaJac.GetCellValueAsString(JacRow, 1)))
            {
                PerrosJac.Add(RutaJac.GetCellValueAsString(JacRow, 1));
                JacRow++;
            }

            while (!string.IsNullOrEmpty(RutaKia.GetCellValueAsString(KiaRow, 1)) )
            {
                PerrosKia.Add(RutaKia.GetCellValueAsString(KiaRow, 1));
                KiaRow++;

            }


            RutaJac.CloseWithoutSaving();
            RutaKia.CloseWithoutSaving();



        }
    }
}
