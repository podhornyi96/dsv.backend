namespace DSV.Persistence.Sql.Entities;

public class Provider
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Description { get; set; }
    public ICollection<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();
}