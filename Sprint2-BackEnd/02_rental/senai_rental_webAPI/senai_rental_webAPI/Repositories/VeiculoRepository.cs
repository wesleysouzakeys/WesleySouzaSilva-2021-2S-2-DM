using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string stringConexao = "Data Source=NOTE0113E5\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";
        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryUpdate = "UPDATE VEICULO SET idEmpresa = @idEmpresa, placa = @placa, idModelo= @idModelo WHERE idVeiculo = @idVeiculoAtualizado";

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", veiculoAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@Placa", veiculoAtualizado.placa);
                    cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@idVeiculoAtualizado", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelectById = "SELECT IdVeiculo, Veiculo.IdEmpresa, Placa, Veiculo.IdModelo FROM Veiculo LEFT JOIN Empresa ON Veiculo.IdEmpresa = Empresa.IdEmpresa LEFT JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo WHERE IdVeiculo = @IdVeiculo";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdVeiculo", idVeiculo);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain VeiculoBuscado = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            Empresa = new EmpresaDomain() { idEmpresa = Convert.ToInt32(rdr[1]) },
                            placa = rdr[2].ToString(),
                            Modelo = new ModeloDomain() { idModelo = Convert.ToInt32(rdr[3]) }
                        };

                        return VeiculoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Veiculo (IdEmpresa,Placa,IdModelo) VALUES(@IdEmpresa,@Placa,@IdModelo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@Placa", novoVeiculo.placa);
                    cmd.Parameters.AddWithValue("@IdModelo", novoVeiculo.idModelo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryDelete = "DELETE FROM Veiculo WHERE idVeiculo = @id";

                using (SqlCommand Cmd = new SqlCommand(QueryDelete, con))
                {
                    Cmd.Parameters.AddWithValue("@id", idVeiculo);

                    con.Open();

                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> ListaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdVeiculo, Veiculo.IdEmpresa, Placa, Veiculo.IdModelo FROM Veiculo LEFT JOIN Empresa ON Veiculo.IdEmpresa = Empresa.IdEmpresa LEFT JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain Veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            Empresa = new EmpresaDomain() { idEmpresa = Convert.ToInt32(rdr[1]) },
                            placa = rdr[2].ToString(),
                            Modelo = new ModeloDomain() { idModelo = Convert.ToInt32(rdr[3]) }
                        };
                        ListaVeiculos.Add(Veiculo);
                    }
                }
            };
            return ListaVeiculos;
        }
    }
}
