using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Xls;

namespace RUTAS_TEST2
{
    
    public class WriteExcel:Form1
    {
        private Success success;

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


        Workbook excel;
        Worksheet Jac_excel;
        Worksheet Kia_excel;


        //WorkBook excel;
        //WorkSheet Jac_excel;
        //WorkSheet Kia_excel;


        int JacStartingRow = 8;
        int KiaStartingRow = 9;

        public WriteExcel(string _path1, string _path2, bool[] _Hollidays, string _RangoDeFechas, DateTime _DiaInicial, DateTime _DiaFinal, List<string> _NuevaListaJac, List<string> _NuevaListaKia, string[] _JacState, string [] _JacSaleAm, string []_KiaState, string[] _KiaSaleAM)
        {
            #region VARIABLES
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


            //excel = WorkBook.Load("RUTAS DICIEMBRE 2019.xlsx");

            //Jac_excel = excel.GetWorkSheet("JAC");
            //Kia_excel = excel.GetWorkSheet("KIA");


            excel = new Workbook();

            excel.LoadFromFile("RUTAS DICIEMBRE 2019.xlsx");

            Jac_excel = excel.Worksheets[0];
            Kia_excel = excel.Worksheets[1];


            #endregion





            ExcelClear();
            WhiteCells();
            printDateRange();
            Print_Labels();
            EachDayPrint();
            SetHollidays();
            PrintJac();
            PrintKia();
            SaveAndClose();

        }

       


        private void ExcelClear()
        {
            #region JAC
            for (int a = 1; a < 15; a++)
            {
                for (int i = 6; i < 40; i++)
                {
                    Jac_excel.SetCellValue(i, a, "");
                }
            }

            

            #endregion

            #region KIA
            for (int a = 1; a < 15; a++)
            {
                for (int i = 6; i < 40; i++)
                {
                    Kia_excel.SetCellValue(i, a, "");
                }
            }

            #endregion
        }
        private void WhiteCells()
        {


            #region JAC
            var Label_range = Jac_excel.Range["A6:N6"];
            var Page_range = Jac_excel.Range["A8:O60"];


            var range = Page_range;

            foreach (var cell in range)
            {
                if (cell.Style.Interior.Color != Color.White)
                {
                    cell.Style.Interior.Color = Color.White;
                }
            }

            range = Label_range;

            foreach (var cell in range)
            {
                cell.Style.Color = Color.DarkKhaki;
            }

            #endregion


            #region KIA

            Page_range = Kia_excel.Range["A8:O43"];


            range = Page_range;

            foreach (var cell in range)
            {
                if(cell.Style.Color != Color.White)
                {
                    cell.Style.Color = Color.White;
                }
            }

            range = Kia_excel.Range["A6:P6"];

            foreach (var cell in range)
            {
                cell.Style.Color = Color.DarkKhaki;
            }


            #endregion
        }
        private void printDateRange()
        {
            Jac_excel["A5"].Value = RangoDeFechas;
            Kia_excel["A5"].Value = RangoDeFechas;

        }
        private void Print_Labels()
        {
            Jac_excel["A6"].Value = "NOMBRE DEL PERRO";
            Jac_excel["A6"].Style.Font.IsBold = true;
            Kia_excel["A6"].Value = "NOMBRE DEL PERRO";
            Kia_excel["A8"].Value = "RUTA CHÍA";
            Kia_excel["A8"].Style.Color = Color.Yellow;
            Kia_excel["A6:A8"].Style.Font.IsBold = true;

        }

        private void EachDayPrint()
        {
            DateTime CurrentDate;

            double a = 0;


            for (int column = 2; column < 16; column += 2)
            {
                CurrentDate = DiaInicial.AddDays(Convert.ToDouble(a));
                Jac_excel.SetCellValue(6, column, ((CurrentDate.ToString("dddd")) + " " + (CurrentDate.ToString("dd"))));
                Kia_excel.SetCellValue(6, column, ((CurrentDate.ToString("dddd")) + " " + (CurrentDate.ToString("dd"))));
                a += 1d;
            }



        }
        private void SetHollidays()
        {
            

            if (Holly[0] == true)
            {
                Console.WriteLine("Lunes Festivo");
                ChangeHollyColors("B6:C43" , "B6:C26");
            }


            if (Holly[1] == true)
            {
                Console.WriteLine("Martes Festivo");
                ChangeHollyColors("D6:E43", "D6:E26");

            }
            if (Holly[2] == true)
            {
                Console.WriteLine("Miercoles Festivo");
                ChangeHollyColors("F6:G43", "F6:G26");

            }
            if (Holly[3] == true)
            {
                Console.WriteLine("Jueves Festivo");
                ChangeHollyColors("H6:I43", "H6:I26");

            }
            if (Holly[4] == true)
            {
                Console.WriteLine("Viernes Festivo");
                ChangeHollyColors("J6:K43", "J6:K26");

            }
            if (Holly[5] == true)
            {
                Console.WriteLine("Sabado Festivo");
                ChangeHollyColors("L6:M43", "L6:M26");

            }













        }



        private void PrintJac()
        {
            int i = JacStartingRow;
            #region IMPRIMIR LOS PERROS

            foreach (string dog in PerrosJac)
            {
                Jac_excel.SetCellValue(i, 1, dog);
                
                i++;
            }

            #endregion

            #region IMPRIMIR ESTADOS

            i = JacStartingRow;


            foreach (string state in JacState)
            {
                Jac_excel.SetCellValue(i, 3, state);
                i++;
            }

            #endregion
                        

            
            #region NOTA
            i = JacStartingRow;

            foreach (string nota in JacSaleAM)
            {
                if(nota != null)
                {

                    Jac_excel.SetCellValue(i, 2, nota);
                }
                i++;
            }

            #endregion

            var RangeToSyle = Jac_excel.Range["A8:C43"];

            foreach(var cell in RangeToSyle)
            {
                if(cell.Value != null)
                {
                    cell.Style.Font.IsBold = true;
                }
            }


        }

        private void PrintKia()
        {
            int i = KiaStartingRow;
            #region IMPRIMIR LOS PERROS

            foreach (string dog in PerrosKia)
            {
                Kia_excel.SetCellValue(i, 1, dog);
                i++;
            }

            #endregion


            #region IMPRIMIR ESTADOS

            i = KiaStartingRow;


            foreach (string state in KiaState)
            {
                Kia_excel.SetCellValue(i, 3, state);
                i++;
            }

            #endregion


            #region NOTA
            i = JacStartingRow;

            foreach (string nota in KiaSaleAm)
            {
                if(nota != null)
                {

                    Kia_excel.SetCellValue(i, 2, nota);
                }
                i++;
            }


            #endregion

            var RangeToSyle = Kia_excel.Range["A9:C43"];

            foreach (var cell in RangeToSyle)
            {
                if (cell.Value != null)
                {
                    cell.Style.Font.IsBold = true;
                }
            }


        }


        private void ChangeHollyColors(string JacRange, string KiaRange)
        {
            var Jac_Range = Jac_excel.Range[JacRange];
            var Kia_Range = Kia_excel.Range[KiaRange];


                foreach (var cell in Jac_Range)
                {
                    cell.Style.Color = Color.Yellow;
                }
                foreach (var cell in Kia_Range)
                {
                    cell.Style.Color = Color.Yellow;
                }



        }




        private void FileManager()
        {

        }
        private void SaveAndClose()
        {
            excel.SaveToFile(Path2 + @"\Rutas.xlsx");


            success = new Success(Path2);
            success.ShowDialog();

        }

    }
}
