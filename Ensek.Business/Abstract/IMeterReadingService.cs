using Ensek.Core.Model;
namespace Ensek.Business.Abstract;

/*
 * Genereted new interface for Loose coupling
 */ 

public interface IMeterReadingService
{
    public MeterReading CreateMeterReading(MeterReading entity);

    public void DeleteMeterReading(int Id);

    public IEnumerable<MeterReading> GetAll();

    public MeterReading UpdateMeterReading(MeterReading entity);
}
