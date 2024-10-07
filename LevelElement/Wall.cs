
// Om jag inte hade klickat i "Do not use top level statement" när jag skapade detta projekt, så hade jag inte behövt skriva namespace runt varje klass.
namespace Labb_02_dungeon_crawler
{
    class Wall : LevelElement
    {
        public new string type = "wall";
        private bool isVisible = false;

        // Utan override, så skapas det en extra Position-property här, så att det 
        // hade funnits en Position i föräldraklassen och en i denna klass.
        public override int[] Position { 
            get; 
            // set; 
        }
        public char Appearance { 
            get; 
            set; 
        }
        public ConsoleColor Color { get; set; }

        public override void Draw()
        {
            (int left, int top) = Console.GetCursorPosition();
            //Console.SetCursorPosition(this.Position[0], this.Position[1]);
            Console.SetCursorPosition(this.Position[0] + GeneralDungeonFunctions.mapDisplacementX, this.Position[1] + GeneralDungeonFunctions.mapDisplacementY);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Appearance.ToString());

            // Resetting color and cursor, for debugging output to be shown under the dungeon.
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left, top);
        }

        public Wall(int[] position)
        {
            Appearance = '#';
            this.Color = ConsoleColor.White;
            this.Position = position;

            //Console.WriteLine($"Wall input x = {position[0]}, y = {position[1]}");
            //Console.WriteLine($"Wall output x = {this.Position[0]}, y = {this.Position[1]}");
        }

        
    }
}
