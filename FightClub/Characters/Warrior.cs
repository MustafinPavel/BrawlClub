using System;
namespace FightClub.Characters
{
    public class Warrior : Character
    {
        public Warrior() : base ("Воин", "Ярость - После удачного удара воин впадает в ярость и трижды атакует противника щитом. Урон каждого удара равен показателю СИЛ воина.", 5, 0, 5)
        {

        }
        public override void UseSpecialPower(Player attacker, Player victim)
        {
            int damage = attacker.Champion.Strength * 3;
            Console.WriteLine("После успешной атаки {0} впадает в ярость и несколько раз бьёт противника щитом, нанося в сумме {1} урона.", attacker.PlayerName, damage);       //дописать спецспособность
            victim.Champion.Health -= damage;
        }
    }
}
