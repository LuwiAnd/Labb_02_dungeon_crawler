﻿
// Om jag inte hade klickat i "Do not use top level statement" när jag skapade detta projekt, så hade jag inte behövt skriva namespace runt varje klass.
namespace Labb_02_dungeon_crawler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Enemy le = new Enemy();
            //Dice dice = new Dice();
            Console.WriteLine("hybris");

            LevelData lv = new LevelData();
            lv.Load("C:\\Users\\ludwi\\source\\repos\\Labb_02_dungeon_crawler\\LevelElement\\bin\\Debug\\net8.0\\Level1.txt");

            Dice myTestDice = new Dice(numberOfDice: 1, sidesPerDice: 3, modifier: 10);
            for(int i = 0; i < 30; i++)
            {
                
                Console.WriteLine(myTestDice.Throw());
            }
        }
    }
}