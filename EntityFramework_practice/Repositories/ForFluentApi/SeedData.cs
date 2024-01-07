using EntityFramework_practice.DataContext.ForFluentContext;
using EntityFramework_practice.Entities.FluentApi;

namespace EntityFramework_practice.Repositories.ForFluentApi;

public class SeedData(DbFluentContext context)
{
    private readonly DbFluentContext _context = context;

    public async Task<IEnumerable<User>> InitData()
    {
        await RemoveDataInDb();
        await InitUsers();
        //await InitBankAccounts();
        await InitTransactions();
        return _context.Users.Select(x => new User()
        {
            Id = x.Id,
            Name = x.Name,
            Surname = x.Surname,
            BankAccountId = x.BankAccountId,
            CreatedTime = x.CreatedTime,
            BankAccount = new BankAccount()
            {
                Id = x.BankAccount.Id,
                UserId = x.BankAccount.UserId,
                Balance = x.BankAccount.Balance,
                CreatedTime = x.BankAccount.CreatedTime,
            }
        });
    }

    private async Task InitTransactions()
    {
        
    }

    // private async Task InitBankAccounts()
    // {
    //     
    // }

    private async Task InitUsers()
    {
        var users = Enumerable.Range(0,5).Select(i => new User()
        {
            Id = i + 1,
            Name = "Name" + i,
            Surname = "Name" + i,
            CreatedTime = DateTime.Now,
            BankAccount = new BankAccount()
            {
                Id = i + 1,
                CreatedTime = DateTime.Now,
                Balance = 10_000,
                UserId = i + 1,
            },
            BankAccountId = i + 1
        });

        await _context.AddRangeAsync(users);
        await _context.SaveChangesAsync();
    }

    private async Task RemoveDataInDb()
    {
        _context.Users.RemoveRange(_context.Users);
        _context.BankAccounts.RemoveRange(_context.BankAccounts);
        _context.TransactionHistories.RemoveRange(_context.TransactionHistories);

        await _context.SaveChangesAsync();
    }
}