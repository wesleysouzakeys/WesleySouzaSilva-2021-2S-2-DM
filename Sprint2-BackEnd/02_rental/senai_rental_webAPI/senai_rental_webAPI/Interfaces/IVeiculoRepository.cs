using senai_rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Interfaces
{
    interface IVeiculoRepository
    {
        List<VeiculoDomain> ListarTodos();

        VeiculoDomain BuscarPorId(int idVeiculo);

        void Cadastrar(VeiculoDomain novoVeiculo);

        void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado);

        void Deletar(int idVeiculo);

    }
}
