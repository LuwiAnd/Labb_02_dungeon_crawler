
// Om jag inte hade klickat i "Do not use top level statement" när jag skapade detta projekt, så hade jag inte behövt skriva namespace runt varje klass.
namespace Labb_02_dungeon_crawler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Enemy le = new Enemy();
            Dice dice = new Dice();
            Console.WriteLine("hybris");
        }
    }
}