using CampClotNot.Data;
using CampClotNot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampClotNot.Repositories;

public class GroupRepository(AppDbContext db) : IGroupRepository
{
    public Task<List<Group>> GetAllAsync() =>
        db.Groups.Include(g => g.BoardPos).ToListAsync();

    public Task<Group?> GetByIdAsync(Guid groupId) =>
        db.Groups.Include(g => g.BoardPos).FirstOrDefaultAsync(g => g.GroupId == groupId);

    public async Task<Group> CreateAsync(Group group)
    {
        db.Groups.Add(group);
        await db.SaveChangesAsync();
        return group;
    }

    public async Task UpdateAsync(Group group)
    {
        db.Groups.Update(group);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid groupId)
    {
        var group = await db.Groups.FindAsync(groupId);
        if (group is not null)
        {
            db.Groups.Remove(group);
            await db.SaveChangesAsync();
        }
    }
}
