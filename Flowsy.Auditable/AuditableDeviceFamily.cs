namespace Flowsy.Auditable;

/// <summary>
/// Represents the family of a device.
/// </summary>
public enum AuditableDeviceFamily
{
    /// <summary>
    /// The device family is unknown.
    /// </summary>
    Unknown,
    
    /// <summary>
    /// The device is a desktop computer.
    /// </summary>
    Desktop,
    
    /// <summary>
    /// The device is a server.
    /// </summary>
    Server,
    
    /// <summary>
    /// The device is a mobile device.
    /// </summary>
    Mobile,
    
    /// <summary>
    /// The device is a tablet.
    /// </summary>
    Tablet,
    
    /// <summary>
    /// The device is a smart TV.
    /// </summary>
    SmartTv,
    
    /// <summary>
    /// The device is a console.
    /// </summary>
    Console,
    
    /// <summary>
    /// The device is a wearable device.
    /// </summary>
    Wearable
}