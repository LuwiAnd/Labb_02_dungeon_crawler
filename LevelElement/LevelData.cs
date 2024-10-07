
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
                        Console.WriteLine(line);
                        for(int x = 0; x < line.Length; x++)
                        {
                            currentPosition = new int[] { x, y };
                            if (line[x] == GeneralDungeonFunctions.wallChar)
                            {
                                //le = new Wall({ x, y });
                                //this._elements.Add(new Wall(new int[]{ x, y }));
                                this._elements.Add(new Wall(currentPosition));
                                //Console.WriteLine($"A new wall was added");
                            }
                            if (line[x] == GeneralDungeonFunctions.ratChar)
                            {
                                this._elements.Add(new Rat(new int[] { x, y }));
                                //Console.WriteLine($"A new rat was added at position x = {x}, y = {y}.");
                            }
                            if (line[x] == GeneralDungeonFunctions.snakeChar)
                            {
                                this._elements.Add(new Snake(new int[] { x, y }));
                                //Console.WriteLine($"A new snake was added at position x = {x}, y = {y}.");
                            }
                            if (line[x] == GeneralDungeonFunctions.playerChar)
                            {
                                this.hero = new Hero(new int[] { x, y });
                                
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
    }
}