namespace DSV.Core.Domain.Entities.Providers;

public class Provider
{
    public Provider(int id)
    {
        Id = id;
    }

    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}