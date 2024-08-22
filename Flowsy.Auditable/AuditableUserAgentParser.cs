namespace Flowsy.Auditable;

/// <summary>
/// Provides a mechanism for parsing user agent strings into an <see cref="AuditableUserAgent"/> object.
/// </summary>
public static class AuditableUserAgentParser
{
    
    /// <summary>
    /// Parses a user agent string into an <see cref="AuditableUserAgent"/> object.
    /// </summary>
    /// <param name="userAgent">
    /// The user agent string to parse.
    /// </param>
    /// <param name="hostName">
    /// The host name of the client device.
    /// </param>
    /// <param name="ipAddress">
    /// The IP address of the client device.
    /// </param>
    /// <returns>
    /// An <see cref="AuditableUserAgent"/> object representing the parsed user agent string.
    /// </returns>
    public static AuditableUserAgent Parse(string userAgent, string? hostName = null, string? ipAddress = null)
    {
        var uaParser = UAParser.Parser.GetDefault();
        var clientInfo = uaParser.Parse(userAgent);
        
        var os = clientInfo.OS;
        var operatingSystem = new AuditableOperatingSystem(
            ParseOperatingSystemFamily(userAgent),
            os.Family,
            new AuditableVersion(
                os.Major,
                os.Minor,
                os.Patch,
                os.PatchMinor
            )
        );

        var dev = clientInfo.Device;
        var device = new AuditableDevice(
            ParseDeviceFamily(userAgent),
            dev.Brand,
            dev.Model,
            dev.IsSpider,
            hostName,
            ipAddress,
            operatingSystem
        );
        
        var ua = clientInfo.UA;
        return new AuditableUserAgent(
            ParseUserAgentFamily(userAgent),
            new AuditableVersion(
                ua.Major,
                ua.Minor,
                ua.Patch
            ),
            device
        );
    }
    
    private static AuditableUserAgentFamily ParseUserAgentFamily(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return AuditableUserAgentFamily.Unknown;

        // Normalize the user agent string to lowercase for easier matching
        var normalizedInput = input.ToLower();

        // Match common browsers and user agents
        if (normalizedInput.Contains("chrome"))
            return AuditableUserAgentFamily.Chrome;

        if (normalizedInput.Contains("firefox"))
            return AuditableUserAgentFamily.Firefox;

        if (normalizedInput.Contains("safari") && !normalizedInput.Contains("chrome"))
            return AuditableUserAgentFamily.Safari;

        if (normalizedInput.Contains("edge"))
            return AuditableUserAgentFamily.Edge;

        if (normalizedInput.Contains("msie") || normalizedInput.Contains("trident"))
            return AuditableUserAgentFamily.InternetExplorer;

        if (normalizedInput.Contains("opera") || normalizedInput.Contains("opr"))
            return AuditableUserAgentFamily.Opera;

        if (normalizedInput.Contains("safari") && normalizedInput.Contains("mobile"))
            return AuditableUserAgentFamily.MobileSafari;

        if (normalizedInput.Contains("android"))
            return AuditableUserAgentFamily.AndroidBrowser;

        return AuditableUserAgentFamily.Unknown;
    }

    private static AuditableOperatingSystemFamily ParseOperatingSystemFamily(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return AuditableOperatingSystemFamily.Unknown;

        // Normalize the user agent string to lowercase for easier matching
        var normalizedInput = input.ToLower();

        // Match common operating systems
        if (normalizedInput.Contains("windows nt") || normalizedInput.Contains("windows"))
            return AuditableOperatingSystemFamily.Windows;

        if (normalizedInput.Contains("mac os") || normalizedInput.Contains("macintosh"))
            return AuditableOperatingSystemFamily.Apple;

        if (normalizedInput.Contains("linux"))
            return AuditableOperatingSystemFamily.Linux;

        if (normalizedInput.Contains("android"))
            return AuditableOperatingSystemFamily.Linux;

        if (normalizedInput.Contains("iphone") || normalizedInput.Contains("ipad") || normalizedInput.Contains("ios"))
            return AuditableOperatingSystemFamily.Apple;

        return AuditableOperatingSystemFamily.Unknown;
    }
    
    private static AuditableDeviceFamily ParseDeviceFamily(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return AuditableDeviceFamily.Unknown;

        // Normalize the user agent string to lowercase for easier matching
        var normalizedInput = input.ToLower();

        // Match common device families
        if (normalizedInput.Contains("mobile") || normalizedInput.Contains("iphone") || normalizedInput.Contains("android"))
            return AuditableDeviceFamily.Mobile;

        if (normalizedInput.Contains("tablet") || normalizedInput.Contains("ipad"))
            return AuditableDeviceFamily.Tablet;

        if (normalizedInput.Contains("windows nt") || normalizedInput.Contains("macintosh") || normalizedInput.Contains("linux"))
            return AuditableDeviceFamily.Desktop;

        if (normalizedInput.Contains("smarttv") || normalizedInput.Contains("tizen") || normalizedInput.Contains("webos"))
            return AuditableDeviceFamily.SmartTv;

        if (normalizedInput.Contains("playstation") || normalizedInput.Contains("xbox") || normalizedInput.Contains("nintendo"))
            return AuditableDeviceFamily.Console;

        if (normalizedInput.Contains("wearable") || normalizedInput.Contains("watch") || normalizedInput.Contains("fitbit"))
            return AuditableDeviceFamily.Wearable;

        return AuditableDeviceFamily.Unknown;
    }
}