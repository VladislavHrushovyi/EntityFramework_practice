﻿namespace EntityFramework_practice.Entities.FluentApi;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public BankAccount BankAccount { get; set; }
    public int BankAccountId { get; set; }
}