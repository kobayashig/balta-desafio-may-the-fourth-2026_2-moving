using Microsoft.Extensions.DependencyInjection;
using Moving.Application.Services;
using Moving.Application.Services.Abstraction;

namespace Moving.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddItemServiceApplication(this IServiceCollection service)
    {
        service.AddScoped<IItemServiceApplication, ItemServiceApplication>();
        
        return service;
    }
}