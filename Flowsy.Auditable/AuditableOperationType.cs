namespace Flowsy.Auditable;

/// <summary>
/// Represents the type of operation that was performed on an auditable entity.
/// </summary>
public enum AuditableOperationType
{
    /// <summary>
    /// The entity was not involved in any operation.
    /// </summary>
    Void,
    
    /// <summary>
    /// The entity was automatically initialized by the system.
    /// </summary>
    Initialization,
    
    /// <summary>
    /// The entity was created by th user.
    /// </summary>
    Creation,
    
    /// <summary>
    /// The entity was modified by the user.
    /// </summary>
    Mutation,
    
    /// <summary>
    /// The entity was synchronized from another entity or some kind of external source.
    /// </summary>
    Synchronization,
    
    /// <summary>
    /// The entity was soft-deleted by the user.
    /// Soft-deleted entities are not actually removed from the system, but marked as deleted.
    /// </summary>
    SoftDeletion,
    
    /// <summary>
    /// The entity was hard-deleted by the user.
    /// Hard-deleted entities are actually removed from the system and cannot be restored.
    /// </summary>
    HardDeletion,
    
    /// <summary>
    /// The previously soft-deleted entity was restored, so it is no longer marked as deleted, has a new lifetime and is fully functional again.
    /// </summary>
    Restoration
}