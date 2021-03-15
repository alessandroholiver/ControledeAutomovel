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
    public class MotoristaEndPoint : ControllerBase
    {
        private readonly IMotoristaServices _motoServices;
        MotoristaDTO motoristaDTO;

        public MotoristaEndPoint(IMotoristaServices moto)
        {
            _motoServices = moto;
        }

        [HttpGet]
        public IEnumerable<MotoristaDTO> ListarTodos()
        {
            var retorno = _motoServices.ListarMotoristas();
            return retorno;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarById(Guid id)
        {
            var retorno = _motoServices.BuscarMotoristaId(id);
            if (retorno == null)
            {
                return BadRequest("Motorista Não encontrado");
            }
            return Ok(retorno);
        }
        [HttpPost]
        public IActionResult CreateMotorista([FromBody] MotoristaRequest motorista)
        {
            if (motorista == null)
                return BadRequest();

            if (_motoServices.ExisteByCPF(motorista.CPF))
                return BadRequest("Já existe um motorista com o CPF informado");


                motoristaDTO = new MotoristaDTO
            {
                Nome = motorista.Nome,
                CPF = motorista.CPF
            };

            
           var retorno = _motoServices.CriarMotorista(motoristaDTO);

            return Ok("O Motorista foi criado com sucesso ID: "+retorno);
        }

        [HttpPut]
        public IActionResult Atualizar( [FromBody] MotoristaDTO motorista)
        {
            if (motorista == null)
                return BadRequest();
            if (!_motoServices.ExisteById(motorista.Id))
                return NotFound();

          var retorno =  _motoServices.AtualizarMotorista(motorista);
            if(retorno)
            return NoContent();

            return NotFound(); 
        }

        [HttpGet("{id}")]
        public IActionResult ExcluirMotorista(Guid id)
        {
            if (!_motoServices.ExisteById(id))
                return NotFound();

             _motoServices.ExcluirMotorista(id);
             return NoContent();
        }
    }
}
