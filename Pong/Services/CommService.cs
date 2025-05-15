using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Services
{
    public class CommService : ICommService
    {
        private SerialPort _commPort = new SerialPort();

        public CommService() 
        {
            _commPort.DataReceived += _commPort_DataReceived;
        }

        public bool IsReady => _commPort.BaudRate != default && !string.IsNullOrWhiteSpace(_commPort.PortName);

        public string Port
        {
            get { return _commPort.PortName; }
            set { _commPort.PortName = value; }
        }

        public int Baud
        {
            get { return _commPort.BaudRate; }
            set { _commPort.BaudRate = value; }
        }

        private void _commPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string incoming_data = _commPort.ReadExisting();
        }

        public void SendCommand(string cmd)
        {
            if (_commPort.IsOpen)
            {
                _commPort.WriteLine(cmd);
            }
        }

        public void Start()
        {
            if (IsReady) { _commPort.Open(); }
            else { throw new Exception("Comm port has not been configured."); }
        }

        public void Stop()
        {
            if (_commPort.IsOpen) { _commPort.Close(); }
        }
    }
}
