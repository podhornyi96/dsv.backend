using AutoMapper;
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
    private readonly IMapper _mapper;

    public ProvidersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Provider>>> GetAsync(
        [FromQuery] int skip, 
        [FromQuery] int take, 
        [FromQuery] string? firstName)
    {
        var providers = await _mediator.Send(new GetProvidersQuery(skip, take, firstName));
        
        return Ok(_mapper.Map<ResultSet<Provider>>(providers));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync([FromRoute] int id)
    {
        var provider = await _mediator.Send(new GetProviderQuery(id));
        
        return provider is null ? NotFound() : Ok(_mapper.Map<Provider>(provider));
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] CreateProvider createProvider)
    {
        var provider = await _mediator.Send(new CreateProviderCommand(createProvider.FirstName, createProvider.LastName, 
            createProvider.Email, createProvider.Description));
        
        return Ok(_mapper.Map<Provider>(provider));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] Provider model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }
        
        var provider = _mapper.Map<Core.Domain.Entities.Providers.Provider>(model);
        var result = await _mediator.Send(new UpdateProviderCommand(provider));

        return Ok(_mapper.Map<Provider>(result));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        await _mediator.Send(new DeleteProviderCommand(id));

        return NoContent();
    }
    
}