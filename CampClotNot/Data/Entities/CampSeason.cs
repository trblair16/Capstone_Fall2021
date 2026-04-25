namespace CampClotNot.Data.Entities;

public class CampSeason
{
    public Guid SeasonId { get; set; }
    public Guid ThemeId { get; set; }
    public int Year { get; set; }
    public bool IsLocked { get; set; }
    public DateTime? LockedAt { get; set; }
    public string? LockedBy { get; set; }

    public Theme Theme { get; set; } = null!;
}
