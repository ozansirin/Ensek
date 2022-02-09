using Ensek.Data.Abstract;
using Ensek.Core.Model;
using Ensek.Core;
using System.Text.RegularExpressions;

namespace Ensek.Data.Concrete;

public class MeterReadingRepository : IMeterReadingRepository
{
    private readonly EnsekDbContext _dbContext;

    public MeterReadingRepository(EnsekDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public MeterReading Create(MeterReading entity)
    {
        if (Validate(entity))
        {
            _dbContext.MeterReadings.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        return null;
    }

    public void Delete(int Id)
    {
        var existEntity= _dbContext.MeterReadings.FirstOrDefault(x => x.Id == Id);
        _dbContext.MeterReadings.Remove(existEntity);
        _dbContext.SaveChanges();
    }

    public IEnumerable<MeterReading> GetAll()
    {
        return _dbContext.MeterReadings.ToList();
    }

    public MeterReading Update(MeterReading entity)
    {
        var existEntity = new MeterReading();
        existEntity = _dbContext.MeterReadings.FirstOrDefault(x => x.Id == entity.Id);
        if (existEntity != null) {
            existEntity.AccountId = entity.AccountId;
            existEntity.MeterReadingValue = entity.MeterReadingValue;
            existEntity.MeterReadingDateTime = entity.MeterReadingDateTime;
            _dbContext.SaveChanges();
            return existEntity;
        }
        return entity;
    }

    public bool Validate(MeterReading meterReading) {

        var meter= _dbContext.MeterReadings.Where(x=>x.AccountId == meterReading.AccountId).FirstOrDefault();

        if (meter != null) {
            return false;
        }
        string validationPattern = @"\b\d{5}\b";
        // Validatng value 
        if (!Regex.Match(meterReading.MeterReadingValue, validationPattern).Success)
        {
            return false;
        }

        return true;
    }
}
