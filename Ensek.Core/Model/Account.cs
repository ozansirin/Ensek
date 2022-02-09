using System.ComponentModel.DataAnnotations;

namespace Ensek.Core.Model;

/// <summary>
/// Accounts database model
/// </summary>
public class Account
{
    [Key]
    public int Id { get; set; }
    public int AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
