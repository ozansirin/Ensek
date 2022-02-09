using CsvHelper.Configuration.Attributes;

namespace Ensek.API.Model;

public class AccountDto
{
    public int AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
