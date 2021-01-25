using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;

namespace RUTAS_TEST2
{
    public class WriteExcel:Form1
    {
        string path1;
        string Path2;
        bool[] Holly;
        string RangoDeFechas;
        DateTime DiaInicial;
        DateTime DiaFinal;
        List<string> PerrosJac;
        List<string> PerrosKia;
        public string[] JacState;
        public string[] JacSaleAM;
        public string[] KiaState;
        public string[] KiaSaleAm;



        WorkBook excel;
        WorkSheet Jac_excel;
        WorkSheet Kia_excel;


        int JacStartingRow = 8;
        int KiaStartingRow = 9;

        public WriteExcel(string _path1, string _path2, bool[] _Hollidays, string _RangoDeFechas, DateTime _DiaInicial, DateTime _DiaFinal, List<string> _NuevaListaJac, List<string> _NuevaListaKia, string[] _JacState, string [] _JacSaleAm, string []_KiaState, string[] _KiaSaleAM)
        {
            path1 = @"C:\Users\josed\Downloads\RUTAS DICIEMBRE 2019.xlsx";
            Path2 = _path2;
            Holly = _Hollidays;
            RangoDeFechas = _RangoDeFechas;
            DiaInicial = _DiaInicial;
            DiaFinal = _DiaFinal;
            PerrosJac = _NuevaListaJac;
            PerrosKia = _NuevaListaKia;
            JacState = _JacState;
            JacSaleAM = _JacSaleAm;
            KiaState = _KiaState;
            KiaSaleAm = _KiaSaleAM;

            

            Console.WriteLine("El path de lectura Write Excel = " + path1);
            excel = WorkBook.Load("RUTAS DICIEMBRE 2019.xlsx");

            Jac_excel = excel.GetWorkSheet("JAC");
            Kia_excel = excel.GetWorkSheet("KIA");

            


            ExcelClear();
            printDateRange();
            PrintJac();
            //PrintKia();
            SaveAndClose();

        }


        private void printDateRange()
        {
            Jac_excel["A5"].Value = RangoDeFechas;
            Kia_excel["A5"].Value = RangoDeFechas;

        }

        private void PrintJac()
        {
            #region Imprimir los perros
            foreach (string dog in PerrosJac)
            {
                Jac_excel.SetCellValue(JacStartingRow, 0, dog);
                JacStartingRow++;
            }
            JacStartingRow = 6;
            #endregion


            #region Imprimir Estados
            JacStartingRow = 7;

            foreach (string state in JacState)
            {
                Jac_excel.SetCellValue(JacStartingRow, 2, state);
                JacStartingRow++;
            }

            #endregion
        }











            private void PrintKia()
        {

      


        }

        private void ExcelClear()
        {
            #region JAC
            for (int a = 0; a < 15; a++)
            {
                for (int i = 5; i < 40; i++)
                {
                    Jac_excel.SetCellValue(i, a, "");
                }
            }
            #endregion

            #region KIA
            for (int a = 0; a < 15; a++)
            {
                for (int i = 5; i < 40; i++)
                {
                    Kia_excel.SetCellValue(i, a, "");
                }
            }

            #endregion
        }
        private void SaveAndClose()
        {
            excel.SaveAs(Path2 + @"\Rutas.xlsx");
            excel.Close();

        }


    }
}
