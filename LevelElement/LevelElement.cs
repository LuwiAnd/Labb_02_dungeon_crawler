
namespace Labb_02_dungeon_crawler
{
    public abstract class LevelElement
    {
        public int[] Position { get; set; }
        public char Appearance { get; set; }
        public ConsoleColor Color { get; set; }

        public abstract void Draw();

    }
}