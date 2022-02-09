using Ensek.Core.Model;
namespace Ensek.Data.Abstract;

/*
 * Genereted new interface for Loose coupling
 */ 

public interface IMeterReadingRepository : IRepository<MeterReading>
{
    bool Validate(MeterReading meterReading);
}
