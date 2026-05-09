namespace Moving.Core.Services.Abstractions;

public interface IItemService
{
    Task<string> LocalizeAsync(string name, CancellationToken ct);
}