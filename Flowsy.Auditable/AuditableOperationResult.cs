using System.Collections.ObjectModel;

namespace Flowsy.Auditable;

/// <summary>
/// Represents the result of an auditable operation.
/// </summary>
public sealed class AuditableOperationResult
{
    /// <summary>
    /// Initializes an empty instance of the <see cref="AuditableOperationResult"/> class.
    /// </summary>
    public AuditableOperationResult() : this(string.Empty, new AuditableOperation())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableOperationResult"/> class.
    /// </summary>
    /// <param name="targetReference">
    /// The reference to the target of the operation.
    /// </param>
    /// <param name="operation">
    /// The operation that was executed.
    /// </param>
    /// <param name="details">
    /// Additional details about the operation.
    /// </param>
    public AuditableOperationResult(string targetReference, AuditableOperation operation, IDictionary<string, object?>? details = null)
        : this(targetReference, operation.Type, operation.Instant, details)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableOperationResult"/> class.
    /// </summary>
    /// <param name="targetReference">
    /// The reference to the target of the operation.
    /// </param>
    /// <param name="operationType">
    /// The type of the operation.
    /// </param>
    /// <param name="operationInstant">
    /// The instant when the operation was executed.
    /// </param>
    /// <param name="details">
    /// Additional details about the operation.
    /// </param>
    public AuditableOperationResult(string targetReference, AuditableOperationType operationType, DateTimeOffset operationInstant, IDictionary<string, object?>? details)
    {
        TargetReference = targetReference;
        OperationType = operationType;
        OperationInstant = operationInstant;
        Details = details ?? new ReadOnlyDictionary<string, object?>(new Dictionary<string, object?>());
    }

    /// <summary>
    /// The reference to the target of the operation.
    /// This tipically will be the unique identifier of an entity or resource affected by the operation.
    /// </summary>
    public string TargetReference { get; private set; }
    
    /// <summary>
    /// The type of the operation.
    /// </summary>
    public AuditableOperationType OperationType { get; private set; }
    
    /// <summary>
    /// The instant when the operation was executed.
    /// </summary>
    public DateTimeOffset OperationInstant { get; private set; }
    
    /// <summary>
    /// Additional details about the operation.
    /// </summary>
    public IDictionary<string, object?> Details { get; private set; }
}