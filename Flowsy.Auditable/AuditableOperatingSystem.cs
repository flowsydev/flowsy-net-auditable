using System.Text;

namespace Flowsy.Auditable;

/// <summary>
/// Represents auditable information about an operating system.
/// </summary>
public class AuditableOperatingSystem : AuditableTrail
{
    /// <summary>
    /// Initializes an empty instance of the <see cref="AuditableOperatingSystem"/> class.
    /// </summary>
    public AuditableOperatingSystem()
        : this(AuditableOperatingSystemFamily.Unknown, string.Empty, new AuditableVersion())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableOperatingSystem"/> class.
    /// </summary>
    /// <param name="family">
    /// The family of the operating system.
    /// </param>
    /// <param name="distribution">
    /// The distribution of the operating system.
    /// </param>
    /// <param name="version">
    /// The version of the operating system.
    /// </param>
    public AuditableOperatingSystem(AuditableOperatingSystemFamily family, string distribution, AuditableVersion? version)
    {
        Family = family;
        Distribution = distribution;
        Version = version;
    }

    /// <summary>
    /// The family of the operating system.
    /// </summary>
    public AuditableOperatingSystemFamily Family { get; private set; }
    
    /// <summary>
    /// The distribution of the operating system.
    /// </summary>
    public string Distribution { get; private set; }
    
    /// <summary>
    /// The version of the operating system.
    /// </summary>
    public AuditableVersion? Version { get; private set; }

    /// <summary>
    /// Returns a string that represents the operating system object.
    /// </summary>
    /// <returns>
    /// A string that represents the operating system object.
    /// </returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        
        stringBuilder.Append(Family);
        
        if (!string.IsNullOrWhiteSpace(Distribution))
            stringBuilder.Append($", {Distribution}");
        
        if (Version is not null)
            stringBuilder.Append($" v{Version}");

        return stringBuilder.ToString();
    }
}