namespace DSV.Core.Domain.Contracts.Exceptions;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
        
    }
}