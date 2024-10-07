
// Om jag inte hade klickat i "Do not use top level statement" när jag skapade detta projekt, så hade jag inte behövt skriva namespace runt varje klass.
namespace Labb_02_dungeon_crawler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Enemy le = new Enemy();
            //Dice dice = new Dice();
            Console.WriteLine("Player: Luwi");
            Console.WriteLine("Enemy: ????");

            LevelData levelData = new LevelData();
            levelData.Load("C:\\Users\\ludwi\\source\\repos\\Labb_02_dungeon_crawler\\LevelElement\\bin\\Debug\\net8.0\\Level1.txt");

            //Dice myTestDice = new Dice(numberOfDice: 1, sidesPerDice: 3, modifier: 10);
            //for(int i = 0; i < 30; i++)
            //{

            //    Console.WriteLine(myTestDice.Throw());
            //}

            //int test = 0;
            //foreach( var element in levelData.Elements)
            //{
            //    Console.WriteLine(test++);
            //    Console.WriteLine($"element.Position = {element.Position[0]}, {element.Position[1]}");
            //}

            int test = 0;
            while (true)
            {
                //Console.WriteLine(test++);
                //levelData.hero.Erase();
                levelData.hero.Update(levelData.Elements);
                //Console.WriteLine($"hero_x = {levelData.hero.Position[0]}, hero_y = {levelData.hero.Position[1]}");
                levelData.hero.Draw();
            }
        }
    }
}