
// Om jag inte hade klickat i "Do not use top level statement" när jag skapade detta projekt, så hade jag inte behövt skriva namespace runt varje klass.
namespace Labb_02_dungeon_crawler
{
    class Wall : LevelElement
    {
        private bool isVisible = false;
        public int[] Position { get; set; }
        public char Appearance { 
            get; 
            set; 
        }
        public ConsoleColor Color { get; set; }

        public override void Draw()
        {
            Console.SetCursorPosition(this.Position[0], this.Position[1]);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Appearance);
        }

        public Wall(int[] position)
        {
            Appearance = '#';
            this.Color = ConsoleColor.White;
            this.Position = position;
        }
    }
}
