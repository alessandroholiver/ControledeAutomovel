using ControleAluguel.Core.Entites;
using ControleAluguel.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Infrastructure.Data
{
    public class RegistroQuery : IRegistroRepository
    {
        List<Registro> registrosList;
        public RegistroQuery()
        {
            registrosList = new List<Registro>();
        }


        public List<Registro> ListRegistroAtivos()
        {
            return registrosList.FindAll(c=> c.DataFim == DateTime.Parse("0001-01-01T00:00:00"));

        }

        public bool FinalizarRegistro(Guid id)
        {
            foreach (var item in registrosList)
            {
                if (item.Id == id && item.DataFim== DateTime.Parse("0001-01-01T00:00:00"))
                {
                    item.DataFim = DateTime.Now;
                }

            }
            
            return true;

        }

        public bool CriarRegistro(Registro reg)
        {
            reg.Id = Guid.NewGuid();
            registrosList.Add(reg);

            return true;

        }

        public Registro BuscarRegistroById(Guid id)
        {

            return registrosList.Find(c => c.Id == id);

        }

        public bool ExisteRegistroById(Guid id)
        {

            return registrosList.Exists(c => c.Id == id);

        }

        public bool ExisteRegistroAtivo(Registro reg)
        {

            return registrosList.Exists(c => c.IdMotorista == reg.IdMotorista || c.IdVeiculo==reg.IdVeiculo);

        }
    }
}
