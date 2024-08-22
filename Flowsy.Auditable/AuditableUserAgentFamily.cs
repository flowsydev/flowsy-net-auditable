namespace Flowsy.Auditable;

/// <summary>
/// Represents the family of a user agent.
/// </summary>
public enum AuditableUserAgentFamily
{
    /// <summary>
    /// Represents an unknown user agent family.
    /// </summary>
    Unknown,
    
    /// <summary>
    /// The user agent is Chrome.
    /// </summary>
    Chrome,
    
    /// <summary>
    /// The user agent is Firefox.
    /// </summary>
    Firefox,
    
    /// <summary>
    /// The user agent is Safari.
    /// </summary>
    Safari,
    
    /// <summary>
    /// The user agent is Edge.
    /// </summary>
    Edge,
    
    /// <summary>
    /// The user agent is Internet Explorer.
    /// </summary>
    InternetExplorer,
    
    /// <summary>
    /// The user agent is Opera.
    /// </summary>
    Opera,
    
    /// <summary>
    /// The user agent is Mobile Safari.
    /// </summary>
    MobileSafari,
    
    /// <summary>
    /// The user agent is Android Browser.
    /// </summary>
    AndroidBrowser
}