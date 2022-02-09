using Ensek.Business.Concrete;
using Ensek.Core.Model;
using Ensek.Data.Abstract;
using Moq;
using Xunit;

namespace Ensek.Test;
public class FunctionalTests
{

    [Fact]
    public void IsMeterReadingSuccess()
    {
        var mockService = new Mock<IMeterReadingRepository>();

        var meterReadingService = new MeterReadingService(mockService.Object);
        var mockData = new MeterReading();
        mockData.Id = 0;
        mockData.AccountId = 2344;
        mockData.MeterReadingDateTime = System.DateTime.Now;
        mockData.MeterReadingValue = "89058";
        //ACT
        mockData = meterReadingService.CreateMeterReading(mockData);

        //ASSERT
        Assert.True(mockData.Id > 0);
    }


    [Fact]
    public void IsMeterReadingAlreadyExist()
    {

        var mockService = new Mock<IMeterReadingRepository>();

        var meterReadingService = new MeterReadingService(mockService.Object);

        var mockData = new MeterReading();
        mockData.Id = 1;
        mockData.AccountId = 2344;
        mockData.MeterReadingDateTime = System.DateTime.Now;
        mockData.MeterReadingValue = "89058";
        var result = true;
        //ACT
        try
        {
            mockData = meterReadingService.CreateMeterReading(mockData);
            result = false;
        }
        catch (System.Exception)
        {
            result = true;
        }


        //ASSERT
        Assert.True(result);
    }

    [Fact]
    public void IsMeterReadingValueNotCorrect()
    {
        var mockService = new Mock<IMeterReadingRepository>();

        var meterReadingService = new MeterReadingService(mockService.Object);
        var mockData = new MeterReading();
        mockData.Id = 0;
        mockData.AccountId = 2344;
        mockData.MeterReadingDateTime = System.DateTime.Now;
        mockData.MeterReadingValue = "XJDKS";
        var result = true;
        //ACT
        try
        {
            mockData = meterReadingService.CreateMeterReading(mockData);
            result = false;
        }
        catch (System.Exception)
        {
            result = true;
        }


        //ASSERT
        Assert.True(result);
    }
}