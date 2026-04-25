namespace CampClotNot.Data.Entities;

public class BoardSpace
{
    public Guid SpaceId { get; set; }
    public Guid ThemeId { get; set; }
    public int SpaceIndex { get; set; }
    public SpaceType SpaceType { get; set; }
    public string Label { get; set; } = "";
    public string? IconAssetPath { get; set; }
    public float XPos { get; set; }
    public float YPos { get; set; }

    public Theme Theme { get; set; } = null!;
}
