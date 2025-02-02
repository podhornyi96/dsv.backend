using DSV.Core.Domain.Contracts.Providers.Commands;
using DSV.Core.Domain.Contracts.Providers.Queries;
using DSV.WebApi.Common.Filters;
using DSV.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DSV.WebApi.Controllers;

[Route("api/providers")]
[ApiExceptionFilter]
public class ProvidersController : ApiControllerBase
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
        
        return Ok(provider); // TODO: add mapping from domain to web api model
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] Provider model)
    {
        var provider = new Core.Domain.Entities.Providers.Provider(id, model.FirstName, model.LastName, 
            model.Email, model.Description);

        var result = await _mediator.Send(new UpdateProviderCommand(provider));

        return Ok(result); // TODO: map to web api model
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        await _mediator.Send(new DeleteProviderCommand(id));

        return NoContent();
    }
    
}