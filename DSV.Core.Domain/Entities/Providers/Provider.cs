namespace DSV.Core.Domain.Entities.Providers;

public class Provider
{
    public Provider(int id, string firstName, string lastName, 
        string email, string? description)
    {
        // TODO: add checks
        
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Description = description;
    }

    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string? Description { get; set; }
}