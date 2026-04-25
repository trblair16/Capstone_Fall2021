namespace CampClotNot.Data.Entities;

public class Theme
{
    public Guid ThemeId { get; set; }
    public string Name { get; set; } = "";
    public int Year { get; set; }
    public string CurrencyName1 { get; set; } = "Coins";
    public string CurrencyName2 { get; set; } = "Stars";
    public bool IsActive { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();
    public ICollection<BoardSpace> BoardSpaces { get; set; } = new List<BoardSpace>();
}
