using DSV.Core.Domain.Entities.Services;
using MediatR;

namespace DSV.Core.Domain.Contracts.Services;

public class GetAllServicesQuery : IRequest<IReadOnlyList<Service>> {}