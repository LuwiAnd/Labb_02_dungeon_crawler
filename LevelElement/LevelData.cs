
// Om jag inte hade klickat i "Do not use top level statement" när jag skapade detta projekt, så hade jag inte behövt skriva namespace runt varje klass.
using System.Runtime.InteropServices;

namespace Labb_02_dungeon_crawler
{

    class LevelData
    {
        //private List<LevelElement> elements;
        private List<LevelElement> elements = new List<LevelElement>();

        public List<LevelElement> Elements{
            get;
            //set; // Denna property ska vara readonly.
        }

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
                                this.elements.Add(new Wall(new int[]{ x, y }));
                                Console.WriteLine("A new wall was added");
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}