namespace Flowsy.Auditable;

/// <summary>
/// Represents a user agent that can be audited.
/// </summary>
public sealed class AuditableUserAgent
{
    /// <summary>
    /// Initializes an empty of the <see cref="AuditableUserAgent"/> class.
    /// </summary>
    public AuditableUserAgent() : this(AuditableUserAgentFamily.Unknown, new AuditableVersion(), new AuditableDevice())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableUserAgent"/> class.
    /// </summary>
    /// <param name="family">
    /// The family of the user agent.
    /// </param>
    /// <param name="version">
    /// The version of the user agent.
    /// </param>
    /// <param name="device">
    /// The device of the user agent.
    /// </param>
    public AuditableUserAgent(AuditableUserAgentFamily family, AuditableVersion version, AuditableDevice device)
    {
        Family = family;
        Version = version;
        Device = device;
    }

    /// <summary>
    /// The family of the user agent.
    /// </summary>
    public AuditableUserAgentFamily Family { get; private set; }
    
    /// <summary>
    /// The version of the user agent.
    /// </summary>
    public AuditableVersion Version { get; private set; }
    
    /// <summary>
    /// The device of the user agent.
    /// </summary>
    public AuditableDevice Device { get; private set; }

    /// <summary>
    /// Returns a string representation of the user agent.
    /// </summary>
    /// <returns>
    /// A string representation of the user agent.
    /// </returns>
    public override string ToString() => $"{Family} v{Version}";
}