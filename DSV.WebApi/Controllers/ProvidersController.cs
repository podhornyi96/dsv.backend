using DSV.Core.Domain.Contracts.Providers;
using DSV.Core.Domain.Contracts.Providers.Commands;
using DSV.Core.Domain.Contracts.Providers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DSV.WebApi.Controllers;

[Route("api/providers")]
public class ProvidersController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProvidersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetProviderQuery(id));
        
        return result is null ? NotFound() : Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] CreateProviderCommand createProvider)
    {
        // TODO: can be added mapper between WebApi model and Domain model
        var provider = await _mediator.Send(new CreateProviderCommand(createProvider.FirstName, createProvider.LastName, 
            createProvider.Email, createProvider.Description));
        
        return Ok(provider);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        await _mediator.Send(new DeleteProviderCommand(id));

        return NoContent();
    }
    
}