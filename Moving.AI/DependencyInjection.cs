using Microsoft.Extensions.DependencyInjection;
using Moving.AI.Agents;
using Moving.AI.Providers;
using Moving.AI.Providers.Abstraction;
using Moving.Core.Agents.Abstractions;
using Moving.Core.Enums;
using Moving.Core.Models;

namespace Moving.AI;

public static class DependencyInjection
{
    public static IServiceCollection AddAgents(this IServiceCollection services)
    {
        services.AddKeyedScoped<IAgent<Item, string>, LocalizeItemAgent>(AgentType.LocalizeItem);

        services.AddKeyedTransient<IPromptProvider, FilePromptProvider>(PromptProvider.File);
        
        return services;
    }
}