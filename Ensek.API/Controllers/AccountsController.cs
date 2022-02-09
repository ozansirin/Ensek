using AutoMapper;
using CsvHelper;
using Ensek.API.Model;
using Ensek.API.Service;
using Ensek.Core.Model;

using Microsoft.AspNetCore.Mvc;

using System.Globalization;

namespace Ensek.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{

    private readonly IContactAppService _appService;
    private Mapper mapper;
    public AccountsController(IContactAppService appService)
    {
        _appService = appService;
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDto>().ReverseMap());
        mapper = new Mapper(config);
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Tamam");
    }

    [Route("account-uploads")]
    [HttpPost, DisableRequestSizeLimit]
    public ActionResult MeterReadingUploads()
    {

        var response = new HttpPostResponse();
        if (Request.Form.Files?.Count > 0)
        {
            var file = Request.Form.Files[0];
            var reader = new StreamReader(file.OpenReadStream());
            using (var csvReader = new CsvReader(reader, CultureInfo.GetCultureInfo("en-GB")))
            {
                var accountData = csvReader.GetRecords<AccountDto>().ToList();
                var account = mapper.Map<IList<AccountDto>, IList<Account>>(accountData);
                response = _appService.CreateAccounts(account);

            }
        }

        return Ok(response);
    }
}
