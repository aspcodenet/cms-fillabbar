using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilLabbar.Lab7
{
    class Lab
    {
        int SelectMenu(int min, int max)
        {
            while(true)
            {
                Console.Write($"Välj {min}-{max}:");
                int sel;
                if (int.TryParse(Console.ReadLine(), out sel) == false || sel < min || sel > max)
                {
                    Console.WriteLine("Ogiltigt tal");
                }
                else
                    return sel;
            }
        }
        int ShowMenu()
        {
            Console.WriteLine("Meny");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Registrera nytt konto");
            return SelectMenu(1, 2);

        }

        void Register()
        {
            var repository = new AccountRepository();
            Console.Write("Ange användarnamn:");
            string namn = Console.ReadLine();

            Account existingAccount = repository.GetAccount(namn);
            if(existingAccount != null)
            {
                Console.WriteLine("Fel - kontot finns redan!!!");
                return;
            }

            Console.Write("Ange lösenord:");
            string password = Console.ReadLine();

            var newAccount = new Account(namn, password);
            repository.UpdateAccount(newAccount);
        }


        public void Login()
        {
            var repository = new AccountRepository();


            Console.Write("Try to login...ange användarnamn:");
            string namn = Console.ReadLine();
            var ac = repository.GetAccount(namn);
            if(ac == null)
            {
                Console.WriteLine("hmm vi hittar díg inte?");
                return;
            }

            Console.Write("Ange lösenord:");
            string password = Console.ReadLine();
            if(ac.Password != password)
            {
                Console.WriteLine("fel lösen?");
                return;
            }
            Console.WriteLine("Inloggad - press enter to continue");
            Console.ReadLine();

        }

        public void Run()
        {

            while (true)
            {
                int sel = ShowMenu();
                if (sel == 2)
                    Register();
                else
                    Login();
            }
        }
    }
}
