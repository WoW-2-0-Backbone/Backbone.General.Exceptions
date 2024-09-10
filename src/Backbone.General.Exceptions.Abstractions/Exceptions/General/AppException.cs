using System.Net;

namespace Backbone.General.Exceptions.Abstractions.Exceptions.General;

/// <summary>
/// Represents general application exception
/// </summary>
public abstract class AppException : Exception
{
    public AppException(string message) : base(message)
    {
    }

    public AppException(string message, Exception inner) : base(message, inner)
    {
    }

    public AppException(Exception inner) : base(inner.Message, inner)
    {
    }
    
    public virtual HttpStatusCode StatusCode => InnerException is AppException appException
        ? appException.StatusCode
        : HttpStatusCode.InternalServerError;
}