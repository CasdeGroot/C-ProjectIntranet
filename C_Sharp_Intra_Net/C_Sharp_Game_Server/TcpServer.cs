using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Game_Server
{
    class TcpServer
    {
        private static int _port = 1337;
        private static TcpListener _listener;


        public static void Start()
        {
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();

            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                new Thread(HandleConnection).Start(client);
            }
        }

        private static void HandleConnection(object o)
        {
            TcpClient client = (TcpClient)o;

            Console.WriteLine($"Connection from: {client.Client.RemoteEndPoint}");

            byte[] buffer = new byte[163840];

            int bytesRead = client.GetStream().Read(buffer, 0, buffer.Length);

            byte[] jsonBytes = buffer.Take(bytesRead).ToArray();

            Packet p = JsonConvert.DeserializeObject<Packet>(Encoding.Default.GetString(jsonBytes));

            Console.WriteLine($"Request: {p.PacketType}");


            switch (p.PacketType)
            {
              

    
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void Send(TcpClient client, Packet p)
        {
            var bytes = Encoding.Default.GetBytes(JsonConvert.SerializeObject(p));
            client.GetStream().Write(bytes, 0, bytes.Length);
            client.Close();
        }

       

    }
}
