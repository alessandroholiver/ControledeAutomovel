using ControleAluguel.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Core.Interfaces.Repository
{
    public interface IMotoristaRepository
    {
        List<Motorista> ListarMotorista();
        Motorista BuscarMotoristaId(Guid id);
        bool ExcluirMotorista(Guid id);
        bool AtualizarMotorista(Motorista motorista);
        Guid CriarMotorista(Motorista motorista);
        bool ExisteById(Guid id);
        bool ExisteByCPF(int CPF);
    }
}
