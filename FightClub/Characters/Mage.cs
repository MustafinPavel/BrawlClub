using System;
namespace FightClub.Characters
{
    public class Mage : Character
    {
        public Mage() : base ("Маг", "Огненный шар - каждый ход маг использует огненный шар, чтобы нанести дополнительный урон. Наносит от 1 до 60 урона.", 2, 3, 5)
        {       
          
        }

        public override void UseSpecialPower(Player attacker, Player victim)
        {
            int damage = new Random().Next(1, 61);
            if (damage <= 10)
            {
                Console.WriteLine("{0} не может сконцентрироваться и вслепую бросает слабо заряженный Огненный Шар. {1} урона",attacker.PlayerName, damage);
            }
            else if (damage > 10 & damage < 40)
            {
                Console.WriteLine("{0} бросает в противника Огненный Шар. {1} урона", attacker.PlayerName , damage);
            }
            else
            {
                Console.WriteLine("{0} телепортируется в слепую зону противника, концентрируется и бросает Мощный Огненный Шар. {1} урона",attacker.PlayerName, damage);
            }
            victim.Champion.Health -= damage;
        }
    }
}
