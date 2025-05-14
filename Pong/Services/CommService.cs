using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Services
{
    public class CommService
    {
        private SerialPort _commPort;

        public CommService(string port, int baud)
        {
            _commPort = new SerialPort(port, baud);
            _commPort.DataReceived += _commPort_DataReceived;
        }

        private void _commPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string incoming_data = _commPort.ReadExisting();
        }

        public void SendCommand(string cmd)
        {
            _commPort.WriteLine(cmd);
        }

        public void Start()
        {
            _commPort.Open();
        }

        public void Stop()
        {
            _commPort.Close();
        }
    }
}
