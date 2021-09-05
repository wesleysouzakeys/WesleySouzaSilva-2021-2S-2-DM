using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using senai_rental_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            try
            {
                _ClienteRepository.Cadastrar(novoCliente);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(ClienteDomain clienteAtualizado)
        {
            try
            {
                _ClienteRepository.AtualizarIdCorpo(clienteAtualizado);
                return StatusCode(201);
            }
            catch (Exception erro)
            { 
                return BadRequest(erro);
            }
        }

        [HttpPut("{idCliente}")]
        public IActionResult PutUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            try
            {
                _ClienteRepository.AtualizarIdUrl(idCliente, clienteAtualizado);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ClienteDomain> listaClientes = _ClienteRepository.ListarTodos();
                return Ok(listaClientes);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idCliente}")]
        public IActionResult GetById(int idCliente)
        {
            try
            {
                ClienteDomain clienteBuscado = _ClienteRepository.BuscarPorId(idCliente);
                return Ok(clienteBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ClienteRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
