using System;
namespace FightClub.Characters
{
    public abstract class Character
    {

        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                BaseDamage = value * Service.damageMultiplier;
            }
        }
        private int agility;
        public int Agility
        {
            get { return agility; }
            set
            {
                agility = value;
                EvasionChance = value * Service.evasionMultiplier;
            }
        }
        private int endurance;
        public int Endurance
        {
            get { return endurance; }
            set
            {
                endurance = value;
                Health = value * Service.healthMultiplier;
            }
        }
        public int BaseDamage { get; private set; }
        public int EvasionChance { get; private set; }
        private int health;
        public int Health
        {
            get { return health; }
            set
            {
                if (value >= 0)
                    health = value;
                else health = 0;
            }
        }
        public string ClassName { get; protected set; }
        public string SpecialPower { get; protected set; }

        public Character(string classname, string specialpower, int strength, int agility, int endurance)  
        {
            ClassName = classname;
            SpecialPower = specialpower;
            Strength = strength;
            Agility = agility;
            Endurance = endurance;
        }

        public int Hit(Character victim)
        {            
            int damage = new Random().Next(BaseDamage - 10, BaseDamage + 11);  //разброс +/- 10
            victim.Health -= damage;
            return damage;
        }
        public bool IsEvading()
        {
            int hitChance = new Random().Next(0, 101);
            bool evade = hitChance < EvasionChance ? true : false;
            return evade;
        }
        public abstract void UseSpecialPower(Player attacker, Player victim);         //Переписать логику метода
    }
}
