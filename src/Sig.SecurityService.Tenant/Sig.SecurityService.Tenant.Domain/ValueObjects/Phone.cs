namespace Sig.SecurityServiceTenant.Domain.ValueObjects;

public class Phone
{
    public int Ddd { get; set; }
    public long Number { get; set; }
    public string FormattedNumber => $"({Ddd}) {Number}";
    public Phone(int ddd, long number)
    {
        Ddd = ddd;
        Number = number;
    }
}
