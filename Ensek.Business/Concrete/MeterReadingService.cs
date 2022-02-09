using Ensek.Business.Abstract;
using Ensek.Core.Model;
using Ensek.Data.Abstract;

namespace Ensek.Business.Concrete;

public class MeterReadingService : IMeterReadingService
{
    private readonly IMeterReadingRepository repository;

    public MeterReadingService(IMeterReadingRepository _repository)
    {
        repository = _repository;
    }

    public MeterReading CreateMeterReading(MeterReading entity)
    {
        if (Validate(entity))
        {
            return repository.Create(entity);

        }

        throw new Exception("Meter reading is invalid");
    }

    public void DeleteMeterReading(int Id)
    {
        repository.Delete(Id);  
    }

    public IEnumerable<MeterReading> GetAll()
    {
        return repository.GetAll(); 
    }

    public MeterReading UpdateMeterReading(MeterReading entity)
    {
        return repository.Update(entity);
    }

    private bool Validate(MeterReading meterReading) {
        
        return repository.Validate(meterReading);
    }
}
