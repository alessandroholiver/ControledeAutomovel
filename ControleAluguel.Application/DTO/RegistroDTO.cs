using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Application.DTO
{
   public class RegistroDTO
    {
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Guid IdMotorista { get; set; }
        public Guid IdVeiculo { get; set; }
        public string MotivoUso { get; set; }

    }
}
