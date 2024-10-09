﻿using System;
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
            this.Color = ConsoleColor.Red;
            this.HP = 10;
            this.Type = "rat";
            this.AttackDice = new Dice(numberOfDice: 1, sidesPerDice: 6, modifier: 3);
            this.DefenceDice = new Dice(numberOfDice: 1, sidesPerDice: 6, modifier: 1);

        }

        public override void Draw()
        {
            (int left, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(
                this.Position.X + GeneralDungeonFunctions.mapDisplacementX,
                this.Position.Y + GeneralDungeonFunctions.mapDisplacementY
            );
            Console.ForegroundColor = this.Color;
            Console.Write(GeneralDungeonFunctions.ratChar.ToString());

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left, top);
        }

        public void Move(Hero hero, List<LevelElement> elements)
        {
            //string[] directions = new string[]
            //{
            //    "up",
            //    "down",
            //    "left",
            //    "right"
            //};
            //Random random = new Random();
            //string direction = directions[random.Next(directions.Length)];

            string[] relativePositions = new string[]
            {
                "above",
                "below",
                "left",
                "right"
            };
            Random random = new Random();
            string nextRelativePosition = relativePositions[random.Next(relativePositions.Length)];

            Position adjacentPosition;
            adjacentPosition = GeneralDungeonFunctions.GetAdjacentPosition(this.Position, nextRelativePosition);
            if (adjacentPosition.X == hero.Position.X && adjacentPosition.Y == hero.Position.Y)
            {
                this.AttackHero(hero);
                return;
            }

            
            bool possibleToMove = GeneralDungeonFunctions.isPositionEmpty(
                adjacentPosition,
                elements
            );
            if (possibleToMove)
            {
                GeneralDungeonFunctions.Erase(this.Position.X, this.Position.Y);
                this.Position = adjacentPosition;
                this.Draw();
            }
        }
    }
}
