using CampClotNot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampClotNot.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Theme> Themes => Set<Theme>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<BoardSpace> BoardSpaces => Set<BoardSpace>();
    public DbSet<GroupBoardPos> GroupBoardPositions => Set<GroupBoardPos>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<ScriptedBlockHit> ScriptedBlockHits => Set<ScriptedBlockHit>();
    public DbSet<ScriptedMiniGame> ScriptedMiniGames => Set<ScriptedMiniGame>();
    public DbSet<User> Users => Set<User>();
    public DbSet<CamperAward> CamperAwards => Set<CamperAward>();
    public DbSet<CampSeason> CampSeasons => Set<CampSeason>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupBoardPos>()
            .HasKey(g => g.GroupId);

        modelBuilder.Entity<GroupBoardPos>()
            .HasOne(g => g.Group)
            .WithOne(g => g.BoardPos)
            .HasForeignKey<GroupBoardPos>(g => g.GroupId);

        // Store enums as strings for readability in the DB
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();

        modelBuilder.Entity<Transaction>()
            .Property(t => t.CurrencyType)
            .HasConversion<string>();

        modelBuilder.Entity<BoardSpace>()
            .Property(b => b.SpaceType)
            .HasConversion<string>();

        modelBuilder.Entity<CamperAward>()
            .Property(a => a.AwardType)
            .HasConversion<string>();
    }
}
