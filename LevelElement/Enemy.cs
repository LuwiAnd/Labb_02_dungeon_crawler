using System.Data;

namespace Labb_02_dungeon_crawler
{
    abstract class Enemy : LevelElement
    {
        //private int[] _position;

        //public override int[] Position
        //{
        //    get { return this._position; }
        //    // positionen får endast sättas av konstruktorn, eller av Update-funktionen.
        //}
        public string Type { get; set; }
        public double HP { get; set; }

        public Dice AttackDice;
        public Dice DefenceDice;

        //protected AttackDice;
        //protected DefenceDice;

        public abstract void Update();
        public virtual bool Defend(int damage)
        {
            this.HP -= damage;
            bool isDead = (HP <= 0);
            return isDead;
        }

        public virtual int AttackHero(Hero hero)
        {
            int attack = this.AttackDice.Throw();
            int defence = hero.D
        }
    }
}