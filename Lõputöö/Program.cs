using System;

namespace Lõputöö
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Start:

            Console.Title = "Lõputöö";
            Console.WriteLine("Kirjuta sisse sõna, mille meetodit kasutada soovid");

            Console.WriteLine("\n1. Range");
            Console.WriteLine("2. TakeWhile");
            Console.WriteLine("3. If ja else faili salvestamine (Salvestamine)");
            Console.WriteLine("4. Forloopi numbripüramiid (Püramiid)");

            string Too = Console.ReadLine();

            switch (Too)
            {
                case "Range":
                    Range();
                    break;

                case "TakeWhile":
                    TakeWhile();
                    break;

                case "Salvestamine":
                    Salvestamine();
                    break;

                case "Püramiid":
                    Püramiid();
                    break;

                default:
                    Console.WriteLine("\nVale. Valikut ei tehtud.");
                    break;
            }
            Console.ReadKey();
            //goto Start;



        }

        public static void Range()
        {
            Console.WriteLine("EmptyRangeRepeat LINQ");

            var emptyColletion1 = Enumerable.Empty<string>();
            var emptyColletion2 = Enumerable.Empty<People>();

            Console.WriteLine("Type {0}" + emptyColletion1.GetType().Name);
            Console.WriteLine("Count: {0} " + emptyColletion1.Count());

            Console.WriteLine("Type {0}" + emptyColletion2.GetType().Name);
            Console.WriteLine("Count: {0} " + emptyColletion2.Count());

            var intCollection = Enumerable.Range(3, 9);
            Console.WriteLine("Total count: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
            {
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));
            }

            var repeatCollection = Enumerable.Range(3, 9);
            Console.WriteLine("Total count: {0} ", intCollection.Count());

            for (int i = 0; i < repeatCollection.Count(); i++)
            {
                Console.WriteLine("Value at index {0} : {1}", i, repeatCollection.ElementAt(i));
            }
        }

        public static void TakeWhile()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("----------Take--------------");
            //jätab esimesed kolm rida välja
            var skip = PeopleList.peoples.Take(3);

            foreach (var item in skip)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("----------TakeWhile--------------");
            //näitab kõiki, kellel on neli või vähem tähemärki 
            var skipWhile = PeopleList.peoples.TakeWhile(s => s.Name.Length > 4);

            foreach (var item in skipWhile)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void Salvestamine()
        {
            Console.WriteLine("Kui url on vale, siis annab " +
                "veateate. Kui on õige, siis ütleb, " +
                "et kõik on korras");
            Console.WriteLine("Kui on õige, siis loob faili " +
                "koos sinu sisestatud tekstiga");
            //kasutada if ja else

            string wrongPath = "V:/Users/opilane/Desktop/FileToDesktop.txt";
            string wrightPath = "C:/Users/opilane/Desktop/FileToDesktop.txt";

            Console.WriteLine("Tee valik numbriga:");
            Console.WriteLine("1 on vale url");
            Console.WriteLine("2 on õige url");
            string choose = Console.ReadLine();

            if (choose == "1")
            {
                try
                {
                    string inputText = Console.ReadLine();
                    File.WriteAllText(wrongPath, inputText);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ei salevstanud desktopile file kuna " +
                        "seda urli ei ole");
                    Console.WriteLine(ex.Message);
                }
            }
            if (choose == "2")
            {
                string inputText = Console.ReadLine();
                File.WriteAllText(wrightPath, inputText);

                Console.WriteLine("Salvestas edukalt desktopile");
            }
        }

        private static void Püramiid()
        {
            Console.WriteLine("\nSisesta püramiidi suurus (töö jaoks 3)");

            double length = double.Parse(Console.ReadLine());

            for (int row = 1; row <= length; row++)
            {
                for (int column = 1; column <= length * 2 - 1; column++)
                {
                    string mark = " ";

                    if (row == length)
                    {
                        mark = "1";
                    }
                    else if (row + column >= length + 1 && column - length + 1 <= row)
                    {
                        mark = "2";
                    }
                    Console.Write(mark);
                }
                Console.WriteLine();
            }
        }
    }
}
