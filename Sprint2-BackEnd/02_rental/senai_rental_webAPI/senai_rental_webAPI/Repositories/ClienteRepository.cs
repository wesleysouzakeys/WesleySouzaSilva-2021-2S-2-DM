using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string stringConexao = @"Data Source=NOTE0113E5\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";
        //private string stringConexao = "Data Source=DESKTOP-C7I8NMI\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=wesley123";

        public void Atualizar(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE CLIENTE SET nomeCliente = @novoNomeCliente, sobrenomeCliente = @novoSobrenome, dataNascimento = @novaData WHERE idCliente = @idClienteAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@novoSobrenome", clienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@novaData", clienteAtualizado.dataNascimento);
                    s
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO CLIENTE(nomeCliente, sobrenomeCliente, dataNascimento) VALUES(@novoNome, @novoSobrenome, @novaData)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@novoSobrenome", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@novaData", novoCliente.dataNascimento);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idClienteDel;";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idClienteDel", idCliente);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
