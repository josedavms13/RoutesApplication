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

        int index = 0;
        private bool JacFinished;
        public List<string> Jac;
        public List<string> Kia;

        string ToPrintNOTE;

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


            Console.WriteLine(Jac);
        }

        private void Seleccion_Load(object sender, EventArgs e)
        {
            GenerateBTN.Enabled = false;
            GenerateBTN.Visible = false;
            textBox1.Visible = false;
            AcceptBTN.Visible = false;

            textBox2.Visible = false;
            Accept2BTN.Visible = false;

            CarLBL.Text = "JAC";
            DogLBL.Text = Jac[index];

            
        }

        private void SaleamBTN_Click(object sender, EventArgs e)
        {
            SaleamBTN.BackColor = Color.Yellow;
            SalepmBTN.BackColor = Color.White;
            ToPrintNOTE = "SALE A.M";
        }

        private void SalepmBTN_Click(object sender, EventArgs e)
        {
            SaleamBTN.BackColor = Color.White;
            SalepmBTN.BackColor = Color.Yellow;
            ToPrintNOTE = "SALE P.M";
        }


        private void button1_Click(object sender, EventArgs e) // NOTA DIFERENTE
        {
            textBox1.Visible = true;
            AcceptBTN.Visible = true;
            textBox1.Focus();

            XBTN.Enabled = false;
            button2.Enabled = false;
            NoBTN.Enabled = false;

            SaleamBTN.Enabled = false;
            SalepmBTN.Enabled = false;

            EstadoDiferenteBTN.Enabled = false;


        }

        private void AcceptBTN_Click(object sender, EventArgs e) // (NOTAS (SALE PM)
        {
            // Variable  = textBox1.Text;

            textBox1.Text = "";
            textBox1.Visible = false;
            AcceptBTN.Visible = false;

            XBTN.Enabled = true;
            button2.Enabled = true;
            NoBTN.Enabled = true;

            SaleamBTN.Enabled = true;
            SalepmBTN.Enabled = true;
            EstadoDiferenteBTN.Enabled = true;
            button1.Enabled = true;

            if (!JacFinished)
            {
                ToPrintNOTE = (textBox2.Text).ToUpper();
                JacSaleAm[index] = ToPrintNOTE;
                textBox1.Text = "";
                
            }
            else
            {
                ToPrintNOTE = (textBox2.Text).ToUpper();
                JKiaSaleAm[index] = ToPrintNOTE;
                textBox1.Text = "";

            }



        }
        private void EstadoDiferenteBTN_Click(object sender, EventArgs e)
        {
            XBTN.Enabled = false;
            button2.Enabled = false;
            NoBTN.Enabled = false;

            SaleamBTN.Enabled = false;
            SalepmBTN.Enabled = false;

            textBox2.Visible = true;
            Accept2BTN.Visible = true;
            textBox2.Focus();

            button1.Enabled = false;
        }


        private void Accept2BTN_Click(object sender, EventArgs e) // Estado (X, G, NO)
        {
            string ToPrintState;
            ToPrintState = textBox2.Text.ToUpper(); 

            textBox2.Visible = false;
            Accept2BTN.Visible = false;

            XBTN.Enabled = true;
            button2.Enabled = true;
            NoBTN.Enabled = true;

            SaleamBTN.Enabled = true;
            SalepmBTN.Enabled = true;
            EstadoDiferenteBTN.Enabled = true;
            button1.Enabled = true;

            if (!JacFinished)
            {
                JacState[index] = ToPrintState;
                JacSaleAm[index] = ToPrintNOTE;
                textBox2.Text = "";
                Next();
                
            }
            else
            {
                KiaState[index] = ToPrintState;
                JKiaSaleAm[index] = ToPrintNOTE;
                textBox2.Text = "";
                Next();
            }
            
        }
        private void NoBTN_Click(object sender, EventArgs e)
        {
            if (!JacFinished)
            {
                JacState[index] = "NO";
                JacSaleAm[index] =ToPrintNOTE;
                Next();
            }
            else
            {
                KiaState[index] = "NO";
                JKiaSaleAm[index] =ToPrintNOTE;
                Next();
            }
        }


        private void button2_Click(object sender, EventArgs e) // GUARDERIA BTN
        {
            if (!JacFinished)
            {
                JacState[index] = "G"; 
                JacSaleAm[index] = ToPrintNOTE;
                Next();
            }
            else
            {
                KiaState[index] = "G";
                JKiaSaleAm[index] = ToPrintNOTE;
                Next();
            }

        }


        private void XBTN_Click(object sender, EventArgs e)
        {

            if (!JacFinished)
            {
                JacState[index] = "X"; 
                JacSaleAm[index] = ToPrintNOTE;
                Next();
            }
            else
            {
                KiaState[index] = "X";
                JKiaSaleAm[index] = ToPrintNOTE;
                Next();
            }
        }


        private void Next()
        {
            // Esto ocurrre al final cuando ya se han ploteado los valores en las respectivas listas


            #region JAC

            if (index <= Jac.Count && !JacFinished)
            {

                DogLBL.Text = Jac[index];
                CarLBL.Text = "JAC";


                if (index == Jac.Count)
                {
                    JacFinished = true;
                    // Cambiar a la pagina de kia en el excel
                    Console.WriteLine("Se cambio a la pagina de kia");
                    index = 0;
                }
            }

            #endregion           
            if (index < Kia.Count && JacFinished)
            {

                DogLBL.Text = Kia[index];
                CarLBL.Text = "KIA";

                if (index == Kia.Count - 1)
                {
                    // TERMINO EL PROCESO 


                    NoBTN.Visible = false;
                    SaleamBTN.Visible = false;
                    XBTN.Visible = false;
                    SalepmBTN.Visible = false;
                    button2.Visible = false;

                    GenerateBTN.Enabled = true;
                    GenerateBTN.Visible = true;
                }
            }

            Print();
            CleanToNext();

            index++;


        }

        private void CleanToNext()
        {
            ToPrintNOTE = "";
            
            SaleamBTN.BackColor = Color.White;
            SalepmBTN.BackColor = Color.White;


        }

        private void Print()
        {
            if (!JacFinished)
            {
                Console.WriteLine(" JAC // " + Jac[index] + " " + JacState[index] +" "+ JacSaleAm[index] + " INDEX: =  " + index);

            }else
            {
                Console.WriteLine(" JAC // " + Kia[index] + " " + KiaState[index] + " " + JKiaSaleAm[index] + " "  + " INDEX: =  " + index);

            }
        }

        private void GenerateBTN_Click(object sender, EventArgs e)
        {
            writeExcel = new WriteExcel(path1, path2, Holli, RangoDedias, DiaInicial, DiaFinal, Jac, Kia, JacState, JacSaleAm, KiaState, JKiaSaleAm);
            Application.Exit();
            //writeExcel = new WriteExcel(DiaInicial, DiaFinal, RangoDedias, path2, Holli, Jac, Kia, JacState, JacSaleAm, KiaState, JKiaSaleAm);
            // MAgia magia
            

            //Application.Exit();

            
        }
    }
}
