namespace EntityFramework_practice.Entities.FluentApi;

public class TransactionHistory : BaseEntity
{
    public User FromUser { get; set; }
    public string FromAccountId { get; set; }

    public User ToUser { get; set; }
    public string ToAccountId { get; set; }

    public float AmountMoney { get; set; }
    public string ActionType { get; set; }
}