using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilLabbar
{
    class Lab7_2
    {
        public void Run()
        {
            string loggedInUser = "";
            while (true)
            {
                Console.WriteLine($"Hej {loggedInUser}");
                int sel = ShowMenu();
                if (sel == 2)
                    Register();
                else if (sel == 1)
                    loggedInUser = Login();
                else break;
            }
        }

        private string Login()
        {
            Console.WriteLine("Användarnamn:");
            string inputName = Console.ReadLine();
            Console.WriteLine("Lösenord:");
            string inputPwd = Console.ReadLine();

            string[] accountLines = System.IO.File.ReadAllLines("..\\..\\Lab7Accounts.txt");
            foreach (var line in accountLines)
            {
                string []splittedString = line.Split(':');
                var userId = splittedString[0];
                var userPwd = splittedString[1];
                if (userId == inputName && inputPwd == userPwd)
                {
                    Console.WriteLine("Du är inloggad");
                    return userId;
                }
            }
            return string.Empty;
        }


        private void Register()
        {
            Console.WriteLine("Nytt Användarnamn:");
            string inputName = Console.ReadLine();
            Console.WriteLine("Nytt Lösenord:");
            string inputPwd = Console.ReadLine();

            string newLineToAddToFile = inputName +":" + inputPwd;

            //File.AppendAllText("..\\..\\Lab7Accounts.txt", newLineToAddToFile);

            using (var sw = File.AppendText("..\\..\\Lab7Accounts.txt"))
            {
                sw.WriteLine(newLineToAddToFile);
            }
        }


        int SelectMenu(int min, int max)
        {
            while (true)
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
            Console.WriteLine("3. Avsluta programmet");
            return SelectMenu(1, 3);

        }

    }
}
