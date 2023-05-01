using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ibf.Wpf.AutoConnector.Abstraction;

namespace Ibf.Wpf.AutoConnector.Service;

public interface IRegistrySettingService
{
    VpnSettings CurrentSettings { get; set; }
    Task Save();
    Task Load();
}

public class RegistrySettingService : IRegistrySettingService
{
    private readonly IRegistryService registryService;
    private const string key = "ac214a7f9fea42a79731e7acee3de259";

    public RegistrySettingService(IRegistryService registryService)
    {
        this.registryService = registryService;
    }

    public VpnSettings CurrentSettings { get; set; }

    public Task Save()
    {
        using var key = registryService.QueryRegistryKey("AutoVPNConnect");
        
        SetString("Username", CurrentSettings.UserName);
        SetEncryptedString("Password", CurrentSettings.Password);
        SetString("VPNConnectionName", CurrentSettings.ConnectionName);
        SetBool("ApplicationEnabled", CurrentSettings.Enabled);
        SetBool("ShowMessages", CurrentSettings.ShowMessages);
        SetBool("StartApplicationMinimized", CurrentSettings.StartMinimized);
        SetBool("StartApplicationWithSystem", CurrentSettings.StartWithSystem);
        
        return Task.CompletedTask;

        void SetString(string subKey, string value)
        {
            key.SetValue(subKey, value);
        }

        void SetEncryptedString(string subKey, string value)
        {
            // const string encryptionKey = "8a8829c5f8224fa188a56d==";
            //
            // var inputArray = Encoding.UTF8.GetBytes(value);
            // var tripleDes = TripleDES.Create();
            //
            // tripleDes.Key = Encoding.UTF8.GetBytes(encryptionKey);
            // tripleDes.Mode = CipherMode.ECB;
            // tripleDes.Padding = PaddingMode.PKCS7;
            //
            // var cTransform = tripleDes.CreateEncryptor();
            // var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            // tripleDes.Clear();
            // var encryptedValue = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            SetString(subKey, AesOperation.EncryptString(RegistrySettingService.key, value));
        }

        void SetBool(string subKey, bool value)
        {
            SetString(subKey, value ? "1" : "0");
        }
    }

    public Task Load()
    {
        var key = registryService.QueryRegistryKey("AutoVPNConnect");

        CurrentSettings = new VpnSettings()
        {
            UserName = FromString("Username"),
            Password = FromEncryptedString("Password"),
            ConnectionName = FromString("VPNConnectionName"),

            Enabled = FromBool("ApplicationEnabled"),
            ShowMessages = FromBool("ShowMessages"),
            StartMinimized = FromBool("StartApplicationMinimized"),
            StartWithSystem = FromBool("StartApplicationWithSystem"),
        };

        key.Dispose();
        return Task.CompletedTask;

        string FromEncryptedString(string subKey)
        {
            // const string encryptionKey = "8a8829c5f8224fa188a56d==";
            var password = FromString(subKey);
            //
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }
            //
            // var inputArray = Convert.FromBase64String(password);
            // var tripleDes = TripleDES.Create();
            //
            // tripleDes.Key = Convert.FromBase64String(encryptionKey);
            // tripleDes.Mode = CipherMode.ECB;
            // tripleDes.Padding = PaddingMode.PKCS7;
            //
            // var cTransform = tripleDes.CreateDecryptor();
            // var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            // tripleDes.Clear();
            // return Encoding.UTF8.GetString(resultArray);

            return AesOperation.DecryptString(RegistrySettingService.key, password);
        }


        string FromString(string subKey) => key.GetValue(subKey);

        bool FromBool(string subKey) => key.GetValue(subKey) is { } conditionValue && conditionValue == "1";
    }
}