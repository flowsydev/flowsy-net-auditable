namespace Flowsy.Auditable;

/// <summary>
/// Represents an object that can be audited.
/// </summary>
public interface IAuditable
{
    /// <summary>
    /// The operation that created the object.
    /// </summary>
    public AuditableOperation Creation { get; }
    
    /// <summary>
    /// The operation that last mutated the object.
    /// </summary>
    public AuditableOperation? LastMutation { get; }
    
    /// <summary>
    /// Start, end and duration of the object's lifetime.
    /// When implementing soft deletes, this should represent the time between creation and deletion.
    /// </summary>
    public AuditableLifetime Lifetime { get; }
}