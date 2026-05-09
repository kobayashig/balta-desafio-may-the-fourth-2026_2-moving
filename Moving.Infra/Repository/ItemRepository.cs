using Microsoft.EntityFrameworkCore;
using Moving.Core.Models;
using Moving.Core.Repository.Abstractions;
using Moving.Infra.Context;

namespace Moving.Infra.Repository;

public class ItemRepository(
    SqliteContext context) : IItemRepository
{
    public async Task CreateItemAsync(Item item, CancellationToken ct)
    {
        await context.Items.AddAsync(item, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken ct) =>
        await context.Items.ToListAsync(cancellationToken: ct);

    public async Task<Item?> GetByNameAsync(string name, CancellationToken ct) =>
        await context.Items.Where(i => i.Name == name).FirstOrDefaultAsync(ct);
}