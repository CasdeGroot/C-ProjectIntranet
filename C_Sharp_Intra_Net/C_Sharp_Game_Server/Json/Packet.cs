using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Game_Server.Json
{
    class Packet
    {
        public EPacketType PacketType;
        public string Token;
        public string Payload;
    }

    enum EPacketType
    {
        
    }
}
