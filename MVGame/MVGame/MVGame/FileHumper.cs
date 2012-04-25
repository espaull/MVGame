using System.IO;
using Microsoft.Xna.Framework;

namespace MVGame
{
    class FileHumper
    {
        private int Width;
        private int Height;
        private string fileName;
        private int LevelNumber = 1;
        private Tile[,] Tiles;
        private int[,] TheLevel;

        public FileHumper(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
         
        public void saveGame()
        {
            fileName = "Level" + LevelNumber.ToString() + ".txt";

            if (File.Exists(fileName))
            {
                ++LevelNumber;
                saveGame();
            }
            else
            {
                StreamWriter sw = new StreamWriter(fileName);
                Tiles = Level.Tiles;

                for (int x = 0; x < Width; x++) // Loop through the Tiles array
                {
                    for (int y = 0; y < Height; y++)
                    {
                        if (Tiles[x, y] == null)
                        {
                            sw.WriteLine("0");
                        }
                        else
                        {
                            sw.WriteLine(Tiles[x, y].TexNum.ToString());
                        }
                    }
                }

                sw.Close();
                sw.Dispose();
            }
        }

        public int[,] loadGame()
        {
            fileName = "Level" + LevelNumber + ".txt";

            if (!File.Exists(fileName))
            {
                LevelNumber = 1;
            }

            fileName = "Level" + LevelNumber + ".txt"; // We need to set it again incase LevelNumber gets set to 1.
            StreamReader sr = new StreamReader(fileName);

            TheLevel = new int[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int.TryParse(sr.ReadLine(), out TheLevel[x, y]);
                }
            }

            sr.Close();

            ++LevelNumber;
            return TheLevel;
        }
    }
}
