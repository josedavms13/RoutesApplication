using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace RUTAS_TEST2
{
    public partial class Revision_de_perros : Form
    {
        private int SideSelector = 0;

        public List<string> NuevaListaJac = new List<string>();
        public List<string> NuevaListaKia = new List<string>();


        Seleccion seleccion;
        Form1 form1;


        private string path;
        private string path2;
        DateTime DiaInicial;
        DateTime DiaFinal;
        string RangoDedias;
        bool[] Holli;


        public Revision_de_perros(string path1, string _path2, bool[] Hollidays, string RangoDeFechas, DateTime _DiaInicial, DateTime _DiaFInal)
        {
            path = path1;
            path2 = _path2;
            DiaInicial = _DiaInicial;
            DiaFinal = _DiaFInal;
            RangoDedias = RangoDeFechas;
            Holli = Hollidays;
            InitializeComponent();
            
        }

        
        private void Revision_de_perros_Load(object sender, EventArgs e)
        {
            STARTBTN.Enabled = false;

            NuevaListaJac.Clear();
            NuevaListaKia.Clear();

            ReadingExcel readingExcel = new ReadingExcel(path);


            textBox1.Visible = false;
            AcceptBTN.Visible = false;
            NameLBL.Visible = false;



            for (int i = 0; i < readingExcel.PerrosJac.Count; i++)
            {
                listBox1.Items.Add(readingExcel.PerrosJac[i]);

            }
            for (int i = 0; i < readingExcel.PerrosKia.Count; i++)
            {
                listBox2.Items.Add(readingExcel.PerrosKia[i]);
            }


            DogCountLBL.Text = "(" + listBox1.Items.Count.ToString() + ")";
            DogCount2LBL.Text = "(" + listBox2.Items.Count.ToString() + ")";




        }

        private void RemoveBTN1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                int index1 = listBox1.SelectedIndex;

                listBox1.Items.RemoveAt(index1);

                DogCountLBL.Text = "(" + listBox1.Items.Count.ToString() + ")";
                DogCount2LBL.Text = "(" + listBox2.Items.Count.ToString() + ")";

            }

        }

        private void RemoveBTN2_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedItem != null)
            {

            int index2 = listBox2.SelectedIndex;

            listBox2.Items.RemoveAt(index2);
            DogCountLBL.Text = "(" + listBox1.Items.Count.ToString() + ")";
            DogCount2LBL.Text = "(" + listBox2.Items.Count.ToString() + ")";

            }


        }
        private void AddBTN1_Click(object sender, EventArgs e)
        {
            SideSelector = 1;
            AddDogs();
        }
        private void AddBTN2_Click(object sender, EventArgs e)
        {

            SideSelector = 2;
            AddDogs();

        }


        private void AddDogs()
        {
            RemoveBTN1.Enabled = false;
            AddBTN1.Enabled = false;
            RemoveBTN2.Enabled = false;
            AddBTN2.Enabled = false;
            STARTBTN.Enabled = false;



            textBox1.Visible = true;
            textBox1.Focus();
            AcceptBTN.Visible = true;
            NameLBL.Visible = true;


        }

        private void AcceptBTN_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Accepted");

            switch (SideSelector)
            {
                case 1:
                    listBox1.Items.Add((textBox1.Text).ToUpper());
                    Console.WriteLine("Jac Selected Dogs Launched");
                    break;
                case 2:
                    listBox2.Items.Add((textBox1.Text).ToUpper());

                    Console.WriteLine("Kia selected Dogs Launched");
                    break;
            }

            textBox1.Text = "";
            textBox1.Visible = false;
            AcceptBTN.Visible = false;
            NameLBL.Visible = false;

            RemoveBTN1.Enabled = true;
            AddBTN1.Enabled = true;
            RemoveBTN2.Enabled = true;
            AddBTN2.Enabled = true;

            DogCountLBL.Text = "(" + listBox1.Items.Count.ToString() + ")";
            DogCount2LBL.Text = "(" + listBox2.Items.Count.ToString() + ")";
        }

        private void ConsolideLists()
        {
            Console.WriteLine("JAC ------");
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                NuevaListaJac.Add(listBox1.Items[i].ToString());
                Console.WriteLine(NuevaListaJac[i]);
            }

            Console.WriteLine("Kia --------");
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                NuevaListaKia.Add(listBox2.Items[i].ToString());
                Console.WriteLine(NuevaListaKia[i]);
            }


        }

        private void STARTBTN_Click(object sender, EventArgs e)
        {
            seleccion = new Seleccion(path , path2, Holli, RangoDedias, DiaInicial, DiaFinal, NuevaListaJac, NuevaListaKia);
            seleccion.ShowDialog();
        }

        private void ConsolideBTN_Click(object sender, EventArgs e)
        {
            STARTBTN.Enabled = true;
            ConsolideBTN.Enabled = false;
            AcceptBTN.Enabled = false;
            AddBTN1.Enabled = false;
            AddBTN2.Enabled = false;
            RemoveBTN1.Enabled = false;
            RemoveBTN2.Enabled = false;

            ConsolideLists();


        }
    }


    
}
