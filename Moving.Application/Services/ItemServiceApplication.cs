using Microsoft.Extensions.Logging;
using Moving.Application.Dto;
using Moving.Application.Extensions;
using Moving.Application.Services.Abstraction;
using Moving.Core.Models;
using Moving.Core.Repository.Abstractions;
using Moving.Core.Services.Abstractions;

namespace Moving.Application.Services;

public class ItemServiceApplication(
    IItemRepository itemRepository,
    IItemService itemService) : IItemServiceApplication
{
    public async Task<string> GetItemAsync(string name, CancellationToken ct) =>
        await itemService.LocalizeAsync(name, ct);

    public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken ct) =>
        await itemRepository.GetAllAsync(ct);

    public async Task PostItemAsync(ItemDtoRequest request, CancellationToken ct) =>
        await itemRepository.CreateItemAsync(request.ConvertToItem(), ct);
}