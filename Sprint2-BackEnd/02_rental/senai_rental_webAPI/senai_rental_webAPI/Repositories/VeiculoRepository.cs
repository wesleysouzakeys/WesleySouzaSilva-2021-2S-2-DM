using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            throw new NotImplementedException();
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public List<VeiculoDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
