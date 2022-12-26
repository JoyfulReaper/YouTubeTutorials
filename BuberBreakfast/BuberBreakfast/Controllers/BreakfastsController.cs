using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using BuberBreakfast.Services.Breakfasts;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

public class BreakfastsController : ApiController
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastsController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var requestToBreakfastResult = Breakfast.From(request);

        if(requestToBreakfastResult.IsError)
        {
            return Problem(requestToBreakfastResult.Errors);
        }

        var breakfast = requestToBreakfastResult.Value;
        var createBreakfastResponse = _breakfastService.CreateBreakfast(breakfast);

        return createBreakfastResponse.Match(
            created => CreatedAsGetBreakfast(breakfast),
            errors => Problem(errors));
    }

    private IActionResult CreatedAsGetBreakfast(Breakfast breakfast)
    {
        return CreatedAtAction(
                    nameof(GetBreakfast),
                    new { id = breakfast.Id },
                    value: MapBreakfastResponse(breakfast));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);

        return getBreakfastResult.Match(
            breakfast => Ok(MapBreakfastResponse(breakfast)),
            errors => Problem(errors));

        // if (getBreakfastResult.IsError &&
        //     getBreakfastResult.FirstError == Errors.Breakfast.NotFound)
        // {
        //     return NotFound();
        // }

        // var breakfast = getBreakfastResult.Value;
        // BreakfastResponse response = MapBreakfastResponse(breakfast);

        //return Ok(response);
    }

    private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        return new BreakfastResponse(
                    breakfast.Id,
                    breakfast.Name,
                    breakfast.Description,
                    breakfast.StartDateTime,
                    breakfast.EndDateTime,
                    breakfast.LastModifedDateTime,
                    breakfast.Savory,
                    breakfast.Sweet);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        var requestBreakfastResult = Breakfast.From(id, request);

        if (requestBreakfastResult.IsError)
        {
            return Problem(requestBreakfastResult.Errors);
        }

        var breakfast = requestBreakfastResult.Value;
        var upsertedBreakfastResult = _breakfastService.UpsertBreakfast(breakfast);

        return upsertedBreakfastResult.Match(
            upserted => upserted.IsNewlyCreated
                ? CreatedAsGetBreakfast(breakfast)
                : NoContent(),
            errors => Problem(errors));
    }

     [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        var deleteBreakfastResult = _breakfastService.DeleteBreakfast(id);
        return deleteBreakfastResult.Match(
            _ => NoContent(),
            errors => Problem(errors));
    }
}