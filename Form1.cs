using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace RUTAS_TEST2
{
    public partial class Form1 : Form
    {
        RutasInfo rutasInfo;

        Bienvenida bienvenida;
        //Bienvenida bienvenida;
        public static string _path1;
        public string Path1;
        public static string Path2;
        public static DateTime DiaInicial;
        public static DateTime DiaFinal;

        public static string Rangodefechas;

        public static bool isTheFirstTime;
        


        public bool[] Holliday = new bool[6];
        Revision_de_perros revision_De_Perros;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _Bienvenida();
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "RUTAS DICIEMBRE 2019.xlsx"))
            {
                File.Copy(Path1, AppDomain.CurrentDomain.BaseDirectory + "RUTAS DICIEMBRE 2019.xlsx");
            }
            if(File.Exists(Path2 + @"\Rutas.xlsx"))
            {
                File.Delete(Path2 + @"\Rutas.xlsx");
                Console.WriteLine("SE borro");
            }

            rutasInfo = new RutasInfo();
            //if (isTheFirstTime)
            //{
            //    bienvenida = new Bienvenida();

            //    bienvenida.ShowDialog();
            //    Path1 = _path1;
            //    isTheFirstTime = true;
            //}
        }




        #region BOTONES DE LOS FESTIVOS
        private void button1_Click(object sender, EventArgs e)
        {
            Holliday[0] = !Holliday[0];
            if (Holliday[0])
            {
                button1.BackColor = Color.Yellow;
            }
            else
            {
                button1.BackColor = Color.White;


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Holliday[1] = !Holliday[1];
            if (Holliday[1])
            {
                button2.BackColor = Color.Yellow;
            }
            else
            {
                button2.BackColor = Color.White;


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Holliday[2] = !Holliday[2];
            if (Holliday[2])
            {
                button3.BackColor = Color.Yellow;
            }
            else
            {
                button3.BackColor = Color.White;


            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Holliday[3] = !Holliday[3];
            if (Holliday[3])
            {
                button4.BackColor = Color.Yellow;
            }
            else
            {
                button4.BackColor = Color.White;


            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Holliday[4] = !Holliday[4];
            if (Holliday[4])
            {
                button5.BackColor = Color.Yellow;
            }
            else
            {
                button5.BackColor = Color.White;


            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Holliday[5] = !Holliday[5];
            if (Holliday[5])
            {
                button6.BackColor = Color.Yellow;
            }
            else
            {
                button6.BackColor = Color.White;


            }

        }

        #endregion

        #region CALENDARIO

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {


            if (!IrregularCHBX.Checked)
            {
                monthCalendar1.MaxSelectionCount = 1;
                DiaInicial = monthCalendar1.SelectionStart;
                DiaFinal = DiaInicial.AddDays(5);
                Rangodefechas = DiaInicial.ToString("D") + " al " + DiaFinal.ToString("D");
                DateSelectedLBL.Text = Rangodefechas;

            }
            else

            {
                monthCalendar1.MaxSelectionCount = 6;
                DiaInicial = monthCalendar1.SelectionStart;
                DiaFinal = monthCalendar1.SelectionEnd;
                Rangodefechas = DiaInicial.ToString("D") + " al " + DiaFinal.ToString("D");
                DateSelectedLBL.Text = Rangodefechas;
            }

        }

        #endregion
        private void button7_Click(object sender, EventArgs e)
        {
            Console.WriteLine("se abre el menu");
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {


            Console.WriteLine("En form1 = " + DiaInicial + "  " + DiaFinal);
            Console.WriteLine("Comenzar a llenar");
            //revision_De_Perros = new Revision_de_perros(DiaInicial, DiaFinal, Rangodefechas, Path, Holliday);

            

            Save();

            revision_De_Perros = new Revision_de_perros(Path1, Path2, Holliday, Rangodefechas, DiaInicial, DiaFinal);
            revision_De_Perros.ShowDialog();
        }
        

        private void _Bienvenida()
        {
            using (Bienvenida bienvenida = new Bienvenida())
            {
                if(bienvenida.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Path1 = bienvenida.path1;
                    Path2 = bienvenida.path2;
                    Console.WriteLine( "Path in FORM1 =  " + Path1);
                    Console.WriteLine("Path 2 in FORM1 =  " + Path2);
                }
            }
        }


        private void Save()
        {

            rutasInfo.Path1 = Path1;
            rutasInfo.Path2 = Path2;
            rutasInfo.Hollydays = Holliday;
            rutasInfo.RangodeDias = Rangodefechas;
            rutasInfo.DiaInicial = DiaInicial;
        }








    }



    }



