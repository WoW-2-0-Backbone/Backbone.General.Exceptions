using System.Net;

namespace Backbone.General.Exceptions.Abstractions.Exceptions.General;

/// <summary>
/// Represents general application exception
/// </summary>
public class AppException : Exception, IAppException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="statusCode">Optional HTTP status code for this exception.</param>
    /// <param name="meta">Optional metadata for additional information.</param>
    public AppException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        Dictionary<string, string>? meta = null)
        : base(message)
    {
        StatusCode = statusCode;
        Meta = meta ?? new Dictionary<string, string>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppException"/> class with a specified error message and inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that caused the current exception.</param>
    /// <param name="statusCode">Optional HTTP status code for this exception.</param>
    /// <param name="meta">Optional metadata for additional information.</param>
    public AppException(
        string message,
        Exception innerException,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        Dictionary<string, string>? meta = null)
        : base(message, innerException)
    {
        StatusCode = innerException is AppException appException ? appException.StatusCode : statusCode;
        Meta = meta ?? new Dictionary<string, string>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppException"/> class with an inner exception.
    /// </summary>
    /// <param name="inner">The exception that caused the current exception.</param>
    /// <param name="statusCode">Optional HTTP status code for this exception.</param>
    /// <param name="meta">Optional metadata for additional information.</param>
    public AppException(
        Exception inner,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        Dictionary<string, string>? meta = null)
        : base(inner.Message, inner)
    {
        StatusCode = statusCode;
        Meta = meta ?? new Dictionary<string, string>();
    }

    /// <inheritdoc />
    public HttpStatusCode StatusCode { get; init; }
    
    /// <inheritdoc />
    public Dictionary<string, string> Meta { get; init; }
}