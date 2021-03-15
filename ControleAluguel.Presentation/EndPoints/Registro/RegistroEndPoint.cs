using ControleAluguel.Application.DTO;
using ControleAluguel.Application.Interfaces.Services;
using ControleAluguel.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ControleAluguel.Presentation.EndPoints.Registro
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RegistroEndPoint: ControllerBase
    {
        RegistroDTO _registro;
       private readonly IRegistroServices regServices;

        public RegistroEndPoint(IRegistroServices serv)
        {
            regServices = serv;
        }

        [HttpGet]
        public IActionResult ListarAtivos()
        {

            var lista = regServices.ListRegistroAtivos();
            if (lista.Count <= 0)
            {
                return NotFound("Não existem registros ativos");
            }

            return Ok(lista);

        }

        [HttpGet]
        public IActionResult Finalizar(Guid id)
        {

            var fim = regServices.FinalizarRegistro(id);

            if (fim)
            {
                return Ok("Registro finalizado com sucesso");
            }
            return NotFound("Não foi encontrado registro em aberto com Id informado");

        }

        [HttpPost]
        public IActionResult CriarRegistro([FromBody] RegistroRequest novoReg)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            if (novoReg == null)
                return BadRequest("Registro não pode ser nulo");

            _registro = new RegistroDTO {
                DataInicio = novoReg.DataInicio,
                IdMotorista = novoReg.IdMotorista,
                IdVeiculo = novoReg.IdVeiculo,
                MotivoUso = novoReg.MotivoUso

            };

            var create = regServices.CriarRegistro(_registro);
            if (create == 1)
            {
                return NotFound( "O não existe motorista com o Id solicitado");
            }
            if (create == 2)
            {
                return NotFound( "Não existe veiculo com ID Solicitado");
            }
            if (create == 3)
            {

                return BadRequest( "Não foi possivel realizar o registro, verifiquei se o veiculo se encontra disponivel ou " +
                    "se o motorista não possui um registro em aberto");
            }
            return Ok( "Registro criado com sucesso");

        }

    }
}
