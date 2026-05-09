using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moving.Core.Agents.Abstractions;
using Moving.Core.Enums;
using Moving.Core.Models;
using Moving.Core.Repository.Abstractions;
using Moving.Core.Services.Abstractions;

namespace Moving.Infra.Services;

public class ItemService(
    ILogger<ItemService> logger,
    
    [FromKeyedServices(AgentType.LocalizeItem)]
    IAgent<Item, string> agent,
    
    IItemRepository itemRepository) : IItemService
{
    public async Task<string> LocalizeAsync(string name, CancellationToken ct)
    {
        logger.LogInformation("Localizando item...");

        var items = await itemRepository.GetByNameAsync(name, ct);
        
        var result = await agent.RunAsync(items, ct);

        return result;
    }
}