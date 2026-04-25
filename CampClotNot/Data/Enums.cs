namespace CampClotNot.Data;

public enum UserRole { Admin, Staff, Display }

public enum SpaceType { Start, Challenge, CoinBonus, Prestige, Penalty }

/// <summary>
/// System name for currency type. Display strings (e.g. "Coins", "Stars") come from Theme config.
/// </summary>
public enum CurrencyType { Primary, Prestige }

public enum AwardType { Named, BigStick, Branch }
