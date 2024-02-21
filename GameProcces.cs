using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace HeroAutoGame

{
    internal class GameProccess
    {
      /*  private static Stopwatch timer = new Stopwatch();
        private static Store store = new Store();
        private static int menu;
        private static string menu_;
        private static List<Hero> heroesList1 = new List<Hero>();
        private static List<Hero> heroesList2 = new List<Hero>();
        private static Hero player1;
        private static Hero player2;
        private static ConsoleKeyInfo key;
        private static Weather weather;
        private static int round;*/

        public static String gameIntro()
        {
           return "This game is about fighting between heroes.\n" +
                "Heroes can grow by earning gold, buying items, etc";
      
        }

      /*  private static bool canYouPlay()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\t\tPress ENTER to start game");
            Console.WriteLine("\t\tPress any key to exit");
            key = Console.ReadKey();
            if (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\tBYE");
                return false;
            }
            return true;
        }

        private static Hero HeroSelection(List<Hero> heroes, string player)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n  " + player + ":\tChoose the hero: ");
                Hero_Viewer.HeroesCards(heroes);
                menu = -1;
                key = Console.ReadKey();
                char f;
                try
                {
                    f = (key.KeyChar);
                    menu = Int16.Parse(f.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input"); Thread.Sleep(1000);
                    continue;
                }

            } while (menu == -1 || menu > heroes.Count());
            return heroes[menu - 1];
        }

        private static void PrepareGame(List<Artefact> artefacts_LVL1, List<Artefact> artefacts_LVL2)
        {
            player1 = HeroSelection(heroesList1, "PLAYER 1");
            Console.WriteLine("\n PLAYER 1 has chosen " + player1.Name);
            Thread.Sleep(2000);
            player2 = HeroSelection(heroesList2, "PLAYER 2");
            Console.WriteLine("\n PLAYER 2 has chosen " + player2.Name);
            Thread.Sleep(2000);
            store.store(artefacts_LVL1, artefacts_LVL2, player1, "PLAYER 1");
            Console.Clear();
            store.store(artefacts_LVL1, artefacts_LVL2, player2, "PLAYER 2");
            Console.Clear();
            FightMessage();
        }
        private static void FightStore(List<Artefact> artefacts_LVL1, List<Artefact> artefacts_LVL2)
        {
            if (round % 5 == 0)
            {
                store.store(artefacts_LVL1, artefacts_LVL2, player1, "PLAYER 1");
                Console.Clear();
                store.store(artefacts_LVL1, artefacts_LVL2, player2, "PLAYER 2");
                Console.Clear();
            }
        }
        private static void BeforeFightHeroesStats()
        {
            Console.Clear();
            Hero_Viewer.mainStats(player1);
            Hero_Viewer.mainStats(player2);
            Thread.Sleep(2000);
            Console.Clear();
        }
        private static bool isHeroAlive(Hero cheked, Hero player)
        {
            if (!cheked.isHeroAlive())
            {
                Console.WriteLine("\n\n\n\n\t\t" + player.Name + "\n\t\tWINNER");
                Thread.Sleep(2000);
                Console.Clear();
                return false;
            }
            return true;
        }
        private static void Player1Attack()
        {
            Func<int, int, int> damageRecievePlayer2 = player2.getAttacked;
            Hero_Viewer.mainStats(player1); //Stats in the moment
            Console.WriteLine(" PLAYER 1 - " + player1.Name + " attacking:");
            int dmg = damageRecievePlayer2(player1.phisicalAttack(), player1.magicalAttack()); // damaging Hero 2
            player1.DamageCounter(dmg); //counting dealt damage
            player1.other(player2, dmg);
            Hero_Viewer.mainStats(player2);//Stats in the moment
            Thread.Sleep(2500);
            Console.Clear();
        }
        private static void Player2attack()
        {
            Func<int, int, int> damageRecievePlayer1 = player1.getAttacked;
            Hero_Viewer.mainStats(player1); //Stats in the moment
            Console.WriteLine(" PLAYER 2 - " + player2.Name + " attacking:");
            int dmg = damageRecievePlayer1(player2.phisicalAttack(), player2.magicalAttack()); // damaging Hero 1
            player2.DamageCounter(dmg); //counting dealt damage
            player2.other(player1, dmg);
            Hero_Viewer.mainStats(player2);
            Thread.Sleep(2500);
            Console.Clear();
        }
        private static void Fight(List<Artefact> artefacts_LVL1, List<Artefact> artefacts_LVL2)
        {
            round = 1;
            BeforeFightHeroesStats();
            timer.Start();
            while (true)
            {
                FightStore(artefacts_LVL1, artefacts_LVL2);
                Player1Attack();
                if (!isHeroAlive(player2, player1)) break;
                Player2attack();
                if (!isHeroAlive(player1, player2)) break;
                round++;
            }
            timer.Stop();



        }
        private static void FightMessage()
        {
            Console.Clear();
            Console.WriteLine(".\n\n\n\n\n\t\t\t " + player1.Name + "\n\t\t\t\tVS\n" + "\t\t\t " + player2.Name);
            Thread.Sleep(2000);
            Console.Clear();
        }
        private static void WeatherLoader()
        {
            weather = new Weather_choosing().randWeather();
            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey();
        }
        private static void initializeHeroes()
        {
            heroesList1.Add(new Juggernaut());
            heroesList1.Add(new Nature_Prophet());
            heroesList1.Add(new Alchemist());
            heroesList2.Add(new Juggernaut());
            heroesList2.Add(new Nature_Prophet());
            heroesList2.Add(new Alchemist());
        }
        public static bool GAME(List<Artefact> artefacts_LVL1, List<Artefact> artefacts_LVL2)
        {
            if (!canYouPlay()) return false;
            gameIntro();
            initializeHeroes();
            WeatherLoader();
            PrepareGame(artefacts_LVL1, artefacts_LVL2);
            Fight(artefacts_LVL1, artefacts_LVL2);
            return true;
        }*/
    }
}