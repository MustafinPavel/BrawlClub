using System;
using System.Threading;
using FightClub.Characters;
namespace FightClub
{
    public class Player
    {
        public int FreePoints { get; set; }
        public string PlayerName { get; set; }
        public Character Champion { get; set; }

        public Player(string name)
        {
            FreePoints = Service.playerFreePoints;
            PlayerName = name;
        }
        public void ChooseChampion()
        {
            Console.Clear();
            Console.WriteLine("{0}, выберите бойца: ", PlayerName);
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
            string choice;
            do
            {
                choice = Console.ReadLine();

                if (choice != "1" & choice != "2" & choice != "3")
                {
                    Console.WriteLine("Неправильный выбор, выберите бойца:");
                }
                else
                {
                    switch (choice)
                    {
                        case "1":
                            Champion = new Warrior();
                            break;
                        case "2":
                            Champion = new Rogue();
                            break;
                        case "3":
                            Champion = new Mage();
                            break;
                        default:
                            break;
                    }

                }

            } while (choice != "1" & choice != "2" & choice != "3");
            Console.WriteLine("Вы выбрали класс {0}", Champion.ClassName);
            Thread.Sleep(1500);
        }
        public void PrintChampionInfo()
        {
            Console.WriteLine("{0} {1}", Champion.ClassName, PlayerName);
            Console.WriteLine("{0,-11}{1,-23}{2,-25}", "Сила: " + Champion.Strength, "Ловкость: " + Champion.Agility, "Выносливость: " + Champion.Endurance);
            Console.WriteLine("{0,-11}{1,-23}{2,-25}", "Урон: " + Champion.BaseDamage, "Шанс уклониться: " + Champion.EvasionChance + "%", "HP: " + Champion.Health);
            Console.WriteLine("Специальное умение: " + Champion.SpecialPower);
        }
        public void UpgradeChampion()
        {
            do
            {
                Console.Clear();
                PrintChampionInfo();
                Console.WriteLine("Выберите, какую основную характеристику вы хотите повысить:\n1.+1СИЛ даст +{0} к урону.\n2.+1ЛВК даст +{1}% шанс увернуться.\n3.+1ВЫН даст +{2} HP.\nСвободных очков: {3}", Service.damageMultiplier, Service.evasionMultiplier, Service.healthMultiplier, FreePoints);
                switch (Console.ReadLine())
                    {
                        case "1":
                            Champion.Strength++;
                            FreePoints--;
                            break;
                        case "2":
                            Champion.Agility++;
                            FreePoints--;
                            break;
                        case "3":
                            Champion.Endurance++;
                            FreePoints--;
                            break;
                        default:
                            break;
                    }
                
            } while (FreePoints > 0);
        }
        public static void DefineWinner(Player player1, Player player2)
        {
            if (player1.Champion.Health == player2.Champion.Health)
            {
                Console.WriteLine("Бой окончен. Ничья! Противники оба рухнули на землю!");
            }
            else if (player1.Champion.Health > player2.Champion.Health)
            {
                Console.WriteLine("Бой окончен. Победитель - {0}!\nAll Hail {0}!", player1.PlayerName);
                
            }
            else
            {
                Console.WriteLine("Бой окончен. Победитель - {0}!\nAll Hail {0}!", player2.PlayerName);
            }
        }       
    }
}
