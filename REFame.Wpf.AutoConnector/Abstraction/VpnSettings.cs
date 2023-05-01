namespace Ibf.Wpf.AutoConnector.Abstraction;

public class VpnSettings
{
    public string ConnectionName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public bool StartWithSystem { get; set; }

    public bool ShowMessages { get; set; }

    public bool Enabled { get; set; }

    public bool StartMinimized { get; set; }
}