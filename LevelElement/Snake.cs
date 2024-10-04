using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_02_dungeon_crawler
{
    internal class Snake : Enemy
    {
        public string Type { get; set; }
        public double HP { get; set; }

        Dice AttackDice = new Dice(numberOfDice: 3, sidesPerDice: 4, modifier: 2);
        Dice DefenceDice = new Dice(numberOfDice: 1, sidesPerDice: 8, modifier: 5);

        public override void Update()
        {
            Console.WriteLine("Uppdaterar ormen");
        }
    }
}
