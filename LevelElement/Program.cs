﻿
// Om jag inte hade klickat i "Do not use top level statement" när jag skapade detta projekt, så hade jag inte behövt skriva namespace runt varje klass.
namespace Labb_02_dungeon_crawler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Player: Luwi");
            Console.WriteLine("Enemy: ????");

            LevelData levelData = new LevelData();
            levelData.Load("C:\\Users\\ludwi\\source\\repos\\Labb_02_dungeon_crawler\\LevelElement\\bin\\Debug\\net8.0\\Level1.txt");
            levelData.TurnsUntilClearingMessages = 3;

            bool gameOver = false;
            while (!gameOver)
            {
                if (levelData.TurnsUntilClearingMessages > 0) levelData.TurnsUntilClearingMessages--;
                else GeneralDungeonFunctions.ClearConsoleMessages();

                //levelData.hero.Update(levelData.Elements);
                levelData.hero.Update(levelData);
                if (CheckIsHeroDead(levelData.hero)) break;

                levelData.UpdateWalls();
                levelData.UpdateSnakes();
                if (CheckIsHeroDead(levelData.hero)) break;
                levelData.UpdateRats();
                if (CheckIsHeroDead(levelData.hero)) break;

                levelData.hero.Draw();
                levelData.EraseDeadElements();
                levelData.RemoveElements();
            }
        }

        private static bool CheckIsHeroDead(Hero hero)
        {
            if (hero.HP <= 0)
            {
                Console.SetCursorPosition(10, 22);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You died! Game over!");
                Console.ForegroundColor = ConsoleColor.White;
                //break;
                return true;
            }
            return false;
        }
    }
}