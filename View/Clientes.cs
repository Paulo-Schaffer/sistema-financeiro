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
            dataGridView1.RowCount = 0;
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

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ClienteRepository repositorio = new ClienteRepository();
            repositorio.Deletar(id); 
            AtualizarTabela();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Id = Convert.ToInt32(lblID.Text);
            cliente.Nome = txtNome.Text;
            cliente.Cpf = mtbCpf.Text;
            cliente.DataNascimento = Convert.ToDateTime(dateTimePicker1.Text);
            cliente.Rg = mtbRg.Text;

            ClienteRepository repositorio = new ClienteRepository();
            repositorio.Alterar(cliente);
            AtualizarTabela(); 
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteRepository repositorio = new ClienteRepository();
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            cliente = repositorio.ObterPeloID(id);
            if (cliente == null)
            {
                MessageBox.Show("Não foi possivel obter o registro selecionado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblID.Text = cliente.Id.ToString();  
            txtNome.Text = cliente.Nome;
            mtbCpf.Text = cliente.Cpf;
            dateTimePicker1.Text = cliente.DataNascimento.ToString();
            mtbRg.Text = cliente.Rg;



        }
    }
}
