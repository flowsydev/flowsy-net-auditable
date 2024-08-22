namespace Flowsy.Auditable;

/// <summary>
/// Represents an auditable lifetime.
/// </summary>
public sealed class AuditableLifetime
{
    /// <summary>
    /// Creates a new instance of AuditableLifetime with the current instant as the start and the maximum value for DateTimeOffset as the end.
    /// </summary>
    public AuditableLifetime() : this(
        DateTimeOffset.Now, 
        DateTimeOffset.MaxValue
        )
    {
    }

    /// <summary>
    /// Creates a new instance of AuditableLifetime.
    /// </summary>
    /// <param name="start">
    /// The start of the lifetime.
    /// </param>
    /// <param name="end">
    /// The end of the lifetime.
    /// </param>
    public AuditableLifetime(DateTimeOffset start, DateTimeOffset end)
    {
        Start = start;
        End = end;
    }

    /// <summary>
    /// Indicates whether the lifetime is still active.
    /// </summary>
    public bool Alive => IsAlive(DateTimeOffset.Now);

    /// <summary>
    /// The start of the lifetime. 
    /// </summary>
    public DateTimeOffset Start { get; private set; }
    
    /// <summary>
    /// The end of the lifetime.
    /// </summary>
    public DateTimeOffset End { get; private set; }
    
    /// <summary>
    /// The duration of the lifetime.
    /// </summary>
    public TimeSpan Duration => End - Start;
    
    /// <summary>
    /// Inidicates whether the lifetime is active at the given instant.
    /// </summary>
    /// <param name="targetInstant">
    /// The instant to check.
    /// </param>
    /// <returns></returns>
    public bool IsAlive(DateTimeOffset targetInstant)
        => targetInstant >= Start && targetInstant <= End;

    /// <summary>
    /// Returns a string that represents the lifetime object.
    /// </summary>
    /// <returns>
    /// A string that represents the lifetime object.
    /// </returns>
    public override string ToString() => $"{Start:O} => {End:O} ({Duration})";
}