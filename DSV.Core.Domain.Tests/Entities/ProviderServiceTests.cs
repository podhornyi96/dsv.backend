using DSV.Core.Domain.Entities.Providers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSV.Core.Domain.Tests.Entities;

[TestClass]
public class ProviderServiceTests
{
    [TestMethod]
    public void PricePerSession_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        int id = 1;
        int serviceId = 100;
        string name = "Test Service";
        decimal pricePerHour = 120m;
        int durationMinutes = 30;
        decimal expectedPricePerSession = pricePerHour / 60 * durationMinutes;

        // Act
        var providerService = new ProviderService(id, serviceId, name, pricePerHour, durationMinutes);

        // Assert
        providerService.Id.Should().Be(id);
        providerService.ServiceId.Should().Be(serviceId);
        providerService.Name.Should().Be(name);
        providerService.PricePerHour.Should().Be(pricePerHour);
        providerService.DurationMinutes.Should().Be(durationMinutes);
        providerService.PricePerSession.Should().Be(expectedPricePerSession);
    }

    [TestMethod]
    public void PricePerSession_ShouldCalculateCorrectly()
    {
        // Arrange
        decimal pricePerHour = 20;
        int durationMinutes = 60;
        decimal expectedPricePerSession = pricePerHour / 60 * durationMinutes;

        // Act
        var providerService = new ProviderService(2, 101, "Sample Service", pricePerHour, durationMinutes);

        // Assert
        providerService.PricePerSession.Should().Be(expectedPricePerSession);
    }
    
    
    [TestMethod]
    public void PricePerSession_ShouldThrowException_WhenPricePerHourIsNegative()
    {
        // Arrange
        Action act = () => new ProviderService(3, 102, "Invalid Service", -100m, 30);

        // Act & Assert
        act.Should().Throw<ArgumentException>().WithMessage("*pricePerHour*");
    }

    [TestMethod]
    public void PricePerSession_ShouldThrowException_WhenDurationMinutesIsNegative()
    {
        // Arrange
        Action act = () => new ProviderService(4, 103, "Invalid Service", 100m, -30);

        // Act & Assert
        act.Should().Throw<ArgumentException>().WithMessage("*durationMinutes*");
    }
    
}