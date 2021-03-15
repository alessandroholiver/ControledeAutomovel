using ControleAluguel.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Application.Interfaces.Services
{
    public interface IMotoristaServices
    {
        List<MotoristaDTO> ListarMotoristas();
        MotoristaDTO BuscarMotoristaId(Guid id);
        bool ExcluirMotorista(Guid id);
        bool AtualizarMotorista(MotoristaDTO veiculo);
        Guid CriarMotorista(MotoristaDTO motorista);
        bool ExisteById(Guid id);
        bool ExisteByCPF(int CPF);
    }
}
