namespace DSV.WebApi.Models;

public class ResultSet<T>
{
    public ResultSet(IReadOnlyList<T> items, int totalCount)
    {
        Items = items;
        TotalCount = totalCount;
    }

    public IReadOnlyList<T> Items { get; }
    public int TotalCount { get; }
}