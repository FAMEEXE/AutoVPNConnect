using System.Diagnostics;
using System.Reflection;
using Timer = System.Windows.Forms.Timer;

namespace Ibf.Vpn.AutoConnect;

public partial class MainWindow : Form
{
    private readonly SettingsManager settingsManager;
    private readonly ConnectionManager connectionManager;
    private readonly Timer updateUITimer;

    public MainWindow()
    {
        settingsManager = new SettingsManager();
        connectionManager = new ConnectionManager(ref settingsManager);
        updateUITimer = new Timer();

        InitializeComponent();

        //Check if there is already a running instance
        var location = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()!.Location);
        if (Process.GetProcessesByName(location).Length > 1)
        {
            MessageBox.Show("AutoVPNConnect is already running.\nIt is recommended to close this instance.", "Warning");
        }

        //Init timer
        updateUITimer.Interval = 3000;
        updateUITimer.Enabled = true;
        updateUITimer.Tick += UpdateUITimerElapsed;

        InitUI();
    }

    private void InitUI()
    {
        //Go to Settings tab when no settings found
        if (settingsManager.ValidSettingsFound() == false)
        {
            tabControl.SelectedTab = tabPage2;
        }
        else
        {
            lblConnectionName.Text = settingsManager.GetConnectionName();
            lblAppEnabled.Text = "Application enabled: " + settingsManager.GetApplicationEnabledSetting().ToString();
        }

        lblConnectionStatus.Text =
            connectionManager.VpnIsConnected()
                ? "Connection status: Connected"
                : "Connection status: Disconnected";

        checkBoxStartWithSystem.Checked = settingsManager.GetApplicationStartWithSystem();
        checkBoxShowMessages.Checked = settingsManager.GetShowMessagesSetting();
        checkBoxApplicationEnabled.Checked = settingsManager.GetApplicationEnabledSetting();
        checkBoxStartApplicationMinimized.Checked = settingsManager.GetStartApplicationMinimized();
    }

    private void comboBoxActiveVPNConnections_DropDown(object sender, EventArgs e)
    {
        comboBoxActiveVPNConnections.Items.Clear();
        var vpnConnections = connectionManager.GetActiveVpnConnections();

        if (vpnConnections.Count == 0)
        {
            MessageBox.Show("Connect to a VPN first");
            try
            {
                var startInfo = new ProcessStartInfo("NCPA.cpl")
                {
                    UseShellExecute = true
                };
                Process.Start(startInfo);
            }
            catch
            {
                // skipped
            }
        }

        foreach (var vpnInterface in vpnConnections)
        {
            comboBoxActiveVPNConnections.Items.Add(vpnInterface.Name);
        }
    }

    private void btnSaveSettings_Click(object sender, EventArgs e)
    {
        var vpnConnectionName = comboBoxActiveVPNConnections.Text;
        var username = textBoxUsername.Text;
        var password = textBoxPassword.Text;

        if (vpnConnectionName == "" || username == "" || password == "")
        {
            MessageBox.Show("Invalid input");
        }
        else
        {
            settingsManager.SetConnectionName(vpnConnectionName);
            settingsManager.SetUserName(username);
            settingsManager.SetPassword(password);

            MessageBox.Show("Settings successfully saved.\n" +
                            "AutoVPNConnect will automatically connect to VPN connection: " +
                            vpnConnectionName + "\nWhen this is not working, enter your username and password again.");
        }
    }

    private void checkBoxStartWithSystem_CheckedChanged(object sender, EventArgs e)
    {
        settingsManager.SetApplicationStartWithSystem(checkBoxStartWithSystem.Checked);
    }

    private void checkBoxShowMessages_CheckedChanged(object sender, EventArgs e)
    {
        settingsManager.SetShowMessages(checkBoxShowMessages.Checked);
    }

    private void checkBoxApplicationEnabled_CheckedChanged(object sender, EventArgs e)
    {
        settingsManager.SetApplicationEnabledSetting(checkBoxApplicationEnabled.Checked);
    }

    private void checkBoxStartApplicationMinimized_CheckedChanged(object sender, EventArgs e)
    {
        settingsManager.SetStartApplicationMinimized(checkBoxStartApplicationMinimized.Checked);
    }

    private void UpdateUITimerElapsed(object? sender, EventArgs e)
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        lblConnectionName.Text = settingsManager.GetConnectionName();
        lblAppEnabled.Text = "Application enabled: " + settingsManager.GetApplicationEnabledSetting().ToString();

        lblConnectionStatus.Text =
            connectionManager.VpnIsConnected()
                ? "Connection status: Connected"
                : "Connection status: Disconnected";
    }

    private void FormResize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            mNotifyIcon.Visible = true;
            ShowInTaskbar = false;
            updateUITimer.Enabled = false;

            if (settingsManager.GetShowMessagesSetting())
            {
                mNotifyIcon.BalloonTipTitle = "AutoVPNConnect";
                mNotifyIcon.BalloonTipText = "AutoVPNConnect runs in background";
                mNotifyIcon.ShowBalloonTip(1000);
            }
        }
        else
        {
            ShowInTaskbar = true;
            mNotifyIcon.Visible = false;
            updateUITimer.Enabled = true;
            UpdateUI();
        }
    }

    private void Loaded(object sender, EventArgs e)
    {
        if (settingsManager.GetStartApplicationMinimized())
        {
            WindowState = FormWindowState.Minimized;
        }
    }

    private void NotifyIconDoubleClick(object sender, MouseEventArgs e)
    {
        WindowState = FormWindowState.Normal;
        ShowInTaskbar = true;
        mNotifyIcon.Visible = false;
    }

    private void CloseClicked(object sender, EventArgs e)
    {
        Close();
    }

    private void MainFormClosing(object sender, FormClosingEventArgs e)
    {
        mNotifyIcon.Visible = false;
    }
}