using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnelRekenen
{
    class Program
    {
        private static readonly string scoreBestand = @"C:\temp\scorebestand.txt";

        static void Main(string[] args)
        {

            Console.Write("Wat is je naam? ");
            var naam = Console.ReadLine();
            Console.Write("Hey... " + naam + "! ");

            while (true)
            {
                Console.Write("Welk level wil je spelen? ");
                var levelText = Console.ReadLine();
                var level = int.Parse(levelText);

                Console.WriteLine("Je hebt 1 minuut de tijd om zoveel mogelijk rekensommen op te lossen, als je wilt stoppen druk je gewoon op enter.");
                Console.WriteLine();
                Console.WriteLine("Druk op een toets om te starten.");
                Console.ReadKey();


                var score = 0;

                var stopwatch = new Stopwatch();

                while (true)
                {
                    var willekeurig = new Random();
                    var a = willekeurig.Next(1, level + 1);
                    var b = willekeurig.Next(1, level + 1);
                    var uitkomst = a * b;

                    stopwatch.Start();

                    Console.Clear();
                    Console.Write("Reken dit uit: " + a + " x " + b + " = ");
                    var antwoord = Console.ReadLine();
                    if (antwoord == "")
                        break;

                    if (stopwatch.Elapsed.TotalSeconds > 60)
                    {
                        Console.WriteLine("Helaas, je tijd is om.");
                        break;
                    }


                    if (antwoord == uitkomst.ToString())
                    {
                        ++level;
                        score += uitkomst;
                    }
                    else {
                        Console.WriteLine("Helaas, het goede antwoord is " + uitkomst);
                        break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Je totale score was: " + score);
                SchrijfScoreWegNaarBestand(naam, score);
                var scores = HaalAlleScoresOp();
                scores = SorteerScoresOpPunten(scores);

                int rang = 1;
                foreach (var s in scores)
                {
                    Console.WriteLine(rang + ".\t" + s.Naam + "\t" + s.Punten);
                    if (rang == 10)
                        break;
                    rang++;
                }
                Console.WriteLine();
                Console.WriteLine("Wil je nog een keer spelen? Selecteer J of N. ");

                
                if (Console.ReadKey().Key == ConsoleKey.N)
                    break;
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Tot ziens " + naam);
            Console.ReadKey();

        }

        private static List<Score> SorteerScoresOpPunten(List<Score> scores)
        {
            return scores.OrderByDescending(s => s.Punten).ToList();
        }

        private static List<Score> HaalAlleScoresOp()
        {
            var scoreLijst = new List<Score>();
            var scores = File.ReadAllLines(scoreBestand);
            foreach (var score in scores)
            {
                scoreLijst.Add(new Score(score));
            }
            return scoreLijst;
        }

        private static void SchrijfScoreWegNaarBestand(string naam, int score)
        {
            File.AppendAllText(scoreBestand, Environment.NewLine + naam + "\t" + score);
        }
    }
}
