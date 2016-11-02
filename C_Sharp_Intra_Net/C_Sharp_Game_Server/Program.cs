using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Game_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("accounts.json"))
                File.Create("accounts.json").Close();

            TcpServer.Start();
        }
    }
}
