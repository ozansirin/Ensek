using Ensek.API.Model;
using Ensek.Business.Abstract;
using Ensek.Core.Model;

namespace Ensek.API.Service;

public class ContactAppService : IContactAppService
{
    private readonly IMeterReadingService _meterReadingService;
    private readonly IAccountService _accountService;

    public ContactAppService(IMeterReadingService meterReadingService,
        IAccountService accountService)
    {
        _meterReadingService = meterReadingService;
        _accountService = accountService;
    }

    public HttpPostResponse CreateAccounts(IList<Account> accounts)
    {
        var response = new HttpPostResponse();
        var addedCount = 0;
        var notAddedCount = 0;

        foreach (var model in accounts)
        {
            try
            {
                _accountService.CreateAccount(model);
                addedCount++;
            }
            catch (Exception ex)
            {
                //TODO: Log exception
                notAddedCount++;
            }
        }

        response.Added = addedCount;
        response.NotAdded = notAddedCount;

        return response;
    }

    public HttpPostResponse CreateMeterReadings(IList<MeterReading> meterReadings)
    {
        var response = new HttpPostResponse();
        var addedCount = 0;
        var notAddedCount = 0;

        foreach (var model in meterReadings)
        {
            try
            {
                _meterReadingService.CreateMeterReading(model);
                addedCount++;
            }
            catch (Exception ex)
            {
                //TODO: Log exception
                notAddedCount++;
            }
        }
        
        response.Added = addedCount;
        response.NotAdded = notAddedCount;

        return response;
    }
}
