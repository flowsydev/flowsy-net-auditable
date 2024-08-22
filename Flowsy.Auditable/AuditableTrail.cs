using System.Collections.ObjectModel;

namespace Flowsy.Auditable;

/// <summary>
/// Represents auditable information.
/// </summary>
public abstract class AuditableTrail
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableTrail"/> class.
    /// </summary>
    /// <param name="details">
    /// Details of the audit trail.
    /// </param>
    protected AuditableTrail(IReadOnlyDictionary<string, object?>? details = null)
    {
        Details = details ?? new ReadOnlyDictionary<string, object?>(new Dictionary<string, object?>());
    }

    /// <summary>
    /// Details of the audit trail.
    /// </summary>
    public IReadOnlyDictionary<string, object?> Details { get; protected set; }
}