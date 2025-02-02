namespace DSV.WebApi.Models.Providers;

public class CreateProvider
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Description { get; set; }
}