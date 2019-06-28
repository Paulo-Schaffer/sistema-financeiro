using Modelo;
using Repositorio; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(); 
            cliente.Nome = txtNome.Text;
            cliente.Cpf = mtbCpf.Text;
            cliente.DataNascimento = dateTimePicker1.Value;
            cliente.Rg = mtbRg.Text;
         

            ClienteRepository repositorio = new ClienteRepository(); 
            repositorio.Inserir(cliente);
           
            System.Windows.Forms.MessageBox.Show("Criado com sucesso");
            AtualizarTabela(); 


        }

        private void AtualizarTabela()
        {

            ClienteRepository repositorio = new ClienteRepository(); 
            string busca = txtBusca.Text;
            List<Cliente> clientes = repositorio.ObterTodos(busca);
            dataGridView1.RowCount = 1;
            for (int i = 0; i < clientes.Count; i++)
            {
                Cliente cliente = clientes[i];
                dataGridView1.Rows.Add(new object[] 
                {
                   cliente.Id,
                   cliente.Nome,
                   cliente.Cpf,
                   cliente.DataNascimento,
                   cliente.Rg
                });
            }
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            AtualizarTabela();
        }
    }
}
