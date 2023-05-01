using System.Diagnostics;
using System.Net.NetworkInformation;
using Timer = System.Windows.Forms.Timer;

namespace Ibf.Vpn.AutoConnect
{
    internal class ConnectionManager
    {
        private readonly SettingsManager settingsManager;
        private readonly Timer vpnConnectionCheckTimer;

        public ConnectionManager(ref SettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;

            //Init timer
            vpnConnectionCheckTimer = new Timer();
            vpnConnectionCheckTimer.Interval = 15000;
            vpnConnectionCheckTimer.Enabled = true;
            vpnConnectionCheckTimer.Tick += VpnConnectionCheckTimerElapsed;
        }

        public List<NetworkInterface> GetActiveVpnConnections()
        {
            var connections = new List<NetworkInterface>();

            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return connections;
            }

            var interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var vpnInterface in interfaces)
            {
                //Get VPN connections
                if ((vpnInterface.NetworkInterfaceType == NetworkInterfaceType.Ppp) &&
                    (vpnInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback))
                {
                    connections.Add(vpnInterface);
                }
            }

            return connections;
        }

        public bool VpnIsConnected()
        {
            var connectionName = settingsManager.GetConnectionName();
            var connections = GetActiveVpnConnections();

            foreach (var vpn in connections)
            {
                if (vpn.Name != connectionName)
                {
                    continue;
                }

                return vpn.OperationalStatus == OperationalStatus.Up;
            }

            return false;
        }

        private void ConnectToVpn()
        {
            var rasDialCommand = $" \"{settingsManager.GetConnectionName()}\" {settingsManager.GetUserName()} {settingsManager.GetPassword()}";
            var procStartInfo = new ProcessStartInfo("rasdial.exe", rasDialCommand)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                // Do not create the black window.
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            //Start the process
            Process.Start(procStartInfo);
        }

        private void CheckConnectionStatus()
        {
            if (!settingsManager.GetApplicationEnabledSetting()) return;
            if (VpnIsConnected() == false && settingsManager.ValidSettingsFound())
            {
                ConnectToVpn();
            }
        }

        private void VpnConnectionCheckTimerElapsed(object sender, EventArgs e)
        {
            CheckConnectionStatus();
        }
    }
}