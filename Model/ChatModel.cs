using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ClientApp.Model
{
    public class ChatModel
    {
        private readonly string _ip;
        private readonly int _port;
        private TcpClient _client;
        private NetworkStream _stream;

        public ChatModel(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }
        public void Connect()
        {
            _client = new TcpClient(_ip, _port);
            _stream = _client.GetStream();
        }
        public void SendMessage(string message)
        {
            using (StreamWriter writer = new StreamWriter(_stream, Encoding.UTF8, 1024, true) { AutoFlush = true })
            {
                writer.WriteLine(message);
            }
        }
        public string ReceiveMessage()
        {
            using (StreamReader reader = new StreamReader(_stream, Encoding.UTF8, true, 1024, true))
            {
                return reader.ReadLine();
            }
        }
        public void Close()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}
