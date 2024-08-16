namespace Flowsy.Auditable;

/// <summary>
/// Represents the context of an auditable operation.
/// </summary>
public sealed class AuditableOperationContext
{
    /// <summary>
    /// Initializes a new instance of an empty operation context.
    /// </summary>
    public AuditableOperationContext() : this(
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        new Dictionary<string, object?>()
        )
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableOperationContext"/> class.
    /// </summary>
    /// <param name="userId">
    /// The unique identifier of the user who performed the operation.
    /// </param>
    /// <param name="userNickname">
    /// The nickname of the user who performed the operation.
    /// </param>
    /// <param name="userAccountId">
    /// The unique identifier of the user account who performed the operation.
    /// </param>
    /// <param name="userAccountEmail">
    /// The email of the user account who performed the operation.
    /// </param>
    /// <param name="details">
    /// Additional details about the operation.
    /// </param>
    public AuditableOperationContext(string userId, string userNickname, string userAccountId, string userAccountEmail, IDictionary<string, object?> details)
    {
        UserId = userId;
        UserNickname = userNickname;
        UserAccountId = userAccountId;
        UserAccountEmail = userAccountEmail;
        Details = details;
    }

    /// <summary>
    /// The unique identifier of the user who performed the operation.
    /// </summary>
    public string UserId { get; private set; }
    
    /// <summary>
    /// The nickname of the user who performed the operation.
    /// </summary>
    public string UserNickname { get; private set; }
    
    /// <summary>
    /// The unique identifier of the user account who performed the operation.
    /// </summary>
    public string UserAccountId { get; private set; }
    
    /// <summary>
    /// The email of the user account who performed the operation.
    /// </summary>
    public string UserAccountEmail { get; private set; }
    
    /// <summary>
    /// Additional details about the operation.
    /// </summary>
    public IDictionary<string, object?> Details { get; private set; }
}