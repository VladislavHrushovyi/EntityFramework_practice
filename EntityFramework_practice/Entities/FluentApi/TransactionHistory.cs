namespace EntityFramework_practice.Entities.FluentApi;

public class TransactionHistory : BaseEntity
{
    public BankAccount FromAccount { get; set; }
    public int FromAccountId { get; set; }

    public BankAccount ToAccount { get; set; }
    public int ToAccountId { get; set; }

    public float AmountMoney { get; set; }
    public string ActionType { get; set; }
}