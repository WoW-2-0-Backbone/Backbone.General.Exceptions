using System.Net;

namespace Backbone.General.Exceptions.Abstractions.Exceptions.General;

/// <summary>
/// Represents general application exception
/// </summary>
public abstract class AppException : Exception
{
    /// <inheritdoc />
    public AppException(string message) : base(message)
    {
    }

    /// <inheritdoc />
    public AppException(string message, Exception inner) : base(message, inner)
    {
    }

    /// <inheritdoc />
    public AppException(Exception inner) : base(inner.Message, inner)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual HttpStatusCode StatusCode => InnerException is AppException appException
        ? appException.StatusCode
        : HttpStatusCode.InternalServerError;
}