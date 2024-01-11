using System.Globalization;
using EntityFramework_practice.DataContext.ForFluentContext;
using EntityFramework_practice.Entities.FluentContext;

using Microsoft.EntityFrameworkCore;

namespace EntityFramework_practice.Repositories.ForFluentApi;

public class SeedData(DbFluentContext context)
{
    private readonly DbFluentContext _context = context;

    public async Task<IEnumerable<User>> InitData()
    {
        await RemoveDataInDb();
        await InitUsers();
        await InitTransactions();
        return _context.Users.Include(x => x.BankAccount).ThenInclude(x => x.TransactionHistories).Select(x =>
            new User()
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
                    TransactionHistories = x.BankAccount.TransactionHistories.Select(tr => new TransactionHistory()
                        {
                            Id = tr.Id,
                            ToAccountId = tr.ToAccountId,
                            FromAccountId = tr.FromAccountId,
                            ActionType = tr.ActionType,
                            CreatedTime = tr.CreatedTime,
                            AmountMoney = tr.AmountMoney
                        }).ToList()
                }
            });
    }

    private async Task InitTransactions()
    {
        var bankAccounts = _context.BankAccounts.ToList();
        var transactionList = new List<TransactionHistory>();
        int transactIdx = 1;
        foreach (var sender in bankAccounts)
        {
            foreach (var receiver in bankAccounts)
            {
                if (sender != receiver)
                {
                    var transactionSend = new TransactionHistory
                    {
                        Id = transactIdx++,
                        CreatedTime = DateTime.Now.ToString(CultureInfo.CurrentCulture),
                        ActionType = "SEND",
                        AmountMoney = 100,
                        FromAccount = sender,
                        FromAccountId = sender.Id,
                        ToAccountId = receiver.Id
                    };

                    var transactionReceive = new TransactionHistory
                    {
                        Id = transactIdx++,
                        CreatedTime = DateTime.Now.ToString(CultureInfo.CurrentCulture),
                        ActionType = "RECEIVE",
                        AmountMoney = 100,
                        FromAccount = sender,
                        FromAccountId = sender.Id,
                        ToAccountId = receiver.Id
                    };

                    sender.Balance -= 100;
                    _context.BankAccounts.Update(sender);

                    receiver.Balance += 100;
                    _context.BankAccounts.Update(receiver);

                    transactionList.Add(transactionSend);
                    transactionList.Add(transactionReceive);
                }
            }
        }

        await _context.TransactionHistories.AddRangeAsync(transactionList);
        await _context.SaveChangesAsync();
    }

    private async Task InitUsers()
    {
        var users = Enumerable.Range(0, 5).Select(i => new User()
        {
            Id = i + 1,
            Name = "Name" + i,
            Surname = "Name" + i,
            CreatedTime = DateTime.Now.ToString(CultureInfo.CurrentCulture),
            BankAccount = new BankAccount()
            {
                Id = i + 1,
                CreatedTime = DateTime.Now.ToString(CultureInfo.CurrentCulture),
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