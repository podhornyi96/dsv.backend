using AutoMapper;
using DSV.Core.Domain.Contracts.ProviderServices;
using DSV.Core.Domain.Contracts.ProviderServices.Queries;
using DSV.WebApi.Models;
using DSV.WebApi.Models.ProviderServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DSV.WebApi.Controllers;

[Route("api/providers/{providerId:int}/services")]
public class ProviderServicesController : ApiControllerBase
{
    private readonly IProviderServiceAssigner _providerServiceAssigner;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProviderServicesController(IProviderServiceAssigner providerServiceAssigner, IMediator mediator, IMapper mapper)
    {
        _providerServiceAssigner = providerServiceAssigner;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(
        [FromRoute] int providerId,
        [FromBody] CreateProviderService model)
    {
        var providerService = await _providerServiceAssigner
            .AssignAsync(providerId, model.ServiceId, model.DurationMinutes, model.PricePerHour);
        
        return Ok(_mapper.Map<ProviderService>(providerService));
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync([FromRoute] int providerId,
        [FromQuery] int skip,
        [FromQuery] int take)
    {
        var providerServices = await _mediator.Send(new GetProviderServicesQuery(providerId, skip, take));
        
        return Ok(_mapper.Map<ResultSet<ProviderService>>(providerServices));
    }
    
}