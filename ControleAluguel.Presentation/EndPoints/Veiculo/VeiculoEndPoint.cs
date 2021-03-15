using ControleAluguel.Application.DTO;
using ControleAluguel.Application.Interfaces.Services;
using ControleAluguel.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAluguel.Presentation.EndPoints.Motorista
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VeiculoEndPoint : ControllerBase
    {
        private readonly IVeiculoServices _veiculoServices;
        VeiculoDTO veiculoDTO;

        public VeiculoEndPoint(IVeiculoServices veiculo)
        {
            _veiculoServices = veiculo;
        }

        [HttpGet]
        public IEnumerable<VeiculoDTO> ListarTodos()
        {
            var retorno = _veiculoServices.ListarVeiculos();
            return retorno;
        }

        [HttpGet]
        public IActionResult ListarPorCor(string cor)
        {
            var retorno = _veiculoServices.ListarVeiculosByCor(cor);
            if (retorno.Count <= 0)
                return NotFound("Não existem veiculos com a cor informada");
            return Ok(retorno);
        }

        [HttpGet]
        public IActionResult ListarPorMarca(string marca)
        {
            var retorno = _veiculoServices.ListarVeiculosByMarca(marca);
            if (retorno.Count <= 0)
                return NotFound("Não existem veiculos com a marca informada");
            return Ok(retorno);
            
        }

        [HttpGet("{id}")]
        public IActionResult BuscarById(Guid id)
        {
            var retorno = _veiculoServices.BuscarVeiculoId(id);
            if (retorno == null)
            {
                return BadRequest("Veiculo não encontrado");
            }
            return Ok(retorno);
        }
        [HttpPost]
        public IActionResult CreateMotorista([FromBody] VeiculoRequest veiculo)
        {
            if (veiculo == null)
                return BadRequest();

            if (_veiculoServices.ExisteByPlaca(veiculo.Placa))
                return BadRequest("Já existe um veiculo com a placa informada");


            veiculoDTO = new VeiculoDTO
            {
                Cor = veiculo.Cor,
                Placa = veiculo.Placa,
                Marca = veiculo.Marca
            };


            var retorno = _veiculoServices.CriarVeiculo(veiculoDTO);

            return Ok("O Veiculo foi criado com sucesso. ID: " + retorno);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] VeiculoDTO veiculo)
        {
            if (veiculo == null)
                return BadRequest();
            if (!_veiculoServices.ExisteById(veiculo.Id))
                return NotFound();

            var retorno = _veiculoServices.AtualizarVeiculo(veiculo);
            if (retorno)
                return NoContent();

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult ExcluirMotorista(Guid id)
        {
            if (!_veiculoServices.ExisteById(id))
                return NotFound();

            _veiculoServices.ExcluirVeiculo(id);
            return NoContent();
        }
    }
}
