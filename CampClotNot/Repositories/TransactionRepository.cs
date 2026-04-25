using CampClotNot.Data;
using CampClotNot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampClotNot.Repositories;

public class TransactionRepository(AppDbContext db) : ITransactionRepository
{
    public Task<List<Transaction>> GetAllAsync() =>
        db.Transactions.Include(t => t.Group).OrderByDescending(t => t.CreatedAt).ToListAsync();

    public Task<List<Transaction>> GetByGroupAsync(Guid groupId) =>
        db.Transactions.Where(t => t.GroupId == groupId).OrderByDescending(t => t.CreatedAt).ToListAsync();

    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        db.Transactions.Add(transaction);
        await db.SaveChangesAsync();
        return transaction;
    }

    public async Task VoidAsync(Guid txId, string voidedBy)
    {
        var tx = await db.Transactions.FindAsync(txId);
        if (tx is not null && tx.VoidedAt is null)
        {
            tx.VoidedAt = DateTime.UtcNow;
            tx.VoidedBy = voidedBy;
            await db.SaveChangesAsync();
        }
    }
}
