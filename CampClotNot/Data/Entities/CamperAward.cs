namespace CampClotNot.Data.Entities;

public class CamperAward
{
    public Guid AwardId { get; set; }
    public Guid GroupId { get; set; }
    public string RecipientName { get; set; } = "";
    public AwardType AwardType { get; set; }
    public int BonusStars { get; set; }
    public DateTime AwardedAt { get; set; }

    public Group Group { get; set; } = null!;
}
