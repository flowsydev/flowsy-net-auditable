namespace Flowsy.Auditable;

/// <summary>
/// Provides the context for an auditable operation.
/// Implementations of this interface should resolve the operation context according to the current environment.
/// For example, a web application could resolve the operation context from the current HTTP request. 
/// </summary>
public interface IAuditableOperationContextProvider
{
    /// <summary>
    /// Gets the operation context for the current operation.
    /// </summary>
    /// <returns></returns>
    AuditableOperationContext GetOperationContext();
}