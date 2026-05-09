using Moving.Application.Dto;
using Moving.Core.Models;

namespace Moving.Application.Services.Abstraction;

public interface IItemServiceApplication
{
    Task<string> GetItemAsync(string name, CancellationToken ct);
    Task<IEnumerable<Item>> GetAllAsync(CancellationToken ct);
    Task PostItemAsync(ItemDtoRequest request, CancellationToken ct);
}