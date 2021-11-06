using global::Domain.Models.InitialData;
using Microsoft.Extensions.DependencyInjection;
using PetClinic.Domain.Common;
using PetClinic.Domain.Factories;

namespace PetClinic.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime())
               .AddTransient<IInitialData, SpiciesData>();
    }
}
