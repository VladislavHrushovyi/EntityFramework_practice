namespace EntityFramework_practice.Entities.FluentContext;

public class BankAccount : BaseEntity
{
    public float Balance { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }

    //public Metadata Metadata { get; set; }
    public ICollection<TransactionHistory> TransactionHistories { get; set; }
}