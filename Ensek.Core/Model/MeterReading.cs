using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensek.Core.Model;


/// <summary>
/// meter reading data model for validating accounts
/// </summary>
public class MeterReading
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int AccountId { get; set; }

    public DateTime MeterReadingDateTime { get; set; }

    public string MeterReadingValue { get; set; }
}
