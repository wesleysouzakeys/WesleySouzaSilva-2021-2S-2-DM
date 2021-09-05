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
        
        private string stringConexao = "Data Source=NOTE0113E5\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";

        public void AtualizarIdCorpo(ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE CLIENTE SET nomeCliente = @novoNomeCliente, sobrenomeCliente = @novoSobrenome, dataNascimento = @novaData WHERE idCliente = @idCliAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@novoSobrenome", clienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@novaData", clienteAtualizado.dataNascimento);
                    cmd.Parameters.AddWithValue("@idCliAtualizado", clienteAtualizado.idCliente);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE CLIENTE SET nomeCliente = @novoNomeCliente, sobrenomeCliente = @novoSobrenome, dataNascimento = @novaData WHERE idCliente = @idCliAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@novoSobrenome", clienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@novaData", clienteAtualizado.dataNascimento);
                    cmd.Parameters.AddWithValue("@idCliAtualizado", idCliente);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectId = "SELECT nomeCliente, sobrenomeCliente, dataNascimento FROM CLIENTE WHERE idCliente = @idCliente";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectId, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            nomeCliente = rdr[0].ToString(),
                            sobrenomeCliente = rdr[1].ToString(),
                            dataNascimento = Convert.ToDateTime(rdr[2]),
                        };
                        return cliente;
                    }
                    return null;
                }
            }
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
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT nomeCliente, sobrenomeCliente, dataNascimento FROM CLIENTE;";
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            //idCliente = Convert.ToInt32(rdr[0]),

                            nomeCliente = rdr[0].ToString(),

                            sobrenomeCliente = rdr[1].ToString(),

                            dataNascimento = Convert.ToDateTime(rdr[2])
                        };

                        listaClientes.Add(cliente);
                    }
                }
            }
            return listaClientes;
        }
    }
}
