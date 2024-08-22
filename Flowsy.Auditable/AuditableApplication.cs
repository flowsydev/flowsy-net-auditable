using System.Collections.ObjectModel;
using System.Text;

namespace Flowsy.Auditable;

/// <summary>
/// Represents auditable information about an application.
/// </summary>
public sealed class AuditableApplication : AuditableTrail
{
    /// <summary>
    /// Initializes an empty instance of the <see cref="AuditableApplication"/> class.
    /// </summary>
    public AuditableApplication() : this(string.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableApplication"/> class.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the application.
    /// </param>
    public AuditableApplication(string id) : this (id, string.Empty)
    {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableApplication"/> class.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="alias"></param>
    /// <param name="version"></param>
    /// <param name="details"></param>
    public AuditableApplication(string id, string alias, AuditableVersion? version = null, IReadOnlyDictionary<string, object?>? details = null) 
        : base(details ?? new ReadOnlyDictionary<string, object?>(new Dictionary<string, object?>()))
    {
        Id = id;
        Alias = alias;
        Version = version;
    }

    /// <summary>
    /// The unique identifier of the application.
    /// </summary>
    public string Id { get; private set; }
    
    /// <summary>
    /// The alias of the application.
    /// </summary>
    public string Alias { get; private set; }
    
    /// <summary>
    /// The version of the application.
    /// </summary>
    public AuditableVersion? Version { get; private set; }
    
    /// <summary>
    /// Returns a string that represents the application object.
    /// </summary>
    /// <returns>
    /// A string that represents the application object.
    /// </returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append(string.IsNullOrEmpty(Alias) ? "Anonymous Application" : Alias);

        if (!string.IsNullOrEmpty(Id))
            stringBuilder.Append($", {Id}");
        
        if (Version is not null)
            stringBuilder.Append($", v{Version}");

        return stringBuilder.ToString();
    }
}