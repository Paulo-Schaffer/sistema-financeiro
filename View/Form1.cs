using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace SistemaFinanceiro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ContasPagar contasPagar = new ContasPagar();
            contasPagar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show(); 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ContasReceber contasReceber = new ContasReceber();
            contasReceber.Show(); 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
