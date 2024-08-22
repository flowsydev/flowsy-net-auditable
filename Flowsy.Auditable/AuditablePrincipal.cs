using System.Collections.ObjectModel;
using System.Text;

namespace Flowsy.Auditable;

/// <summary>
/// Represents auditable information about a principal.
/// Application principals are entities that can be authenticated by the system, such as users and applications.
/// </summary>
public sealed class AuditablePrincipal : AuditableTrail
{
    /// <summary>
    /// Initializes an empty instance of the <see cref="AuditablePrincipal"/> class.
    /// </summary>
    public AuditablePrincipal() 
        : this(string.Empty, string.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditablePrincipal"/> class.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the principal.
    /// This shall be a UUID string or some kind of unique value used to identify the principal.
    /// </param>
    /// <param name="alias">
    /// The alias of the principal.
    /// This shall be the friendly name of the principal, such as the user's full name, the user's email address, the application's name, etc.
    /// </param>
    /// <param name="details">
    /// The details of the principal.
    /// </param>
    public AuditablePrincipal(string id, string alias, IReadOnlyDictionary<string, object?>? details = null) : base(details)
    {
        Id = id;
        Alias = alias;
    }

    /// <summary>
    /// The unique identifier of the principal.
    /// This shall be a UUID string or some kind of unique value used to identify the principal.
    /// </summary>
    public string Id { get; private set; }
    
    /// <summary>
    /// The alias of the principal.
    /// This shall be the friendly name of the principal, such as the user's full name, the user's email address, the application's name, etc.
    /// </summary>
    public string Alias { get; private set; }

    /// <summary>
    /// Returns a string that represents the principal object.
    /// </summary>
    /// <returns>
    /// A string that represents the principal object.
    /// </returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        
        stringBuilder.Append(string.IsNullOrEmpty(Alias) ? "Anonymous User" : Alias);
        
        if (!string.IsNullOrEmpty(Id))
            stringBuilder.Append($" ({Id})");

        if (Details.Any())
        {
            var details = string.Join(", ", Details.Select(x => $"{x.Key}: {x.Value}"));
            stringBuilder.Append($" [{details}]");
        }
        
        return stringBuilder.ToString();
    }
}