using JobHub.Application.CQRS.Commands;
using JobHub.Application.Interfaces.ICustomRepo;
using JobHub.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HobHub.Shared
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region MediatR
            services.AddMediatR(typeof(SaveProfileHandler));
            #endregion
        }
    }
}
