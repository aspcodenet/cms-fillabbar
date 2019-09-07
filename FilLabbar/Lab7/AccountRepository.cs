using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilLabbar.Lab7
{
    class AccountRepository
    {
        string accountFile = "..\\..\\Lab7Accounts.txt";

        //Två olika sätt...ReadAllLines (lättare), StereamReader (svårare)
        //för och nackdelar???

        public void UpdateAccount(Account account)
        {
            string[] allAccounts = new string[0];

            if(File.Exists(accountFile) )
                allAccounts = System.IO.File.ReadAllLines(accountFile);

            bool found = false;
            for(int i = 0; i < allAccounts.Length;i++)
            {
                Account ac = Account.FromString(allAccounts[i]);
                if (ac.Username == account.Username)
                {
                    allAccounts[i] = account.ToString();
                    found = false;
                    break;
                }
            }
            if(found)
                System.IO.File.WriteAllLines(accountFile, allAccounts);
            else
                System.IO.File.AppendAllText(accountFile, account.ToString());
        }

        public Account GetAccount(string userName)
        {
            if (!File.Exists(accountFile)) return null;

            using (StreamReader sr = File.OpenText(accountFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Account ac = Account.FromString(line);
                    if (ac.Username == userName) return ac;
                }
            }
            return null;
        }
    }
}
