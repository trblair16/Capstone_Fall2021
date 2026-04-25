namespace CampClotNot.Data.Entities;

public class Transaction
{
    public Guid TxId { get; set; }
    public Guid GroupId { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public int Amount { get; set; }
    public string? Note { get; set; }
    public string LoggedBy { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public DateTime? VoidedAt { get; set; }
    public string? VoidedBy { get; set; }

    public Group Group { get; set; } = null!;
}
