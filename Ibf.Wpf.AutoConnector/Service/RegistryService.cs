using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;

namespace Ibf.Wpf.AutoConnector.Service;

public interface IRegistryService
{
    IRegistryKey QueryRegistryKey(string subKeyName);
}

public class RegistryService : IRegistryService
{
    public IRegistryKey QueryRegistryKey(string subKeyName)
    {
        var key = Registry.CurrentUser.OpenSubKey(subKeyName, true)
                  ?? Registry.CurrentUser.CreateSubKey(subKeyName, true);

        return new RegistryKey(key);
    }
}

public interface IRegistryKey : IDisposable
{
    void SetValue(string subKey, string stringValue);

    string GetValue(string subKey);
}

public class RegistryKey : IRegistryKey
{
    private readonly Microsoft.Win32.RegistryKey winKey;

    public RegistryKey(Microsoft.Win32.RegistryKey winKey)
    {
        this.winKey = winKey;
    }

    public void SetValue(string subKey, string stringValue)
    {
        winKey.SetValue(subKey, stringValue, RegistryValueKind.String);
    }

    public string GetValue(string subKey)
    {
        return winKey.GetValue(subKey)?.ToString() ?? string.Empty;
    }

    public void Dispose()
    {
        winKey.Dispose();
    }
}