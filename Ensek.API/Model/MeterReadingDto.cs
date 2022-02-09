using CsvHelper.Configuration.Attributes;

namespace Ensek.API.Model;

public class MeterReadingDto
{
    public int AccountId { get; set; }

    public DateTime MeterReadingDateTime { get; set; }

    [Name("MeterReadValue")]
    public string MeterReadingValue { get; set; }
}
