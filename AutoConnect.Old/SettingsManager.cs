using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace Ibf.Vpn.AutoConnect
{
    internal class SettingsManager
    {
        private string vpnConnectionName = "No settings found";
        private string userName = "";
        private string password = "";

        private bool startApplicationWithSystem = true;
        private bool showMessages = true;
        private bool applicationEnabled = true;
        private bool startApplicationMinimized;
        private const string encryptionKey = "199A387C9827437093EC35A4762AAAF1F2E8F86C171B4253BA1FEF31756F868B";


        public SettingsManager()
        {
            if (ValidSettingsFound())
            {
                ReadSettings();
            }
        }

        private bool SettingsRegistryFound()
        {
            var key = Registry.CurrentUser.OpenSubKey("AutoVPNConnect");
            return key != null;
        }

        public bool ValidSettingsFound()
        {
            var connectionName = "No settings found";
            var userName = "";
            var password = "";

            if (SettingsRegistryFound() == false)
            {
                return false;
            }

            var key = Registry.CurrentUser.OpenSubKey("AutoVPNConnect");

            if (key == null)
            {
                return false;
            }

            try
            {
                connectionName = key.GetValue("VPNConnectionName").ToString();
                userName = key.GetValue("Username").ToString();
                password = key.GetValue("Password").ToString();
                key.Close();
            }
            catch
            {
                key.Close();
                return false;
            }

            return connectionName != "No settings found"
                   && userName != ""
                   && password != "";
        }

        private void ReadSettings()
        {
            var key = Registry.CurrentUser.OpenSubKey("AutoVPNConnect");

            if (key == null)
            {
                return;
            }

            try
            {
                if (key is null)
                {
                    return;
                }

                var registryVpnConnectionName = key.GetValue("VPNConnectionName").ToString();
                var registryUserName = key.GetValue("Username").ToString();
                var registryEncryptedPassword = key.GetValue("Password").ToString();
                var registryApplicationStartWithSystem = key.GetValue("StartApplicationWithSystem").ToString();
                var registryShowMessages = key.GetValue("ShowMessages").ToString();
                var registryApplicationEnabled = key.GetValue("ApplicationEnabled").ToString();
                var registryStartApplicationMinimized = key.GetValue("StartApplicationMinimized").ToString();

                vpnConnectionName = registryVpnConnectionName;
                userName = registryUserName;
                password = DecryptPassword(registryEncryptedPassword);
                startApplicationWithSystem = registryApplicationStartWithSystem == "True";
                showMessages = registryShowMessages == "True";
                applicationEnabled = registryApplicationEnabled == "True";
                startApplicationMinimized = registryStartApplicationMinimized == "True";

                key.Close();
            }
            catch
            {
                key.Close();
            }
        }

        private void WriteSettings()
        {
            DeleteRegistryKey();
            CreateRegistryKey();

            var key = Registry.CurrentUser.OpenSubKey("AutoVPNConnect", true);
            if (key == null)
            {
                MessageBox.Show("Error while writing settings", "Error");
                return;
            }

            try
            {
                var encryptedPassword = EncryptPassword(password);

                key.SetValue("VPNConnectionName", vpnConnectionName, RegistryValueKind.String);
                key.SetValue("Username", userName, RegistryValueKind.String);
                key.SetValue("Password", encryptedPassword, RegistryValueKind.String);
                key.SetValue("StartApplicationWithSystem", startApplicationWithSystem, RegistryValueKind.String);
                key.SetValue("ShowMessages", showMessages, RegistryValueKind.String);
                key.SetValue("ApplicationEnabled", applicationEnabled, RegistryValueKind.String);
                key.SetValue("StartApplicationMinimized", startApplicationMinimized, RegistryValueKind.String);
            }
            catch
            {
                MessageBox.Show("Error while writing settings");
            }

            key.Close();
        }

        private void CreateRegistryKey()
        {
            Registry.CurrentUser.CreateSubKey("AutoVPNConnect");
        }

        private void DeleteRegistryKey()
        {
            if (SettingsRegistryFound())
            {
                Registry.CurrentUser.DeleteSubKey("AutoVPNConnect");
            }
        }

        private string EncryptPassword(string password)
        {
            if (password == "")
            {
                return "";
            }

            var inputArray = Encoding.UTF8.GetBytes(password);
            var tripleDes = TripleDES.Create();

            tripleDes.Key = Encoding.UTF8.GetBytes(encryptionKey);
            tripleDes.Mode = CipherMode.ECB;
            tripleDes.Padding = PaddingMode.PKCS7;

            var cTransform = tripleDes.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        private string DecryptPassword(string encryptedPassword)
        {
            if (encryptedPassword == "")
            {
                return "";
            }

            var inputArray = Convert.FromBase64String(encryptedPassword);
            var tripleDes = TripleDES.Create();

            tripleDes.Key = Encoding.UTF8.GetBytes(encryptionKey);
            tripleDes.Mode = CipherMode.ECB;
            tripleDes.Padding = PaddingMode.PKCS7;

            var cTransform = tripleDes.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDes.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }

        public void SetConnectionName(string connectionName)
        {
            vpnConnectionName = connectionName;
            WriteSettings();
        }

        public string GetConnectionName()
        {
            return vpnConnectionName;
        }

        public void SetUserName(string newUserName)
        {
            this.userName = newUserName;
            WriteSettings();
        }

        public string GetUserName()
        {
            return userName;
        }

        public void SetPassword(string newPassword)
        {
            this.password = newPassword;
            WriteSettings();
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetApplicationStartWithSystem(bool enabled)
        {
            var registryKey =
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            try
            {
                if (enabled)
                {
                    registryKey?.SetValue("AutoVPNConnect", Application.ExecutablePath);
                }
                else
                {
                    registryKey?.DeleteValue("AutoVPNConnect");
                }
            }
            catch
            {
                MessageBox.Show("Error while writing settings", "Error");
            }


            startApplicationWithSystem = enabled;
            WriteSettings();
        }

        public bool GetApplicationStartWithSystem()
        {
            return startApplicationWithSystem;
        }

        public void SetShowMessages(bool enabled)
        {
            showMessages = enabled;
            WriteSettings();
        }

        public bool GetShowMessagesSetting()
        {
            return showMessages;
        }

        public void SetApplicationEnabledSetting(bool enabled)
        {
            applicationEnabled = enabled;
            WriteSettings();
        }

        public bool GetApplicationEnabledSetting()
        {
            return applicationEnabled;
        }

        public void SetStartApplicationMinimized(bool enabled)
        {
            startApplicationMinimized = enabled;
            WriteSettings();
        }

        public bool GetStartApplicationMinimized()
        {
            return startApplicationMinimized;
        }
    }
}