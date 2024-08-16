namespace Flowsy.Auditable;

public sealed class AuditableOperationResult
{
    public AuditableOperationResult() : this(
        string.Empty,
        AuditableOperationType.Void,
        DateTimeOffset.Now,
        new AuditableOperationContext(),
        new Dictionary<string, object?>()
        )
    {
    }

    public AuditableOperationResult(string targetReference, AuditableOperationType operationType, DateTimeOffset timestamp, AuditableOperationContext context, IDictionary<string, object?> details)
    {
        TargetReference = targetReference;
        OperationType = operationType;
        Timestamp = timestamp;
        Context = context;
        Details = details;
    }

    public string TargetReference { get; private set; }
    public AuditableOperationType OperationType { get; private set; }
    public DateTimeOffset Timestamp { get; private set; }
    public AuditableOperationContext Context { get; private set; }
    public IDictionary<string, object?> Details { get; private set; }
}