using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RUTAS_TEST2
{
    public partial class Seleccion : Form
    {
        WriteExcel writeExcel;

        int index;
        string CurrentSelection;
        bool FirstIndexZero;
        bool hasNote;

        private bool JacFinished = false;


        public List<string> Jac;
        public List<string> Kia;

        string ToPrintNOTE;
        string ToPrintState;

        public string[] JacState;
        public string[] JacSaleAm;

        public string[] KiaState;
        public string[] JKiaSaleAm;

        private string path1;
        private string path2;
        private DateTime DiaInicial;
        private DateTime DiaFinal;
        private string RangoDedias;
        private bool[] Holli;



        public Seleccion(string _Path1, string _path2, bool[] _Hollidays, string _RangoDeFechas, DateTime _DiaInicial, DateTime _DiaFinal, List<string> _NuevaListaJac, List<string> _NuevaListaKia)
        {
            path1 = _Path1;
            path2 = _path2;
            DiaInicial = _DiaInicial;
            DiaFinal = _DiaFinal;
            RangoDedias = _RangoDeFechas;
            Holli = _Hollidays;

            Console.WriteLine(DiaInicial +" " + DiaFinal + " " + RangoDedias + " " + path2) ;
            InitializeComponent();
            JacFinished = false;
            Jac = _NuevaListaJac;
            Kia = _NuevaListaKia;

            JacState = new string[Jac.Count];
            JacSaleAm = new string[Jac.Count];
            KiaState = new string[Kia.Count];
            JKiaSaleAm = new string[Kia.Count];



            index = 0;
        
            
        }

        private void Seleccion_Load(object sender, EventArgs e)
        {
            Initial();
        }

        private void SaleamBTN_Click(object sender, EventArgs e)
        {
            SaleamBTN.BackColor = Color.Yellow;
            SalepmBTN.BackColor = Color.White;

            hasNote = true;
            ToPrintNOTE = "SALE A.M";
        }

        private void SalepmBTN_Click(object sender, EventArgs e)
        {
            SaleamBTN.BackColor = Color.White;
            SalepmBTN.BackColor = Color.Yellow;

            hasNote = true;

            ToPrintNOTE = "SALE P.M";
        }


        private void button1_Click(object sender, EventArgs e) // NOTA DIFERENTE
        {
            textBox1.Visible = true;
            textBox1.Focus();
            AcceptBTN.Visible = true;
        }

        private void AcceptBTN_Click(object sender, EventArgs e) // (NOTAS (SALE PM)
        {

            hasNote = true;
            ToPrintNOTE = textBox1.Text.ToUpper();
            Console.WriteLine("Se va a imprimir " + ToPrintNOTE);
            printNote();

            AcceptBTN.Visible = false;

            textBox1.Text = "";
            textBox1.Visible = false;



        }
        private void EstadoDiferenteBTN_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox2.Focus();
            Accept2BTN.Visible = true;

            #region DESABILITAR BOTONES
            XBTN.Enabled = false;
            NoBTN.Enabled = false;
            button2.Enabled = false;



            #endregion
        }


        private void Accept2BTN_Click(object sender, EventArgs e) // Estado (X, G, NO)
        {

            ToPrintState = textBox2.Text.ToUpper();
            Console.WriteLine("ToPrintState = " + ToPrintState);
            if (!JacFinished)
            {
                JacState[index] = ToPrintState;
            }
            else
            {
                KiaState[index - Jac.Count] = ToPrintState;
            }

            textBox2.Text = "";
            textBox2.Visible = false;
            Accept2BTN.Visible = false;

            XBTN.Enabled = true;
            NoBTN.Enabled = true;
            button2.Enabled = true;

            Next();

        }
        private void NoBTN_Click(object sender, EventArgs e)
        {
            if (!JacFinished)
            {
                JacState[index] = "NO";
            }
            else
            {
                KiaState[index - Jac.Count] = "NO";
            }

            Next();

        }


        private void button2_Click(object sender, EventArgs e) // G BTN
        {
            if (!JacFinished)
            {
                JacState[index] = "G";
            }
            else
            {
                KiaState[index - Jac.Count] = "G";
            }


            Next();
        }


        private void XBTN_Click(object sender, EventArgs e)
        {

            if (!JacFinished)
            {
                JacState[index] = "X";
            }
            else
            {
                KiaState[index - Jac.Count] = "X";
            }


            Next();
        }



        private void GenerateBTN_Click(object sender, EventArgs e)
        {
            GenerateBTN.BackColor = Color.AliceBlue;
            GenerateBTN.Text = "GENERANDO...";
            GenerateBTN.ForeColor = Color.White;


            writeExcel = new WriteExcel(path1, path2, Holli, RangoDedias, DiaInicial, DiaFinal, Jac, Kia, JacState, JacSaleAm, KiaState, JKiaSaleAm);
            

            
        }



        private void Initial()
        {
            GenerateBTN.Visible = false;
            textBox1.Visible = false;
            AcceptBTN.Visible = false;
            textBox2.Visible = false;
            Accept2BTN.Visible = false;
            state();
            printInScreen();
        }


        private void Next()
        {
            printNote();

            index++;

            Console.WriteLine("index = " + index );

            state();
            
            printInScreen();
            hasNote = false;
        }

        private void state()
        {

            if(index < Jac.Count)
            {
                CurrentSelection = Jac[index];
            }
            else
            {
                JacFinished = true;
                Console.WriteLine("EMPIEZA KIA ");
                if(index-Jac.Count < Kia.Count)
                {

                    CarLBL.Text = "KIA";
                    CurrentSelection = Kia[index - Jac.Count];
                }
                else
                {
                    ProcessCompleted();
                    DEBUG();
                }
            }
        }

        private void printNote()
        {
            /*
             * Hay que pensar que puede que el primero tenga nota diferente, sale am o sale pm, o ninguno
             * 
             * El sistema tiene que saber si se ha puesto alguna nota o no,
             *      si -> toPrintNote = nota;
             *      No -> toPrintNote = "";
             */

            if (!hasNote)
            {

                ToPrintNOTE = "";
            }
            else
            {

                if (index < JacSaleAm.Length)
                {
                    JacSaleAm[index] = ToPrintNOTE;
                }
                if((index +1) >= JacSaleAm.Length)
                {
                    JKiaSaleAm[(index + 1) - JacSaleAm.Length] = ToPrintNOTE;
                }



                hasNote = false;
                ToPrintNOTE = "";
            }







            SaleamBTN.BackColor = Color.White;
            SalepmBTN.BackColor = Color.White;

        }


        private void ProcessCompleted()
        {
            GenerateBTN.Visible = true;
            SaleamBTN.Visible = false;
            SalepmBTN.Visible = false;
            XBTN.Visible = false;
            NoBTN.Visible = false;
            button2.Visible = false;
            Accept2BTN.Visible = false;
            AcceptBTN.Visible = false;
            EstadoDiferenteBTN.Visible = false;
            NotaDiferenteBTN.Visible = false;
            DogLBL.Visible = false;
            CarLBL.Visible = false;
            Console.WriteLine("Proceso Completado ");
        }


        private void printInScreen()
        {
            DogLBL.Text = CurrentSelection;
        }





        private void DEBUG()
        {
            foreach(string nota in JacSaleAm)
            {
                Console.WriteLine(nota);
            }

            for (int i = 0; i<Jac.Count; i++)
            {
                Console.WriteLine("Jac = " + Jac[i] + " Estado == " + JacState[i] + " || NOTA =  " + JacSaleAm[i]);
            }
            for(int i = 0; i<Kia.Count; i++)
            {
                Console.WriteLine("Kia = " + Kia[i] + " Estado == " + KiaState[i] + " || NOTA =  " + JKiaSaleAm[i]);

            }
        }
    }
}
