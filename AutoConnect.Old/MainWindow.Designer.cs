namespace Ibf.Vpn.AutoConnect;

partial class MainWindow
{
    /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.groupBoxConnectionSettings = new System.Windows.Forms.GroupBox();
            this.lblConnectionName = new System.Windows.Forms.Label();
            this.lblConnectsTo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.lblAppEnabled = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxGeneralSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxStartApplicationMinimized = new System.Windows.Forms.CheckBox();
            this.lblStartMinimized = new System.Windows.Forms.Label();
            this.checkBoxApplicationEnabled = new System.Windows.Forms.CheckBox();
            this.lblApplicationEnabled = new System.Windows.Forms.Label();
            this.checkBoxShowMessages = new System.Windows.Forms.CheckBox();
            this.lblShowMessages = new System.Windows.Forms.Label();
            this.checkBoxStartWithSystem = new System.Windows.Forms.CheckBox();
            this.lblStartWithSystem = new System.Windows.Forms.Label();
            this.groupBoxVPNSettings = new System.Windows.Forms.GroupBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.comboBoxActiveVPNConnections = new System.Windows.Forms.ComboBox();
            this.lblSelectVPNConnection = new System.Windows.Forms.Label();
            this.mNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxConnectionSettings.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxGeneralSettings.SuspendLayout();
            this.groupBoxVPNSettings.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConnectionSettings
            // 
            this.groupBoxConnectionSettings.Controls.Add(this.lblConnectionName);
            this.groupBoxConnectionSettings.Controls.Add(this.lblConnectsTo);
            this.groupBoxConnectionSettings.Location = new System.Drawing.Point(6, 9);
            this.groupBoxConnectionSettings.Name = "groupBoxConnectionSettings";
            this.groupBoxConnectionSettings.Size = new System.Drawing.Size(282, 70);
            this.groupBoxConnectionSettings.TabIndex = 1;
            this.groupBoxConnectionSettings.TabStop = false;
            this.groupBoxConnectionSettings.Text = "Connection settings";
            // 
            // lblConnectionName
            // 
            this.lblConnectionName.AutoSize = true;
            this.lblConnectionName.Location = new System.Drawing.Point(7, 43);
            this.lblConnectionName.Name = "lblConnectionName";
            this.lblConnectionName.Size = new System.Drawing.Size(90, 13);
            this.lblConnectionName.TabIndex = 1;
            this.lblConnectionName.Text = "No settings found";
            // 
            // lblConnectsTo
            // 
            this.lblConnectsTo.AutoSize = true;
            this.lblConnectsTo.Location = new System.Drawing.Point(7, 20);
            this.lblConnectsTo.Name = "lblConnectsTo";
            this.lblConnectsTo.Size = new System.Drawing.Size(116, 13);
            this.lblConnectsTo.TabIndex = 0;
            this.lblConnectsTo.Text = "Connects automatic to:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(302, 275);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxStatus);
            this.tabPage1.Controls.Add(this.groupBoxConnectionSettings);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(294, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.lblAppEnabled);
            this.groupBoxStatus.Controls.Add(this.lblConnectionStatus);
            this.groupBoxStatus.Location = new System.Drawing.Point(6, 85);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(282, 72);
            this.groupBoxStatus.TabIndex = 2;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // lblAppEnabled
            // 
            this.lblAppEnabled.AutoSize = true;
            this.lblAppEnabled.Location = new System.Drawing.Point(7, 20);
            this.lblAppEnabled.Name = "lblAppEnabled";
            this.lblAppEnabled.Size = new System.Drawing.Size(128, 13);
            this.lblAppEnabled.TabIndex = 2;
            this.lblAppEnabled.Text = "Application enabled: True";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(7, 45);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(164, 13);
            this.lblConnectionStatus.TabIndex = 0;
            this.lblConnectionStatus.Text = "Connection status: Disconnected";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxGeneralSettings);
            this.tabPage2.Controls.Add(this.groupBoxVPNSettings);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(294, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxGeneralSettings
            // 
            this.groupBoxGeneralSettings.Controls.Add(this.checkBoxStartApplicationMinimized);
            this.groupBoxGeneralSettings.Controls.Add(this.lblStartMinimized);
            this.groupBoxGeneralSettings.Controls.Add(this.checkBoxApplicationEnabled);
            this.groupBoxGeneralSettings.Controls.Add(this.lblApplicationEnabled);
            this.groupBoxGeneralSettings.Controls.Add(this.checkBoxShowMessages);
            this.groupBoxGeneralSettings.Controls.Add(this.lblShowMessages);
            this.groupBoxGeneralSettings.Controls.Add(this.checkBoxStartWithSystem);
            this.groupBoxGeneralSettings.Controls.Add(this.lblStartWithSystem);
            this.groupBoxGeneralSettings.Location = new System.Drawing.Point(7, 143);
            this.groupBoxGeneralSettings.Name = "groupBoxGeneralSettings";
            this.groupBoxGeneralSettings.Size = new System.Drawing.Size(281, 100);
            this.groupBoxGeneralSettings.TabIndex = 1;
            this.groupBoxGeneralSettings.TabStop = false;
            this.groupBoxGeneralSettings.Text = "General settings";
            // 
            // checkBoxStartApplicationMinimized
            // 
            this.checkBoxStartApplicationMinimized.AutoSize = true;
            this.checkBoxStartApplicationMinimized.Location = new System.Drawing.Point(260, 81);
            this.checkBoxStartApplicationMinimized.Name = "checkBoxStartApplicationMinimized";
            this.checkBoxStartApplicationMinimized.Size = new System.Drawing.Size(15, 14);
            this.checkBoxStartApplicationMinimized.TabIndex = 9;
            this.checkBoxStartApplicationMinimized.UseVisualStyleBackColor = true;
            this.checkBoxStartApplicationMinimized.CheckedChanged += new System.EventHandler(this.checkBoxStartApplicationMinimized_CheckedChanged);
            // 
            // lblStartMinimized
            // 
            this.lblStartMinimized.AutoSize = true;
            this.lblStartMinimized.Location = new System.Drawing.Point(9, 81);
            this.lblStartMinimized.Name = "lblStartMinimized";
            this.lblStartMinimized.Size = new System.Drawing.Size(131, 13);
            this.lblStartMinimized.TabIndex = 8;
            this.lblStartMinimized.Text = "Start application minimized";
            // 
            // checkBoxApplicationEnabled
            // 
            this.checkBoxApplicationEnabled.AutoSize = true;
            this.checkBoxApplicationEnabled.Location = new System.Drawing.Point(260, 60);
            this.checkBoxApplicationEnabled.Name = "checkBoxApplicationEnabled";
            this.checkBoxApplicationEnabled.Size = new System.Drawing.Size(15, 14);
            this.checkBoxApplicationEnabled.TabIndex = 7;
            this.checkBoxApplicationEnabled.UseVisualStyleBackColor = true;
            this.checkBoxApplicationEnabled.CheckedChanged += new System.EventHandler(this.checkBoxApplicationEnabled_CheckedChanged);
            // 
            // lblApplicationEnabled
            // 
            this.lblApplicationEnabled.AutoSize = true;
            this.lblApplicationEnabled.Location = new System.Drawing.Point(9, 61);
            this.lblApplicationEnabled.Name = "lblApplicationEnabled";
            this.lblApplicationEnabled.Size = new System.Drawing.Size(100, 13);
            this.lblApplicationEnabled.TabIndex = 4;
            this.lblApplicationEnabled.Text = "Application enabled";
            // 
            // checkBoxShowMessages
            // 
            this.checkBoxShowMessages.AutoSize = true;
            this.checkBoxShowMessages.Location = new System.Drawing.Point(260, 40);
            this.checkBoxShowMessages.Name = "checkBoxShowMessages";
            this.checkBoxShowMessages.Size = new System.Drawing.Size(15, 14);
            this.checkBoxShowMessages.TabIndex = 6;
            this.checkBoxShowMessages.UseVisualStyleBackColor = true;
            this.checkBoxShowMessages.CheckedChanged += new System.EventHandler(this.checkBoxShowMessages_CheckedChanged);
            // 
            // lblShowMessages
            // 
            this.lblShowMessages.AutoSize = true;
            this.lblShowMessages.Location = new System.Drawing.Point(9, 41);
            this.lblShowMessages.Name = "lblShowMessages";
            this.lblShowMessages.Size = new System.Drawing.Size(84, 13);
            this.lblShowMessages.TabIndex = 2;
            this.lblShowMessages.Text = "Show messages";
            // 
            // checkBoxStartWithSystem
            // 
            this.checkBoxStartWithSystem.AutoSize = true;
            this.checkBoxStartWithSystem.Location = new System.Drawing.Point(260, 19);
            this.checkBoxStartWithSystem.Name = "checkBoxStartWithSystem";
            this.checkBoxStartWithSystem.Size = new System.Drawing.Size(15, 14);
            this.checkBoxStartWithSystem.TabIndex = 5;
            this.checkBoxStartWithSystem.UseVisualStyleBackColor = true;
            this.checkBoxStartWithSystem.CheckedChanged += new System.EventHandler(this.checkBoxStartWithSystem_CheckedChanged);
            // 
            // lblStartWithSystem
            // 
            this.lblStartWithSystem.AutoSize = true;
            this.lblStartWithSystem.Location = new System.Drawing.Point(9, 20);
            this.lblStartWithSystem.Name = "lblStartWithSystem";
            this.lblStartWithSystem.Size = new System.Drawing.Size(140, 13);
            this.lblStartWithSystem.TabIndex = 0;
            this.lblStartWithSystem.Text = "Start application with system";
            // 
            // groupBoxVPNSettings
            // 
            this.groupBoxVPNSettings.Controls.Add(this.btnSaveSettings);
            this.groupBoxVPNSettings.Controls.Add(this.lblPassword);
            this.groupBoxVPNSettings.Controls.Add(this.textBoxPassword);
            this.groupBoxVPNSettings.Controls.Add(this.lblUsername);
            this.groupBoxVPNSettings.Controls.Add(this.textBoxUsername);
            this.groupBoxVPNSettings.Controls.Add(this.comboBoxActiveVPNConnections);
            this.groupBoxVPNSettings.Controls.Add(this.lblSelectVPNConnection);
            this.groupBoxVPNSettings.Location = new System.Drawing.Point(6, 6);
            this.groupBoxVPNSettings.Name = "groupBoxVPNSettings";
            this.groupBoxVPNSettings.Size = new System.Drawing.Size(282, 131);
            this.groupBoxVPNSettings.TabIndex = 0;
            this.groupBoxVPNSettings.TabStop = false;
            this.groupBoxVPNSettings.Text = "VPN Settings";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(9, 103);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSettings.TabIndex = 4;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(145, 61);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(148, 77);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(128, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 61);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(10, 77);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(132, 20);
            this.textBoxUsername.TabIndex = 2;
            // 
            // comboBoxActiveVPNConnections
            // 
            this.comboBoxActiveVPNConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActiveVPNConnections.FormattingEnabled = true;
            this.comboBoxActiveVPNConnections.Location = new System.Drawing.Point(10, 37);
            this.comboBoxActiveVPNConnections.Name = "comboBoxActiveVPNConnections";
            this.comboBoxActiveVPNConnections.Size = new System.Drawing.Size(266, 21);
            this.comboBoxActiveVPNConnections.TabIndex = 1;
            this.comboBoxActiveVPNConnections.DropDown += new System.EventHandler(this.comboBoxActiveVPNConnections_DropDown);
            // 
            // lblSelectVPNConnection
            // 
            this.lblSelectVPNConnection.AutoSize = true;
            this.lblSelectVPNConnection.Location = new System.Drawing.Point(7, 20);
            this.lblSelectVPNConnection.Name = "lblSelectVPNConnection";
            this.lblSelectVPNConnection.Size = new System.Drawing.Size(85, 13);
            this.lblSelectVPNConnection.TabIndex = 0;
            this.lblSelectVPNConnection.Text = "VPN connection";
            // 
            // mNotifyIcon
            // 
            this.mNotifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.mNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mNotifyIcon.Icon")));
            this.mNotifyIcon.Visible = true;
            this.mNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(93, 26);
            this.contextMenuStrip.Click += new System.EventHandler(this.CloseClicked);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            // 
            // AutoVPNConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 299);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AutoVPNConnect";
            this.Text = "AutoVPNConnect";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.Loaded);
            this.Resize += new System.EventHandler(this.FormResize);
            this.groupBoxConnectionSettings.ResumeLayout(false);
            this.groupBoxConnectionSettings.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBoxGeneralSettings.ResumeLayout(false);
            this.groupBoxGeneralSettings.PerformLayout();
            this.groupBoxVPNSettings.ResumeLayout(false);
            this.groupBoxVPNSettings.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConnectionSettings;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblConnectionName;
        private System.Windows.Forms.Label lblConnectsTo;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.GroupBox groupBoxVPNSettings;
        private System.Windows.Forms.ComboBox comboBoxActiveVPNConnections;
        private System.Windows.Forms.Label lblSelectVPNConnection;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.GroupBox groupBoxGeneralSettings;
        private System.Windows.Forms.CheckBox checkBoxShowMessages;
        private System.Windows.Forms.Label lblShowMessages;
        private System.Windows.Forms.CheckBox checkBoxStartWithSystem;
        private System.Windows.Forms.Label lblStartWithSystem;
        private System.Windows.Forms.CheckBox checkBoxApplicationEnabled;
        private System.Windows.Forms.Label lblApplicationEnabled;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Label lblAppEnabled;
        private System.Windows.Forms.CheckBox checkBoxStartApplicationMinimized;
        private System.Windows.Forms.Label lblStartMinimized;
        private System.Windows.Forms.NotifyIcon mNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
}