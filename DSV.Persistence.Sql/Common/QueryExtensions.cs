using System.Linq.Expressions;

namespace DSV.Persistence.Sql.Common;

internal static class QueryExtensions
{
    public static IQueryable<T> WhereIfNotNullOrEmpty<T>(
        this IQueryable<T> source, 
        string? fieldValue, 
        Expression<Func<T, bool>> predicate)
    {
        return !string.IsNullOrEmpty(fieldValue) ? source.Where(predicate) : source;
    }

}
