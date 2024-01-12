namespace EntityFramework_practice.Entities.FluentContext;

public class Metadata
{
    public string CardNumber { get; set; }
    public string CardExpireData { get; set; }
    public string CVV { get; set; }
    public PaySystemInfo PaySystemInfo { get; set; }
}

public class PaySystemInfo
{
    public string Name { get; set; }
    public string SystemCode { get; set; }
}