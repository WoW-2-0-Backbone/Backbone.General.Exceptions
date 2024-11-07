using System.Net;

namespace Backbone.General.Exceptions.Abstractions.Exceptions.General;

/// <summary>
/// Defines the app exception properties.
/// </summary>
public interface IAppException
{
    /// <summary>
    /// Gets the status code of the exception.
    /// </summary>
    HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Gets or sets the metadata of the exception.
    /// </summary>
    Dictionary<string, string> Meta { get; }
}