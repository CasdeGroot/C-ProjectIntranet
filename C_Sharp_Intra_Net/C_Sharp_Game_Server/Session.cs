using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Game_Server
{
    class Session
    {
        static Dictionary<string, Account> sessions = new Dictionary<string, Account>();
        static Dictionary<string, Timer> SessionTimers = new Dictionary<string, Timer>();

        public static string NewSession(Account a)
        {
            byte[] rnd = new byte[5];
            new Random().NextBytes(rnd);
            string token = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(rnd)).Replace("-", "");

            sessions.Add(token, a);
            SessionTimers.Add(token, new Timer(SessionExpire, token, TimeSpan.FromMinutes(20), TimeSpan.FromMilliseconds(-1)));
            return token;
        }

        public static bool TryGetAccount(string token, out Account a)
        {
            a = null;
            if (!sessions.ContainsKey(token))
                return false;

            a = sessions[token];
            SessionTimers[token].Change(TimeSpan.FromMinutes(20), TimeSpan.FromMilliseconds(-1));
            return true;
        }

        private static void SessionExpire(object state)
        {
            SessionTimers.Remove((string)state);
            sessions.Remove((string)state);
        }
    }
}
