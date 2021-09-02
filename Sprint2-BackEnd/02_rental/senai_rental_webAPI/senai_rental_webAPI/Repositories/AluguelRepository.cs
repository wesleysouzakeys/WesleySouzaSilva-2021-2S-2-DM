using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = "Data Source=NOTE0113E4//SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";

        public void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string updateIdUrl = "UPDATE ALUGUEL SET dataAluguel = @novaDataAluguel WHERE idAluguel = @idNovaData";

                using (SqlCommand cmd = new SqlCommand(updateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novaDataAluguel", aluguelAtualizado.dataAluguel);
                    cmd.Parameters.AddWithValue("@idNovaData", idAluguel);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

            }
        }

        public void Deletar(int idAluguel)
        {
            throw new NotImplementedException();
        }

        public List<AluguelDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
