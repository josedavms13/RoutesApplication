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
    public partial class Bienvenida : Form
    {

        public string path1;
        public string path2;

        public Bienvenida()
        {
            InitializeComponent();
            Path1LBL.Visible = false;
            Path2LBL.Visible = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();

            path1 = openFileDialog1.FileName;
            Path1LBL.Text = path1;
            button1.BackColor = Color.LightGreen;
            Console.WriteLine("Path1 = " + path1);
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
            path2 = folderBrowserDialog2.SelectedPath;
            Path2LBL.Text = path2;
            button2.BackColor = Color.LightGreen;
            Console.WriteLine("Path 2 = " + path2);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
