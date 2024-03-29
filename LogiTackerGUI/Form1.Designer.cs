﻿namespace LogiTackerGUI
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAutoDecrypt = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonDecryptHistory = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.deviceListCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonExportJson = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.channel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.payloadLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.payload = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.payloadDecrypted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClearList = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClearKeyLogs = new System.Windows.Forms.Button();
            this.textBoxKeys = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.HidHandler = new System.ComponentModel.BackgroundWorker();
            this.buttonImportJson = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAutoDecrypt);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.buttonDecryptHistory);
            this.groupBox1.Controls.Add(this.textBoxKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.deviceListCombobox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // buttonAutoDecrypt
            // 
            this.buttonAutoDecrypt.Location = new System.Drawing.Point(439, 50);
            this.buttonAutoDecrypt.Name = "buttonAutoDecrypt";
            this.buttonAutoDecrypt.Size = new System.Drawing.Size(104, 23);
            this.buttonAutoDecrypt.TabIndex = 6;
            this.buttonAutoDecrypt.Text = "Auto Decrypt: OFF";
            this.buttonAutoDecrypt.UseVisualStyleBackColor = true;
            this.buttonAutoDecrypt.Click += new System.EventHandler(this.ButtonAutoDecrypt_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(479, 23);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(64, 23);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // buttonDecryptHistory
            // 
            this.buttonDecryptHistory.Location = new System.Drawing.Point(343, 50);
            this.buttonDecryptHistory.Name = "buttonDecryptHistory";
            this.buttonDecryptHistory.Size = new System.Drawing.Size(90, 23);
            this.buttonDecryptHistory.TabIndex = 4;
            this.buttonDecryptHistory.Text = "Decrypt History";
            this.buttonDecryptHistory.UseVisualStyleBackColor = true;
            this.buttonDecryptHistory.Click += new System.EventHandler(this.ButtonDecryptHistory_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(94, 52);
            this.textBoxKey.MaxLength = 32;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(243, 20);
            this.textBoxKey.TabIndex = 3;
            this.textBoxKey.WordWrap = false;
            this.textBoxKey.TextChanged += new System.EventHandler(this.TextBoxKey_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Decryption key:";
            // 
            // deviceListCombobox
            // 
            this.deviceListCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceListCombobox.Location = new System.Drawing.Point(79, 25);
            this.deviceListCombobox.Name = "deviceListCombobox";
            this.deviceListCombobox.Size = new System.Drawing.Size(394, 21);
            this.deviceListCombobox.Sorted = true;
            this.deviceListCombobox.TabIndex = 1;
            this.deviceListCombobox.SelectedIndexChanged += new System.EventHandler(this.DeviceListCombobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "USB device:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 257);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 231);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Packets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.buttonExportJson, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.listView1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonClearList, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonImportJson, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(788, 225);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonExportJson
            // 
            this.buttonExportJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExportJson.Location = new System.Drawing.Point(397, 198);
            this.buttonExportJson.Name = "buttonExportJson";
            this.buttonExportJson.Size = new System.Drawing.Size(191, 24);
            this.buttonExportJson.TabIndex = 2;
            this.buttonExportJson.Text = "Export JSON";
            this.buttonExportJson.UseVisualStyleBackColor = true;
            this.buttonExportJson.Click += new System.EventHandler(this.ButtonExportJson_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.address,
            this.pid,
            this.channel,
            this.payloadLength,
            this.payload,
            this.payloadDecrypted});
            this.tableLayoutPanel2.SetColumnSpan(this.listView1, 3);
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(782, 189);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // address
            // 
            this.address.Text = "Address";
            this.address.Width = 140;
            // 
            // pid
            // 
            this.pid.Text = "PID";
            this.pid.Width = 30;
            // 
            // channel
            // 
            this.channel.Text = "Ch";
            this.channel.Width = 30;
            // 
            // payloadLength
            // 
            this.payloadLength.Text = "Length";
            this.payloadLength.Width = 48;
            // 
            // payload
            // 
            this.payload.Text = "Payload";
            this.payload.Width = 360;
            // 
            // payloadDecrypted
            // 
            this.payloadDecrypted.Text = "Decrypted Payload";
            this.payloadDecrypted.Width = 150;
            // 
            // buttonClearList
            // 
            this.buttonClearList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearList.Location = new System.Drawing.Point(3, 198);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(388, 24);
            this.buttonClearList.TabIndex = 1;
            this.buttonClearList.Text = "Clear list";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.ButtonClearList_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 231);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decrypted key presses";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.buttonClearKeyLogs, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxKeys, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(788, 225);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // buttonClearKeyLogs
            // 
            this.buttonClearKeyLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearKeyLogs.Location = new System.Drawing.Point(3, 198);
            this.buttonClearKeyLogs.Name = "buttonClearKeyLogs";
            this.buttonClearKeyLogs.Size = new System.Drawing.Size(782, 24);
            this.buttonClearKeyLogs.TabIndex = 2;
            this.buttonClearKeyLogs.Text = "Clear key logs";
            this.buttonClearKeyLogs.UseVisualStyleBackColor = true;
            this.buttonClearKeyLogs.Click += new System.EventHandler(this.ButtonClearKeyLogs_Click);
            // 
            // textBoxKeys
            // 
            this.textBoxKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxKeys.Location = new System.Drawing.Point(3, 3);
            this.textBoxKeys.MaxLength = 2147483647;
            this.textBoxKeys.Multiline = true;
            this.textBoxKeys.Name = "textBoxKeys";
            this.textBoxKeys.ReadOnly = true;
            this.textBoxKeys.Size = new System.Drawing.Size(782, 189);
            this.textBoxKeys.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(808, 363);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // HidHandler
            // 
            this.HidHandler.WorkerSupportsCancellation = true;
            this.HidHandler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.HidHandler_DoWork);
            this.HidHandler.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.HidHandler_RunWorkerCompleted);
            // 
            // buttonImportJson
            // 
            this.buttonImportJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImportJson.Location = new System.Drawing.Point(594, 198);
            this.buttonImportJson.Name = "buttonImportJson";
            this.buttonImportJson.Size = new System.Drawing.Size(191, 24);
            this.buttonImportJson.TabIndex = 3;
            this.buttonImportJson.Text = "Import JSON";
            this.buttonImportJson.UseVisualStyleBackColor = true;
            this.buttonImportJson.Click += new System.EventHandler(this.ButtonImportJson_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 363);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "LogiTacker :: Raw decoder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDecryptHistory;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox deviceListCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader address;
        private System.Windows.Forms.ColumnHeader pid;
        private System.Windows.Forms.ColumnHeader channel;
        private System.Windows.Forms.ColumnHeader payloadLength;
        private System.Windows.Forms.ColumnHeader payload;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonAutoDecrypt;
        private System.Windows.Forms.ColumnHeader payloadDecrypted;
        private System.ComponentModel.BackgroundWorker HidHandler;
        private System.Windows.Forms.TextBox textBoxKeys;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonClearList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonExportJson;
        private System.Windows.Forms.Button buttonClearKeyLogs;
        private System.Windows.Forms.Button buttonImportJson;
    }
}

