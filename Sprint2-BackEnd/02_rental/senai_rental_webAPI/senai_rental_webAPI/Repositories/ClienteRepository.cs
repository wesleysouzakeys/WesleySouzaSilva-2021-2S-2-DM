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
        private string stringConexao = "Data Source=NOTE0113E4//SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";

        public void Atualizar(int idCliente, ClienteDomain clienteAtualizado)
        {
            throw new NotImplementedException();
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
                    cmd.Parameters.AddWithValue("@novoCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@novoSobrenome", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@novaData", novoCliente.dataNascimento);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
