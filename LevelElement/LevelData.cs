﻿
// Om jag inte hade klickat i "Do not use top level statement" när jag skapade detta projekt, så hade jag inte behövt skriva namespace runt varje klass.
using System.Runtime.InteropServices;

namespace Labb_02_dungeon_crawler
{

    class LevelData
    {
        //private List<LevelElement> elements;
        private List<LevelElement> _elements = new List<LevelElement>();

        public List<LevelElement> Elements{
            get { return this._elements; }
            //set; // Denna property ska vara readonly.
        }

        public Hero hero;

        public int TurnsUntilClearingMessages { get; set; }

        public void Load(string fileName)
        {
            try
            {
                using(StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    //int x = 0;
                    int y = 0;
                    int[] currentPosition;
                    //LevelElement le;
                    while((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        for(int x = 0; x < line.Length; x++)
                        {
                            //currentPosition = new int[] { x, y };
                            if (line[x] == GeneralDungeonFunctions.wallChar)
                            {
                                //le = new Wall({ x, y });
                                //this._elements.Add(new Wall(new int[]{ x, y }));
                                //this._elements.Add(new Wall(currentPosition));
                                this._elements.Add(new Wall(x, y));
                                //Console.WriteLine($"A new wall was added");
                            }
                            if (line[x] == GeneralDungeonFunctions.ratChar)
                            {
                                //this._elements.Add(new Rat(new int[] { x, y }));
                                this._elements.Add(new Rat(x, y));
                                //Console.WriteLine($"A new rat was added at position x = {x}, y = {y}.");
                            }
                            if (line[x] == GeneralDungeonFunctions.snakeChar)
                            {
                                //this._elements.Add(new Snake(new int[] { x, y }));
                                this._elements.Add(new Snake(x, y));
                                //Console.WriteLine($"A new snake was added at position x = {x}, y = {y}.");
                            }
                            if (line[x] == GeneralDungeonFunctions.playerChar)
                            {
                                //this.hero = new Hero(new int[] { x, y });
                                this.hero = new Hero(x, y);
                                
                                //Console.WriteLine($"A new hero was added at position x = {x}, y = {y}.");
                            }
                        }
                        y++;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            this.hero.Draw();
        }

        public void RemoveElements()
        {
            //foreach(var element in this.Elements)
            foreach(var element in this.Elements.ToList())
            {
                if(element.Type == "rat" || element.Type == "snake")
                {
                    Enemy enemy = (Enemy)element;
                    if(enemy.HP <= 0) { this.Elements.Remove(element); }
                }
            }
        }

        public void UpdateWalls()
        {
            foreach (LevelElement element in this.Elements)
            {
                if (element.Type == "wall")
                {
                    //Console.WriteLine("Moving a snake!");
                    Wall wall = (Wall)element;
                    wall.Update(this.hero);
                }
            }
        }

        public void UpdateSnakes()
        {
            foreach(LevelElement element in this.Elements)
            {
                if(element.Type == "snake")
                {
                    Snake snake = (Snake)element;
                    //snake.Update(this.hero, this.Elements);
                    snake.Update(this.hero, this);
                }
            }
        }

        public void UpdateRats()
        {
            foreach (LevelElement element in this.Elements)
            {
                if (element.Type == "rat")
                {
                    Rat rat = (Rat)element;
                    //rat.Update(this.hero, this.Elements);
                    rat.Update(this.hero, this);
                }
            }
        }

        public void EraseDeadElements()
        {
            foreach(var element in this.Elements)
            {
                if(element is Enemy enemy && enemy.HP <= 0)
                {
                    GeneralDungeonFunctions.Erase(enemy.Position.X, enemy.Position.Y);
                }
            }
        }
    }
}