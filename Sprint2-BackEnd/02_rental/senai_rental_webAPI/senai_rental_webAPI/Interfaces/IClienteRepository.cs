using senai_rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Interfaces
{
    interface IClienteRepository
    {
        List<ClienteDomain> ListarTodos();
        ClienteDomain BuscarPorId(int idCliente);
        void Cadastrar(ClienteDomain novoCliente);
        void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado);
        void AtualizarIdCorpo(ClienteDomain clienteAtualizado);
        void Deletar(int idCliente);
    }
}
