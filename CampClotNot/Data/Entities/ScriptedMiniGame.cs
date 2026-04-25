namespace CampClotNot.Data.Entities;

public class ScriptedMiniGame
{
    public Guid ScriptId { get; set; }
    public int CampDay { get; set; }
    public string ActivityLabel { get; set; } = "";
    public bool IsTriggered { get; set; }
}
