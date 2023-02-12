using System;
namespace FightClub.Characters
{
    public class Rogue : Character
    {
        public Rogue() : base ("Разбойник", "Амбидекстр - при ударе есть 25% шанс отвлечь противника и незаметно ударить второй рукой в уязвимое место. Удар второй рукой наносит х3 урона.", 3, 4, 3)
        {

        }

        public override void UseSpecialPower(Player attacker, Player victim)
        {
            int i = new Random().Next(1, 101);
            if (i >= 75)
            {
                int damage = new Random().Next(attacker.Champion.BaseDamage - 10, attacker.Champion.BaseDamage + 10) * 3;
                Console.WriteLine("{0} успешно обманывает своего противника и производит удар второй рукой. Атака наносит {1} урона",attacker.PlayerName , damage);
                victim.Champion.Health -= damage;
            }
            else
            {
                Console.WriteLine("{0} пытается провести удар второй рукой, но противник уворачивается.", attacker.PlayerName);                
            }            
        }
    }
}
