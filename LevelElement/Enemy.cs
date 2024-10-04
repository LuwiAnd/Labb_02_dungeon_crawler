using System.Data;

namespace Labb_02_dungeon_crawler
{
    abstract class Enemy
    {
        public string Type { get; set; }
        public double HP { get; set; }

        public Dice AttackDice;
        public Dice DefenceDice;

        //protected AttackDice;
        //protected DefenceDice;

        public abstract void Update();
    }
}