using System;
using System.Threading;
using FightClub.Characters;
namespace FightClub
{
    class Program 
    {
        static void Main(string[] args)
        {           
            ShowMainMenu();
        }
        public static void ShowRules()
        {
            Console.Clear(); ;
            Console.WriteLine("ПРАВИЛА ИГРЫ:\n");
            Console.WriteLine("В начале игры каждый игрок должен выбрать класс своего персонажа - Воин, Разбойник или Маг. У каждого бойца есть свои характеристики Силы, Ловкости и Выносливости, которые влияют на их урон, шанс уклонения и HP. Также у каждого класса есть своё особое умение, которое они применяют в бою. Далее игроки должны распределить {0} свободных очков характеристик, напрямую влияя на боевые показатели персонажа. 1 единица Силы даёт +{1} урона, единица Ловкости +{2}% шанса уклонения, а 1 единица Выносливости +{3}HP. Бой между персонажами состоит из раундов. В каждом раунде персонажи пытаются нанести друг-другу прямой урон и применить свою спец.способность. Это продолжается до тех пор, пока у кого-то не закончатся очки здоровья.\n", Service.playerFreePoints , Service.damageMultiplier, Service.evasionMultiplier, Service.healthMultiplier);
            Console.WriteLine("Базовые характеристики классов: ");
            Character[] testMass = { new Warrior(), new Rogue(), new Mage() };
            int i = 1;
            foreach (Character testCharacter in testMass)
            {
                Console.WriteLine("{0}.Класс: {1}", i, testCharacter.ClassName);
                Console.WriteLine("{0,-11}{1,-23}{2,-25}", "Сила: " + testCharacter.Strength, "Ловкость: " + testCharacter.Agility, "Выносливость: " + testCharacter.Endurance);
                Console.WriteLine("{0,-11}{1,-23}{2,-25}", "Урон: " + testCharacter.BaseDamage, "Шанс уклониться: " + testCharacter.EvasionChance + "%", "HP: " + testCharacter.Health);
                Console.WriteLine("Специальное умение: " + testCharacter.SpecialPower + "\n");
                i++;
            }
            Console.WriteLine("Нажмите Enter, чтобы вернуться в Главное Меню");
            Console.ReadLine();
            ShowMainMenu();
        }
        public static void StartNewGame()
        {
            Console.Clear();
            Console.WriteLine("Игрок 1, введите имя: ");
            Player player1 = new Player(Console.ReadLine());
            player1.ChooseChampion();
            player1.UpgradeChampion();
            Console.Clear();
            Console.WriteLine("Игрок 2, введите имя: ");
            Player player2 = new Player(Console.ReadLine());
            player2.ChooseChampion();
            player2.UpgradeChampion();
            Console.Clear();
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine("{0}...", i);
                Thread.Sleep(1000);
            }

            //Игра начинается

            int roundCounter = 0;
            do
            {
                roundCounter++;
                Console.Clear();
                Console.WriteLine("Ход {0}", roundCounter);
                if (player2.Champion.IsEvading())
                {
                    Console.WriteLine("{0} пытается атаковать, но {1} ловко уворачивается", player1.PlayerName, player2.PlayerName);
                }
                else
                {
                    Console.WriteLine("{0} ударяет и наносит {1} урона!", player1.PlayerName, player1.Champion.Hit(player2.Champion));
                    if (player1.Champion.ClassName is "Воин")
                    {
                        player1.Champion.UseSpecialPower(player1, player2);
                    }
                }
                if (!(player1.Champion.ClassName is "Воин"))
                {
                    player1.Champion.UseSpecialPower(player1, player2);
                }

                if (player1.Champion.IsEvading())
                {
                    Console.WriteLine("{0} пытается атаковать, но {1} ловко уворачивается", player2.PlayerName, player1.PlayerName);
                }
                else
                {
                    Console.WriteLine("{0} ударяет и наносит {1} урона!", player2.PlayerName, player2.Champion.Hit(player1.Champion));
                    if (player2.Champion.ClassName is "Воин")
                    {
                        player2.Champion.UseSpecialPower(player2, player1);
                    }
                }
                if (!(player2.Champion.ClassName is "Воин"))
                {
                    player2.Champion.UseSpecialPower(player2, player1);
                }
                Console.WriteLine("Результаты хода {0}:", roundCounter);
                player1.PrintChampionInfo();
                player2.PrintChampionInfo();
                Console.ReadLine();

            } while (player1.Champion.Health > 0 & player2.Champion.Health > 0);
            Player.DefineWinner(player1, player2);
            Console.WriteLine("Нажмите Enter, чтобы вернуться в Главное Меню");
            Console.ReadLine();
            ShowMainMenu();
        }
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Игра \"Бойцовский Клуб\"\n");
            Console.WriteLine("1-Новая игра\n2-Правила\n3-Выход");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    StartNewGame();
                    break;
                case "2":
                    ShowRules();
                    break;
                case "3":
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    ShowMainMenu();
                    break;
            }
        }
    }
}
