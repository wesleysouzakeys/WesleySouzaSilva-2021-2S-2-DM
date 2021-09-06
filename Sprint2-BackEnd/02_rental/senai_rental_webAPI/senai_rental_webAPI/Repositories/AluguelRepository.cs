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
        private string stringConexao = "Data Source=NOTE0113E5\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";

        public void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Aluguel SET IdCliente = @IdCliente, IdVeiculo = @IdVeiculo, Data = @Data  WHERE IdAluguel = @IdAluguelAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", aluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@IdVeiculo", aluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@Data", aluguelAtualizado.dataAluguel);
                    cmd.Parameters.AddWithValue("@IdAluguelAtualizado", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdAluguel, IdCliente, IdVeiculo, Data FROM Aluguel WHERE IdAluguel = @IdAluguel";


                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdAluguel", idAluguel);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            Cliente = new ClienteDomain() { idCliente = Convert.ToInt32(rdr[1]) },
                            Veiculo = new VeiculoDomain() { idVeiculo = Convert.ToInt32(rdr[2]) },
                            dataAluguel = Convert.ToDateTime(rdr[3])
                        };

                        return aluguelBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Aluguel(IdCliente,IdVeiculo,Data) VALUES (@IdCliente,@IdVeiculo,@Data)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@IdVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@Data", novoAluguel.dataAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Aluguel WHERE IdAluguel = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectAll = "SELECT IdAluguel, Aluguel.IdCliente, Aluguel.IdVeiculo, Preco, Data FROM Aluguel LEFT JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente LEFT JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain Aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            Cliente = new ClienteDomain() { idCliente = Convert.ToInt32(rdr[1]) },
                            Veiculo = new VeiculoDomain() { idVeiculo = Convert.ToInt32(rdr[2]) },
                            dataAluguel = Convert.ToDateTime(rdr[3])
                        };

                        listaAlugueis.Add(Aluguel);
                    }
                }
            };

            return listaAlugueis;
        }
    }
}
