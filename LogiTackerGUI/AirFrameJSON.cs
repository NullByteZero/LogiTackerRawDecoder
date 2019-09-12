using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTackerGUI {
    class AirFrameJSON {
        public string Address { get; set; }
        public byte PID { get; set; }
        public byte Ch { get; set; }
        public sbyte RSSI { get; set; }
        public byte Length { get; set; }
        public string Payload { get; set; }
        public string DecryptedPayload { get; set; }
    }
}
