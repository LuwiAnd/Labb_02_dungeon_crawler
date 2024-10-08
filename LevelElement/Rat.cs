using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_02_dungeon_crawler
{
    internal class Rat : Enemy
    {
        //private int[] _position;

        //public override int[] Position
        //{
        //    get { return this._position; }
        //    // positionen får endast sättas av konstruktorn, eller av Update-funktionen.
        //}
        //public string Type { get; set; }
        //public double HP { get; set; }

        //Dice AttackDice = new Dice(numberOfDice: 1, sidesPerDice: 6, modifier: 3);
        //Dice DefenceDice = new Dice(numberOfDice: 1, sidesPerDice: 6, modifier: 1);

        public override void Update()
        {
            Console.WriteLine("Uppdaterar råttan");
        }

        //public Rat(int[] position)
        public Rat(int positionX, int positionY)
        {
            //this._position = position;
            this.Position = new Position(x: positionX, y: positionY);
            this.HP = 10;
            this.Type = "rat";
            this.AttackDice = new Dice(numberOfDice: 1, sidesPerDice: 6, modifier: 3);
            this.DefenceDice = new Dice(numberOfDice: 1, sidesPerDice: 6, modifier: 1);
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
