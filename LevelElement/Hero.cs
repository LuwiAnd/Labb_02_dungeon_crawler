using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_02_dungeon_crawler
{
    internal class Hero : LevelElement
    {
        private int[] _position;

        public override int[] Position
        {
            get { return this._position; }
            // positionen får endast sättas av konstruktorn, eller av Update-funktionen.
        }
        public string Type { get; set; }
        public double HP { get; set; }

        Dice AttackDice = new Dice(numberOfDice: 2, sidesPerDice: 6, modifier: 2);
        Dice DefenceDice = new Dice(numberOfDice: 2, sidesPerDice: 6, modifier: 0);

        public void Update()
        {
            Console.WriteLine("Uppdaterar spelaren");
        }

        public Hero(int[] position)
        {
            this._position = position;
            this.HP = 100;
            this.Type = "hero";

            this.Color = ConsoleColor.Green;
            this.Appearance = GeneralDungeonFunctions.playerChar;
        }

        public override void Draw()
        {
            (int left, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(this._position[0] + GeneralDungeonFunctions.mapDisplacementX, this._position[1] + GeneralDungeonFunctions.mapDisplacementY);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Appearance.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left, top);

        }

        public void Update(List<LevelElement> elements)
        {
            //bool heroHasSpaceAbove = true;
            //bool heroHasSpaceBelow = true;
            //bool heroHasSpaceOnLeftSide = true;
            //bool heroHasSpaceOnRightSide = true;

            //bool heroHasEnemyAbove = true;
            //bool heroHasEnemyBelow = true;
            //bool heroHasEnemyOnLeftSide = true;
            //bool heroHasEnemyOnRightSide = true;

            //foreach (var element in elements)
            //{
            //    if (element.type == "wall")
            //    {
            //        if (this.Position[0] == element.Position[0] && this.Position[1] == (element.Position[1] - 1))
            //        {
            //            heroHasSpaceAbove = false;
            //        }

            //        if (this.Position[0] == element.Position[0] && this.Position[1] == (element.Position[1] + 1))
            //        {
            //            heroHasSpaceBelow = false;
            //        }

            //        if (this.Position[0] == (element.Position[0] - 1) && this.Position[1] == element.Position[1])
            //        {
            //            heroHasSpaceOnLeftSide = false;
            //        }

            //        if (this.Position[0] == (element.Position[0] + 1) && this.Position[1] == element.Position[1])
            //        {
            //            heroHasSpaceOnRightSide = false;
            //        }
            //    }else if(element.type == "rat" || element.type == "snake")
            //    {
            //        if (this.Position[0] == element.Position[0] && this.Position[1] == (element.Position[1] - 1))
            //        {
            //            heroHasEnemyAbove = false;
            //        }

            //        if (this.Position[0] == element.Position[0] && this.Position[1] == (element.Position[1] + 1))
            //        {
            //            heroHasEnemyBelow = false;
            //        }

            //        if (this.Position[0] == (element.Position[0] - 1) && this.Position[1] == element.Position[1])
            //        {
            //            heroHasEnemyOnLeftSide = false;
            //        }

            //        if (this.Position[0] == (element.Position[0] + 1) && this.Position[1] == element.Position[1])
            //        {
            //            heroHasEnemyOnRightSide = false;
            //        }
            //    }
            //}

            //Console.WriteLine("AAAAA");
            ConsoleKeyInfo cki;
            int intervalTime = 50;
            bool okDirection = false;
            //while (!okDirection && currentWaitTime <= maxWaitTime)
            while (!okDirection)
            {
                //Console.WriteLine("BBBBBB");
                //while (Console.KeyAvailable == false && currentWaitTime <= maxWaitTime)
                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(intervalTime);
                    //currentWaitTime += intervalTime;
                }

                //Console.WriteLine("CCCCC");
                if (Console.KeyAvailable)
                {
                    //Console.WriteLine("DDDDD");
                    cki = Console.ReadKey();
                    //Console.WriteLine("You pressed the '{0}' key", cki.Key);

                    if (cki.Key == ConsoleKey.UpArrow)
                    {
                        okDirection = true;
                        //bool heroHasElementAbove = false;
                        foreach (var element in elements)
                        {
                            if (element.Position[0] == this.Position[0] && element.Position[1] == (this.Position[1] - 1))
                            {
                                //heroHasElementAbove = true;
                                if (element.type != "wall")
                                {
                                    okDirection = true;
                                    // Attack the enemy.
                                    // Enemy attacks back.
                                }
                                else
                                {
                                    okDirection = false;
                                }
                            }

                        }
                        if (okDirection)
                        {
                            this.Position[1]--;
                        }
                    }

                    if (cki.Key == ConsoleKey.LeftArrow)
                    {
                        okDirection = true;
                        //bool heroHasElementAbove = false;
                        foreach (var element in elements)
                        {
                            if (element.Position[0] == (this.Position[0] - 1) && element.Position[1] == this.Position[1])
                            {
                                //heroHasElementAbove = true;
                                if (element.type != "wall")
                                {
                                    okDirection = true;
                                    // Attack the enemy.
                                    // Enemy attacks back.
                                }
                                else
                                {
                                    okDirection = false;
                                }
                            }

                        }
                        if (okDirection)
                        {
                            this.Position[0]--;
                        }
                    }
                    if (cki.Key == ConsoleKey.DownArrow)
                    {
                        okDirection = true;
                        //bool heroHasElementAbove = false;
                        foreach (var element in elements)
                        {
                            if (element.Position[0] == this.Position[0] && element.Position[1] == (this.Position[1] + 1))
                            {
                                //heroHasElementAbove = true;
                                if (element.type != "wall")
                                {
                                    okDirection = true;
                                    // Attack the enemy.
                                    // Enemy attacks back.
                                }
                                else
                                {
                                    okDirection = false;
                                }
                            }

                        }
                        if (okDirection)
                        {
                            this.Position[1]++;
                        }
                    }
                    if (cki.Key == ConsoleKey.RightArrow)
                    {
                        okDirection = true;
                        //bool heroHasElementAbove = false;
                        //int debugIndex = 0;
                        foreach (var element in elements)
                        {
                            //debugIndex++;
                            //Console.WriteLine(debugIndex);
                            //Console.WriteLine($"Length of elements: {elements.Count}");
                            //Console.WriteLine(element);
                            //Console.WriteLine(element.Color);
                            //Console.WriteLine($"Hero position: x = {this.Position[0]}, y = {this.Position[1]}");
                            //Console.WriteLine(element.Position[0]);
                            //Console.WriteLine(element.Position[1]);
                            
                            if (element.Position[0] == (this.Position[0] + 1) && element.Position[1] == this.Position[1])
                            {
                                //heroHasElementAbove = true;
                                if (element.type != "wall")
                                {
                                    okDirection = true;
                                    // Attack the enemy.
                                    // Enemy attacks back.
                                }
                                else
                                {
                                    okDirection = false;
                                }
                            }

                        }
                        if (okDirection)
                        {
                            this.Position[0]++;
                        }
                    }
                }
                //else if (currentWaitTime > maxWaitTime)
                //{
                //    break;
                //}

                //if (
                //    newDirection == "up" && currentDirection != "down"
                //    ||
                //    newDirection == "down" && currentDirection != "up"
                //    ||
                //    newDirection == "left" && currentDirection != "right"
                //    ||
                //    newDirection == "right" && currentDirection != "left"
                //)
                //{
                //    okDirection = true;
                //}
                //else
                //{
                //    newDirection = "";
                //}
            }
        }
    }
}
