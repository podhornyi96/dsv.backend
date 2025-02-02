using AutoMapper;
using DSV.Core.Domain.Contracts.Services;
using DSV.Persistence.Sql.Migrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DSV.WebApi.Controllers;

[Route("api/services")]
public class ServicesController : ApiControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ServicesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Service>>> GetServices()
    {
        var services = await _mediator.Send(new GetAllServicesQuery());
        
        return Ok(_mapper.Map<IReadOnlyList<Models.Service>>(services));
    }
    
}