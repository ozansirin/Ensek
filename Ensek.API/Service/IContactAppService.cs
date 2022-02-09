using Ensek.API.Model;
using Ensek.Core.Model;

namespace Ensek.API.Service;

public interface IContactAppService
{
    HttpPostResponse CreateMeterReadings(IList<MeterReading> meterReadings);

    HttpPostResponse CreateAccounts(IList<Account> accounts);
}
