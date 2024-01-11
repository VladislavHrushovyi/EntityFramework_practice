namespace EntityFramework_practice.Entities.FluentContext;

public class TransactionHistory : BaseEntity
{
    public BankAccount FromAccount { get; set; }
    public int FromAccountId { get; set; }

    public BankAccount ToAccount { get; set; }
    public int ToAccountId { get; set; }

    public float AmountMoney { get; set; }
    public string ActionType { get; set; }
}