using CampClotNot.Data;
using CampClotNot.Data.Entities;
using CampClotNot.Hubs;
using CampClotNot.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace CampClotNot.Services;

/// <summary>
/// Handles posting and voiding transactions. Every coin/star movement is a transaction.
/// Records are append-only — nothing is deleted, only voided.
/// </summary>
public class TransactionService(
    ITransactionRepository transactions,
    IHubContext<CampHub> hub)
{
    public Task<List<Transaction>> GetAllAsync() => transactions.GetAllAsync();

    public Task<List<Transaction>> GetByGroupAsync(Guid groupId) => transactions.GetByGroupAsync(groupId);

    /// <summary>
    /// Posts a new transaction and broadcasts a score update to all connected clients.
    /// </summary>
    public async Task<Transaction> PostAsync(Guid groupId, CurrencyType currencyType, int amount,
        string loggedBy, string? note = null)
    {
        var tx = await transactions.CreateAsync(new Transaction
        {
            TxId = Guid.NewGuid(),
            GroupId = groupId,
            CurrencyType = currencyType,
            Amount = amount,
            LoggedBy = loggedBy,
            Note = note,
            CreatedAt = DateTime.UtcNow
        });
        await hub.Clients.All.SendAsync("ScoresUpdated");
        return tx;
    }

    /// <summary>
    /// Voids a transaction (admin only). Reverses the effective amount and broadcasts update.
    /// Only non-voided transactions are reversed — calling void twice is a no-op.
    /// </summary>
    public async Task VoidAsync(Guid txId, string voidedBy)
    {
        await transactions.VoidAsync(txId, voidedBy);
        await hub.Clients.All.SendAsync("ScoresUpdated");
    }
}
