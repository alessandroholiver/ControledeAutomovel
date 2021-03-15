using ControleAluguel.Core.Entites;
using ControleAluguel.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Infrastructure.Data
{
  public class MotoristaQuery: IMotoristaRepository
    {
        List<Motorista> motorList;

        public MotoristaQuery()
        {
           motorList = new List<Motorista>();
        }

        public Guid CriarMotorista( Motorista motoristaNovo)
        {
         

            var motorista = new Motorista
            {
                Id = Guid.NewGuid(),
                Nome = motoristaNovo.Nome,
                CPF = motoristaNovo.CPF
            };

            motorList.Add(motorista);
            return motorista.Id;
        }

        public bool AtualizarMotorista(Motorista motor)
        {
            foreach (var item in motorList)
            {
                if (item.CPF == motor.CPF)
                {
                    item.CPF = motor.CPF;
                    item.Nome = motor.Nome;
                    return true;
                }
            }
            return false;
        }

        public bool ExcluirMotorista(Guid id)
        {
            motorList.Remove(BuscarMotoristaId(id));
            return true;
        }


        public List<Motorista> ListarMotorista()
        {
            var motorista1 = new Motorista
            {
                Id = new Guid("{3fa85f64-5717-4562-b3fc-2c963f66afa3}"),
                Nome = "Jose Jose",
                CPF = 1234567888
            };

            var motorista = new Motorista
            {
                Id = new Guid("{3fa85f64-5717-4562-b3fc-2c963f66afa0}"),
                Nome = "Rubens",
                CPF = 2132112155
            };

            var motorista2 = new Motorista
            {
                Id = new Guid("{3fa85f64-5717-4562-b3fc-2c963f66afa4}"),
                Nome = "Maria Maria",
                CPF = 565454588

            };

            var motorista3 = new Motorista
            {
                Id = new Guid("{3fa85f64-5717-4562-b3fc-2c963f66afa8}"),
                Nome = "Carlos Carlos",
                CPF = 45456484
            };

            var motorista4 = new Motorista
            {
                Id = new Guid("{3fa85f64-5717-4562-b3fc-2c963f66afa6}"),
                Nome = "Jose Jose",
                CPF = 124545
            };



            motorList.Add(motorista);
            motorList.Add(motorista1);
            motorList.Add(motorista2);
            motorList.Add(motorista3);
            motorList.Add(motorista4);
            return motorList;
        }

        public Motorista BuscarMotoristaId(Guid id)
        {
            return motorList.Find(c => c.Id == id);
        }

        public bool ExisteById(Guid id)
        {
           
            return motorList.Exists(c => c.Id == id);
        }

        public bool ExisteByCPF(int CPF)
        {

            return motorList.Exists(c => c.CPF == CPF);
        }
    }
}
