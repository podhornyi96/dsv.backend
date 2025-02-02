using DSV.Core.Domain.Contracts.Exceptions;
using DSV.Core.Domain.Contracts.ProviderServices.Commands;
using DSV.Core.Domain.Contracts.ProviderServices.Queries;
using DSV.Core.Domain.Contracts.Services;
using DSV.Core.Domain.Entities.Common;
using DSV.Core.Domain.Entities.Providers;
using DSV.Core.Domain.Entities.Services;
using DSV.Core.Services.ProviderServices;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSV.Core.Services.Tests.ProviderServices;

 [TestClass]
public class ProviderServiceAssignerTests
{
    private IMediator _mediator;
    private ProviderServiceAssigner _assigner;

    [TestInitialize]
    public void Setup()
    {
        _mediator = A.Fake<IMediator>();
        _assigner = new ProviderServiceAssigner(_mediator);
    }

    [TestMethod]
    public async Task AssignAsync_ShouldThrowNotFoundException_WhenServiceNotFound()
    {
        // Arrange
        const int serviceId = 100;
        A.CallTo(() => _mediator.Send(A<GetServiceQuery>.That.Matches(q => q.Id == serviceId), default))
            .Returns(Task.FromResult<Service?>(null));

        // Act
        Func<Task> act = async () => await _assigner.AssignAsync(1, serviceId, 30, 100m);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>().WithMessage("*Service*");
    }

    [TestMethod]
    public async Task AssignAsync_ShouldThrowBusinessException_WhenServiceAlreadyAssigned()
    {
        // Arrange
        const int providerId = 1;
        const int serviceId = 100;
        var service = new Service(serviceId, "Test Service");
        var providerServices = new ResultSet<ProviderService>(new[] { new ProviderService(1, serviceId, "Test Service", 20, 60) }, 1);
        
        A.CallTo(() => _mediator.Send(A<GetServiceQuery>.That.Matches(q => q.Id == serviceId), CancellationToken.None))!
            .Returns(Task.FromResult(service));
        A.CallTo(() => _mediator.Send(A<GetProviderServicesQuery>.That.Matches(q => q.ProviderId == providerId), default))
            .Returns(Task.FromResult(providerServices));

        // Act
        Func<Task> act = async () => await _assigner.AssignAsync(providerId, serviceId, 30, 100m);

        // Assert
        await act.Should().ThrowAsync<BusinessException>().WithMessage("*already been assigned*");
    }

    [TestMethod]
    public async Task AssignAsync_ShouldReturnProviderService_WhenSuccessfullyAssigned()
    {
        // Arrange
        const int providerId = 1;
        const int serviceId = 100;
        var service = new Service(serviceId, "Test Service");
        var providerServices = new ResultSet<ProviderService>(Array.Empty<ProviderService>(), 0);
        var expectedProviderService = new ProviderService(1, serviceId, "Test Service", 100m, 30);
        
        A.CallTo(() => _mediator.Send(A<GetServiceQuery>.That.Matches(q => q.Id == serviceId), CancellationToken.None))!
            .Returns(Task.FromResult(service));
        A.CallTo(() => _mediator.Send(A<GetProviderServicesQuery>.That.Matches(q => q.ProviderId == providerId), default))
            .Returns(Task.FromResult(providerServices));
        A.CallTo(() => _mediator.Send(A<CreateProviderServiceCommand>.Ignored, default))
            .Returns(Task.FromResult(expectedProviderService));

        // Act
        var result = await _assigner.AssignAsync(providerId, serviceId, 30, 100m);

        // Assert
        result.Should().BeEquivalentTo(expectedProviderService);
    }
}