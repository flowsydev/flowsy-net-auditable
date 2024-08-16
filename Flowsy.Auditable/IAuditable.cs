namespace Flowsy.Auditable;

/// <summary>
/// Represents an entity that can be audited.
/// </summary>
public interface IAuditable
{
    /// <summary>
    /// The operation that created the entity.
    /// </summary>
    public AuditableOperation Creation { get; }
    
    /// <summary>
    /// The operation that last mutated the entity.
    /// </summary>
    public AuditableOperation? LastMutation { get; }
    
    /// <summary>
    /// Start, end and duration of the entity's lifetime.
    /// When implementing soft deletes, this should represent the time between creation and deletion.
    /// </summary>
    public AuditableLifetime Lifetime { get; }
}