using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Game_Server.Json
{ 

     public class Account
    {
    public int ID;
    public string Username;
    public string PasswordHash;
    public bool isAdmin;
    public string FirstName;
    public string LastName;
    public int Age;
    public List<Calendar> Calendars = new List<Calendar>();
    }

    public class AccountFile
    {
        public List<Account> Accounts = new List<Account>();

        public List<Account> GetAccounts()
        {
            var accountfile = JsonConvert.DeserializeObject<AccountFile>(File.ReadAllText("accounts.json"));
            return accountfile.Accounts;

        }

        
        public static Account GetAccount(string username)
        {
            return JsonConvert.DeserializeObject<AccountFile>(File.ReadAllText("accounts.json"))
                .Accounts.First(a => a.Username == username);
        }


        public static void AddNewAccount(string username, string passwordhash, bool isAdmin, string firstName, string lastName, int age)
        {
            var accountFile = JsonConvert.DeserializeObject<AccountFile>(File.ReadAllText("accounts.json"));
            int nextID = accountFile.Accounts.Select(a => a.ID).Max() + 1;

            accountFile.Accounts.Add(new Account() { ID = nextID, Username = username, PasswordHash = passwordhash,
                                                     isAdmin = isAdmin, FirstName = firstName, LastName = lastName, Age = age });
        }


        public static void Update(Account account)
        {
            var accountsfile = JsonConvert.DeserializeObject<AccountsFile>(File.ReadAllText("accounts.json"));
            accountsfile.Accounts[accountsfile.Accounts.FindIndex(a => a.ID == account.ID)] = account;

            File.WriteAllText("accounts.json", JsonConvert.SerializeObject(accountsfile));
        }

    }

   
}
