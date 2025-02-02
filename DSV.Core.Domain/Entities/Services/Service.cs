namespace DSV.Core.Domain.Entities.Services;

public class Service
{
    public Service(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}