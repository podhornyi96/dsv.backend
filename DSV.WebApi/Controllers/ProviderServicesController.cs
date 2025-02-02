using DSV.Core.Domain.Contracts.ProviderServices;
using DSV.WebApi.Models.ProviderServices;
using Microsoft.AspNetCore.Mvc;

namespace DSV.WebApi.Controllers;

[Route("api/providers/{providerId:int}/services")]
public class ProviderServicesController : ApiControllerBase
{
    private readonly IProviderServiceAssigner _providerServiceAssigner;

    public ProviderServicesController(IProviderServiceAssigner providerServiceAssigner)
    {
        _providerServiceAssigner = providerServiceAssigner;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(
        [FromRoute] int providerId,
        [FromBody] CreateProviderService model)
    {
        var partnerService = await _providerServiceAssigner
            .AssignAsync(providerId, model.ServiceId, model.DurationMinutes, model.PricePerHour);
        
        return Ok(partnerService); // TODO: map
    }
}