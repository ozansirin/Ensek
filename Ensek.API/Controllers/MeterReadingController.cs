using Ensek.API.Model;
using Ensek.Core.Model;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Ensek.API.Service;
using AutoMapper;

namespace Ensek.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MeterReadingController : ControllerBase
{
    private readonly IContactAppService _appService;
    private Mapper mapper;
    public MeterReadingController(IContactAppService appService)
    {
        _appService = appService;
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MeterReading, MeterReadingDto>().ReverseMap());
        mapper = new Mapper(config);
    }

    [HttpGet]
    public ActionResult Get() {
        return Ok("Tamam");
    }

    [Route("meter-reading-uploads")]
    [HttpPost, DisableRequestSizeLimit]
    public ActionResult MeterReadingUploads() {

        var response = new HttpPostResponse();
        if (Request.Form.Files?.Count>0)
        {
            var file = Request.Form.Files[0];
            var reader = new StreamReader(file.OpenReadStream());
            using (var csvReader = new CsvReader(reader, CultureInfo.GetCultureInfo("en-GB")))
            {
                var meterData= csvReader.GetRecords<MeterReadingDto>().ToList();
                var meters = mapper.Map<IList<MeterReadingDto>, IList<MeterReading>>(meterData);
                response = _appService.CreateMeterReadings(meters);
                
            }
        }

        return Ok(response);
    }

}
