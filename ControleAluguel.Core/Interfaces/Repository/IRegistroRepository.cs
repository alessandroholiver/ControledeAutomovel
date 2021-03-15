using ControleAluguel.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Core.Interfaces.Repository
{
    public interface IRegistroRepository
    {
        List<Registro> ListRegistroAtivos();
        bool FinalizarRegistro(Guid id);
        bool CriarRegistro(Registro reg);
        Registro BuscarRegistroById(Guid id);
        bool ExisteRegistroById(Guid id);
        bool ExisteRegistroAtivo(Registro reg);

    }
}
