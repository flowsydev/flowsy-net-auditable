using System.Text;

namespace Flowsy.Auditable;

/// <summary>
/// Represents a version of a software component.
/// </summary>
public sealed class AuditableVersion
{
    /// <summary>
    /// Initializes an empty of the <see cref="AuditableVersion"/> class.
    /// </summary>
    public AuditableVersion() : this("0")
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableVersion"/> class.
    /// </summary>
    /// <param name="major">
    /// The major version number.
    /// </param>
    /// <param name="minor">
    /// The minor version number.
    /// </param>
    /// <param name="patch">
    /// The patch version number.
    /// </param>
    /// <param name="patchMinor">
    /// The patch minor version number.
    /// </param>
    /// <param name="label">
    /// The label of the version.
    /// </param>
    public AuditableVersion(string major, string? minor = null, string? patch = null, string? patchMinor = null, string? label = null)
    {
        Major = major;
        Minor = minor;
        Patch = patch;
        PatchMinor = patchMinor;
        Label = label;
    }

    /// <summary>
    /// The major version number.
    /// </summary>
    public string Major { get; private set; }
    
    /// <summary>
    /// The minor version number.
    /// </summary>
    public string? Minor { get; private set; }
    
    /// <summary>
    /// The patch version number.
    /// </summary>
    public string? Patch { get; private set; }
    
    /// <summary>
    /// The patch minor version number.
    /// </summary>
    public string? PatchMinor { get; private set; }
    
    /// <summary>
    /// The label of the version.
    /// </summary>
    public string? Label { get; private set; }
    
    /// <summary>
    /// Gets a string representation of the version object.
    /// </summary>
    /// <returns>
    /// A string representation of the version object.
    /// </returns>
    public override string ToString()
    {
        // Build a string using a StringBuilder
        // Format: Major.Minor.Patch.PatchMinor Label
        
        var stringBuilder = new StringBuilder();
        
        stringBuilder.Append(Major);
        stringBuilder.Append($".{Minor ?? "0"}");
        stringBuilder.Append($".{Patch ?? "0"}");
        stringBuilder.Append($".{PatchMinor ?? "0"}");
        
        // Remove strings '.0' from the end of the string
        while (stringBuilder.ToString().EndsWith(".0"))
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
        
        if (!string.IsNullOrEmpty(Label))
            stringBuilder.Append($" {Label}");

        return stringBuilder.ToString();
    }
}