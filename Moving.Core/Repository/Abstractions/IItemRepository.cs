using Moving.Core.Models;

namespace Moving.Core.Repository.Abstractions;

public interface IItemRepository
{
    Task CreateItemAsync(Item item, CancellationToken ct);
    Task<IEnumerable<Item>> GetAllAsync(CancellationToken ct);
    Task<Item?> GetByNameAsync(string name, CancellationToken ct);
}