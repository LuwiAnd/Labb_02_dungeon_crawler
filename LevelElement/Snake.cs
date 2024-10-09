using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Labb_02_dungeon_crawler
{
    internal class Snake : Enemy
    {
        //private int[] _position;

        //public override int[] Position
        //{
        //    get { return this._position; }
        //    // positionen får endast sättas av konstruktorn, eller av Update-funktionen.
        //}
        //public string Type { get; set; }
        //public double HP { get; set; }

        //Dice AttackDice = new Dice(numberOfDice: 3, sidesPerDice: 4, modifier: 2);
        //Dice DefenceDice = new Dice(numberOfDice: 1, sidesPerDice: 8, modifier: 5);

        public override void Update()
        {
            Console.WriteLine("Uppdaterar ormen");
        }

        //public Snake(int[] position)
        public Snake(int positionX, int positionY)
        {
            //this._position = position;
            this.Position = new Position(x: positionX, y: positionY);
            this.Color = ConsoleColor.Green;
            this.HP = 25;
            this.Type = "snake";
            this.AttackDice = new Dice(numberOfDice: 3, sidesPerDice: 4, modifier: 2);
            this.DefenceDice = new Dice(numberOfDice: 1, sidesPerDice: 8, modifier: 5);
        }

        public override void Draw()
        {
            (int left, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(
                this.Position.X + GeneralDungeonFunctions.mapDisplacementX, 
                this.Position.Y + GeneralDungeonFunctions.mapDisplacementY
            );
            Console.ForegroundColor = this.Color;
            Console.Write(GeneralDungeonFunctions.snakeChar.ToString());

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left, top);
        }

        //public bool Move(string direction, List<LevelElement> elements)
            //bool snakeMoved = false;
            //Position adjacentPosition = GeneralDungeonFunctions.GetAdjacentPosition(this.Position, direction);
        public void Move(Hero hero, List<LevelElement> elements)
        {
            bool snakeIsNextToHero = false;
            string herosRelativePosition = "";
            string[] relativePositions = new string[]
            {
                "above",
                "below",
                "left",
                "right"
            };
            Position adjacentPosition;
            foreach(string relativePosition in relativePositions)
            {
                adjacentPosition = GeneralDungeonFunctions.GetAdjacentPosition(this.Position, relativePosition);
                if(adjacentPosition.X == hero.Position.X && adjacentPosition.Y == hero.Position.Y)
                {
                    snakeIsNextToHero = true;
                    herosRelativePosition = relativePosition;
                }
            }

            adjacentPosition = GeneralDungeonFunctions.GetAdjacentPosition(
                    this.Position,
                    this.ReverseRelativePosition(herosRelativePosition)
                );
            bool possibleToFlee = GeneralDungeonFunctions.isPositionEmpty(
                adjacentPosition,
                elements
            );
            if (possibleToFlee)
            {
                GeneralDungeonFunctions.Erase(this.Position.X, this.Position.Y);
                this.Position = adjacentPosition;
                this.Draw();
            }
            //return snakeMoved;
        }

        private string ReverseRelativePosition(string relativePosition)
        {
            switch (relativePosition)
            {
                case "above":
                    return "below";
                    break;
                case "below":
                    return "above";
                    break;
                case "left":
                    return "right";
                    break;
                case "right":
                    return "left";
                    break;
                default: 
                    return "";
                    break;
            }
        }
    }
}
