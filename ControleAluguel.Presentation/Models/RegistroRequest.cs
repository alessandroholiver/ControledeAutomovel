using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAluguel.Presentation.Models
{
    public class RegistroRequest
    {
       
        public DateTime DataInicio { get; set; }
        public Guid IdMotorista { get; set; }
        public Guid IdVeiculo { get; set; }
        public string MotivoUso { get; set; }
    }
}
