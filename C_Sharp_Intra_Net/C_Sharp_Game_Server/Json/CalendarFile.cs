using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Game_Server.Json
{
    class CalendarFile
    {
    }

    public class Calendar
    {
        public int ID;
        public string CalendarName;
        public string PasswordHash;
        // Usernames of the accounts which can acces the Calendar
        public List<String> VerifiedAccounts = new List<string>();
         
    }
}
