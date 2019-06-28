using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class ClienteRepository
    {
        public string CadeiaConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\SistemaFinanceiro.mdf;Integrated Security=True;Connect Timeout=30";

        public void Inserir(Cliente clientes)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "INSERT INTO clientes (nome,cpf,data_Nascimento,rg) " +
                "VALUES (@NOME,@CPF,@DATANASCIMENTO,@RG)";
            comando.Parameters.AddWithValue("@NOME", clientes.Nome);
            comando.Parameters.AddWithValue("@CPF", clientes.Cpf);
            comando.Parameters.AddWithValue("@DATANASCIMENTO", clientes.DataNascimento);
            comando.Parameters.AddWithValue("@RG", clientes.Rg);
            comando.ExecuteNonQuery();



            conexao.Close();

        }

        public void Deletar(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "DELETE FROM clientes WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            conexao.Close();


        }

        public void Alterar(Cliente clientes)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "UPDATE clientes SET nome=@NOME,cpf=@CPF,data_Nascimento=@DATANASCIMENTO,rg=@RG WHERE id=@ID ";

            comando.Parameters.AddWithValue("@ID", clientes.Id);
            comando.Parameters.AddWithValue("@NOME", clientes.Nome);
            comando.Parameters.AddWithValue("@CPF", clientes.Cpf);
            comando.Parameters.AddWithValue("@DATANASCIMENTO", clientes.DataNascimento);
            comando.Parameters.AddWithValue("@RG", clientes.Rg);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public List<Cliente> ObterTodos(string busca)
        {
            SqlConnection conexao = new SqlConnection();

            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"SELECT * FROM clientes";

 

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            conexao.Close();

            List<Cliente> cliente = new List<Cliente>();
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                Cliente clientes = new Cliente();
                clientes.Id = Convert.ToInt32(linha["id"]);
                clientes.Nome = linha["nome"].ToString();
                clientes.Cpf = linha["cpf"].ToString();
                clientes.DataNascimento = Convert.ToDateTime(linha["data_Nascimento"]);
                clientes.Rg = linha["rg"].ToString();
                cliente.Add(clientes);

            }
            return cliente;
        }

        public Cliente ObterPeloID(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;

            comando.CommandText = "SELECT * FROM clientes WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            if (tabela.Rows.Count == 0)
            {
                return null;
               
            }

            DataRow linha = tabela.Rows[0];
            Cliente cliente = new Cliente();
            cliente.Id = Convert.ToInt32(linha["id"]);
            cliente.Nome = linha["nome"].ToString();
            cliente.Cpf = linha["cpf"].ToString();
            cliente.DataNascimento = Convert.ToDateTime(linha["data_nascimento"].ToString());
            cliente.Rg = linha["rg"].ToString();
            return cliente;
        }
    }
}   

