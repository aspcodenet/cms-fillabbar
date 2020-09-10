using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilLabbar
{
    class Program
    {
        static void Lab1()
        {
            string inFile = "..\\..\\Lab1TextFile-InData.txt";

            bool odd = true;

            using (StreamReader sr = File.OpenText(inFile))
            {
                string line;
                while (true)
                {
                    line = sr.ReadLine();
                    if (line == null) break;
                    if (odd)
                        Console.WriteLine(line);
                    odd = !odd;
                }

                //while ((line = sr.ReadLine()) != null)
                //{
                //    if(odd)
                //        Console.WriteLine(line);
                //    odd = !odd;
                //}
            }
        }

        static void Lab2()
        {
            string outFile = "..\\..\\Lab2TextFile-UtData.txt";
            string inFile1 = "..\\..\\Lab2TextFile-Indata1.txt";
            string inFile2 = "..\\..\\Lab2TextFile-Indata2.txt";

            if (File.Exists(outFile))
                File.Delete(outFile);

            using(StreamWriter sw = File.CreateText(outFile))
            {
                using (StreamReader sr = File.OpenText(inFile1))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine(line); 
                    }
                }
                using (StreamReader sr = File.OpenText(inFile2))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine(line);
                    }
                }


            }


        }

        static void Lab3()
        {
            string outFile = "..\\..\\Lab3TextFile-UtData.txt";
            string inFile1 = "..\\..\\Lab3TextFile-Indata.txt";

            if (File.Exists(outFile))
                File.Delete(outFile);

            int number = 1;
            using (StreamWriter sw = File.CreateText(outFile))
            {
                using (StreamReader sr = File.OpenText(inFile1))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine($"{number} {line}");
                    }
                }

            }

        }

        static void Lab4()
        {
            string inFile1 = "..\\..\\Lab4TextFile-Indata1.txt";
            string inFile2 = "..\\..\\Lab4TextFile-Indata2.txt";
            int samma = 0;
            int olika = 0;
            using (StreamReader sr = File.OpenText(inFile1))
            {
                using (StreamReader sr2 = File.OpenText(inFile2))
                {
                    string line1;
                    string line2;

                    while (true)
                    {
                        line1 = sr.ReadLine();
                        line2 = sr2.ReadLine();
                        if (line1 == null && line2 == null) break;
                        if (line1 == line2)
                            samma++;
                        else
                            olika++;
                    }
                }
            }
            Console.WriteLine($"Samma:{samma}   Olika:{olika}");
        }

        static void Lab5()
        {
            string inFile1 = "..\\..\\Lab5TextFile-Indata1.txt";
            string outFile = "..\\..\\Lab5TextFile-UtData.txt";

            if (File.Exists(outFile))
                File.Delete(outFile);


            string[] birds = File.ReadAllLines(inFile1);
            Array.Sort(birds);
            File.WriteAllLines(outFile,birds);

        }


        static Random rnd = new Random();
        static string GenerateRandomString(int len)
        {
            //Many spaces = more often
            var chars = "         ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var sb = new StringBuilder();

            while (len > 0)
            {
                int slumpPosition = rnd.Next(0, chars.Length-1);
                char ch = chars[slumpPosition];
                sb.Append(ch);
                len--;
            }
            return sb.ToString();

        }
        static void CreateFile(string path, int sizeInBytes)
        {
            if (File.Exists(path))
                File.Delete(path);
            using (StreamWriter sw = File.CreateText(path))
            {
                while(sizeInBytes > 0)
                {
                    string random = GenerateRandomString(80);
                    sw.WriteLine(random);
                    sizeInBytes -= 80;
                }
            }


        }

        static void Lab7()
        {
            var lab = new Lab7.Lab();
            lab.Run();
        }


        static void Lab8()
        {
            Console.Write("Skriv in sökväg:");
            string dir = Console.ReadLine();
            Console.Write("Skriv in fil att söka efter:");
            string file = Console.ReadLine();


            foreach(var f in Directory.GetFiles(dir))
            {
                if(System.IO.Path.GetFileName(f).Equals(file,StringComparison.OrdinalIgnoreCase))
                {
                    var fi = new FileInfo(f);
                    Console.WriteLine($"Hittade filen den är {fi.Length}");
                }
            }

        }

        static void Lab6()
        {
            string outFile = "..\\..\\Lab6TextFile-UtData.txt";
            CreateFile(outFile,100000);
        }

        static void Main(string[] args)
        {
            Lab8();
            var l = new Lab7_2();
            l.Run();
            //var line1 = "abc123";
            //var line2 = "Abc123";
            //if (string.Equals(line1, line2, StringComparison.CurrentCultureIgnoreCase))
            //{
            //    Console.WriteLine("Samma");
            //}
            //if (line1.ToLower() == line2.ToLower() )
            //{
            //    Console.WriteLine("Samma");
            //}

            Lab7();
            Lab6();
            Lab5();
            Lab4();
            Lab3();
            Lab2();
            Lab1();
        }
    }
}
