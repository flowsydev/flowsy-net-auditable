using System.Text;
using UAParser;

namespace Flowsy.Auditable;

/// <summary>
/// Represents the context of an auditable operation.
/// </summary>
public sealed class AuditableOperationContext : AuditableTrail
{
    /// <summary>
    /// The user associated with the operation.
    /// </summary>
    public AuditablePrincipal User { get; internal set; } = new();
    
    /// <summary>
    /// The user account associated with the operation.
    /// </summary>
    public AuditablePrincipal UserAccount { get; internal set; } = new();
    
    /// <summary>
    /// The user agent associated with the operation.
    /// </summary>
    public AuditableUserAgent? UserAgent { get; internal set; }
    
    /// <summary>
    /// The application associated with the operation.
    /// </summary>
    public AuditableApplication Application { get; internal set; } = new();
    
    /// <summary>
    /// The device that originated the operation.
    /// </summary>
    public AuditableDevice OriginDevice { get; internal set; } = new();

    /// <summary>
    /// The local device where the operation was performed.
    /// </summary>
    public AuditableDevice LocalDevice { get; internal set; } = new();

    public AuditableOperation CreateOperation(AuditableOperationType type)
        => new (type, DateTimeOffset.Now, this);

    /// <summary>
    /// Returns a string that represents the operation context.
    /// </summary>
    /// <returns>
    /// A string that represents the operation context.
    /// </returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        
        sb.AppendLine($"User: {User}, {UserAccount}");
        sb.AppendLine($"Application: {Application}");
        
        if (UserAgent is not null)
            sb.AppendLine($"User Agent: {UserAgent}");
        
        sb.AppendLine($"Local Device: {LocalDevice}");
        sb.AppendLine($"Origin Device: {OriginDevice}");
        
        return sb.ToString();
    }

    /// <summary>
    /// Creates an object used to build an instance of <see cref="AuditableOperationContext"/>.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="AuditableOperationContextBuilder"/>.
    /// </returns>
    public static AuditableOperationContextBuilder Create() => new (new AuditableOperationContext());
}