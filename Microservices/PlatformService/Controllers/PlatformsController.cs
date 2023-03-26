using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SynDataServices.Http;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _respository;
    private readonly IMapper _mapper;
    private readonly ICommandDataClient _commandDataClient;

    public PlatformsController(
        ICommandDataClient commandDataClient, 
        IPlatformRepo respository, 
        IMapper mapper)
    {
        _respository = respository;
        _mapper = mapper;
        _commandDataClient = commandDataClient;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("--> Getting Platforms...");

        var platfromItems = _respository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platfromItems));
    }

    [HttpGet("{id}", Name="GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platformItem = _respository.GetPlatformById(id);
        if (platformItem != null)
        {
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCrateDto)
    {
        var platformModel = _mapper.Map<Platform>(platformCrateDto);
        _respository.CreatePlatform(platformModel);
        _respository.SaveChanges();

        var platfromReadDto = _mapper.Map<PlatformReadDto>(platformModel);

        try
        {
            await _commandDataClient.SendPlatformToCommand(platfromReadDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Could not send synchronsoly: {ex.Message}");
        }

        return CreatedAtRoute(nameof(GetPlatformById), new { Id = platfromReadDto.Id}, platfromReadDto);
    }
}