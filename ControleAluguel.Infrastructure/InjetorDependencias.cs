using ControleAluguel.Application.Interfaces.Services;
using ControleAluguel.Application.Services;
using ControleAluguel.Core.Interfaces.Repository;
using ControleAluguel.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;


namespace ControleAluguel.Infrastructure
{
    public class InjetorDependencias
    {

        public static void Registrar(IServiceCollection services)
        {

            services.AddSingleton<IMotoristaServices,MotoristaService>();
            services.AddSingleton<IRegistroServices, RegistroServices>();
            services.AddSingleton<IVeiculoServices, VeiculoServices>();


            services.AddSingleton<IMotoristaRepository, MotoristaQuery>();
            services.AddSingleton<IVeiculoRepository, VeiculoQuery>();
            services.AddSingleton<IRegistroRepository, RegistroQuery>();


        }

    }
}
