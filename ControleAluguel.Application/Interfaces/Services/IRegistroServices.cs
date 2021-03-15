using ControleAluguel.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Application.Interfaces.Services
{
   public interface IRegistroServices
    {
        List<RegistroDTO> ListRegistroAtivos();
        bool FinalizarRegistro(Guid id);
        int CriarRegistro(RegistroDTO reg);
        RegistroDTO BuscarRegistroById(Guid id);
        bool ExisteRegistroById(Guid id);

    }
}
