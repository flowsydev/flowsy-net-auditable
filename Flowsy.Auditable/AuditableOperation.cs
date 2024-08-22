using System.Text;

namespace Flowsy.Auditable;

/// <summary>
/// Represents an operation that can be audited.
/// </summary>
public sealed class AuditableOperation
{
    /// <summary>
    /// Initializes a new instance of a void operation taking place at the current instant with an empty context.
    /// </summary>
    public AuditableOperation() : this(
        AuditableOperationType.Void,
        DateTimeOffset.Now,
        new AuditableOperationContext()
    )
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableOperation"/> class.
    /// </summary>
    /// <param name="type">
    /// The type of operation.
    /// </param>
    /// <param name="instant">
    /// The instant when the operation was executed.
    /// </param>
    /// <param name="context">
    /// The context in which the operation was executed.
    /// </param>
    public AuditableOperation(AuditableOperationType type, DateTimeOffset instant, AuditableOperationContext context)
    {
        Type = type;
        Instant = instant;
        Context = context;
    }

    /// <summary>
    /// The type of operation.
    /// </summary>
    public AuditableOperationType Type { get; private set; }
    
    /// <summary>
    ///  The instant when the operation was executed.
    /// </summary>
    public DateTimeOffset Instant { get; private set; }
    
    /// <summary>
    /// The context in which the operation was executed.
    /// </summary>
    public AuditableOperationContext Context { get; private set; }
    
    /// <summary>
    /// Gets the time elapsed since the operation was executed.
    /// </summary>
    /// <returns>
    /// The time elapsed since the operation was executed.
    /// </returns>
    public TimeSpan GetElapsedTime() => GetElapsedTime(DateTimeOffset.Now);

    /// <summary>
    /// Gets the time elapsed since the operation was executed using a target instant as reference for the calculation.
    /// </summary>
    /// <param name="targetInstant">
    /// The instant to calculate the elapsed time from.
    /// </param>
    /// <returns>
    /// The time elapsed since the operation was executed.
    /// </returns>
    public TimeSpan GetElapsedTime(DateTimeOffset targetInstant) => targetInstant - Instant;

    /// <summary>
    /// Gets the time remaining until the operation is executed.
    /// </summary>
    /// <returns>
    /// The time remaining until the operation is executed.
    /// </returns>
    public TimeSpan GetRemainingTime() => GetRemainingTime(DateTimeOffset.Now);

    /// <summary>
    /// Gets the time remaining until the operation is executed.
    /// </summary>
    /// <param name="targetInstant">
    /// The instant to calculate the remaining time until the operation is executed.
    /// </param>
    /// <returns>
    /// The time remaining until the operation is executed.
    /// </returns>
    public TimeSpan GetRemainingTime(DateTimeOffset targetInstant) => Instant - targetInstant;
    
    public static AuditableOperation Create()
        => new (AuditableOperationType.Void, DateTimeOffset.Now, new AuditableOperationContext());

    /// <summary>
    /// Returns a string that represents the operation object.
    /// </summary>
    /// <returns>
    /// A string that represents the operation object.
    /// </returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        var operationName = Type.ToString();
        var operationNameLength = operationName.Length;
        var operationNameSeparator = new string('-', operationNameLength);

        stringBuilder.AppendLine(operationNameSeparator);
        stringBuilder.AppendLine($"{operationName}: {Instant:O}");
        stringBuilder.Append(Context);
        
        return stringBuilder.ToString();
    }
}