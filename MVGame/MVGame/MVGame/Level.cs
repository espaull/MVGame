using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MVGame
{
    class Level
    {
        public static Tile[,] Tiles { get; set; }
        public static int[,] TheLevel { get; set; }
        private ContentManager Content;
        private int Width;
        private int Height;
        private int LevelNum = 1;
        private MouseState mouse;
        private KeyboardState prevKeyboard;
        private KeyboardState keyboard;
        private int TileIndex = 2;
        //private int LevelNumber = 1;
        //private string fileName;
        private FileHumper Humper;

        public Level(ContentManager Content, int width, int height)
        {
            this.Content = Content;
            Width = width / Tile.Width;
            Height = height / Tile.Height;

            Tiles = new Tile[Width, Height];
            TheLevel = new int[Width, Height];
            Humper = new FileHumper(Width, Height);
        }
        
        public void Update()
        {
            mouse = Mouse.GetState();
            keyboard = Keyboard.GetState();

            handleMouse(mouse);
            handleKeys(keyboard);
        }

        public void Draw(SpriteBatch sBatch)
        {
            sBatch.Begin();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Tiles[x, y] != null)
                    {
                        sBatch.Draw(Tiles[x, y].Texture, Tiles[x, y].Pos, Color.White);
                    }
                }
            }

            sBatch.End();
        }

        private Tile LoadTile(Vector2 pos)
        {
            return new Tile(Content.Load<Texture2D>("tiles/tile" + TileIndex), pos, TileIndex);
        }

        private void handleMouse(MouseState mouse)
        {
            int mPosX = mouse.X / Tile.Width;
            int mPosY = mouse.Y / Tile.Height;

            if (mPosX >= 40 || mPosX < 0 || mPosY >= 23 || mPosY < 0)
            {
                return; // Do nothing.
            }
            else
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    if (Tiles[mPosX, mPosY] == null)
                    {
                        Tiles[mPosX, mPosY] = LoadTile(new Vector2(mPosX * Tile.Width, mPosY * Tile.Height));
                    }
                    else if (Tiles[mPosX, mPosY].TexNum != TileIndex)
                    {
                        Tiles[mPosX, mPosY] = null; // Not sure if loading the same tile in the same place over and over will eat up memory so I'll make it null before applying the new tile texture.
                        Tiles[mPosX, mPosY] = LoadTile(new Vector2(mPosX * Tile.Width, mPosY * Tile.Height));
                    }
                }

                if (mouse.RightButton == ButtonState.Pressed)
                {
                    if (Tiles[mPosX, mPosY] != null)
                    {
                        Tiles[mPosX, mPosY] = null;
                    }
                }
            }
        }

        private void handleKeys(KeyboardState keyboard)
        {

            if (keyboard.IsKeyDown(Keys.F5) && !prevKeyboard.IsKeyDown(Keys.F5)) {
                Humper.saveGame();
            } 
            else if (keyboard.IsKeyDown(Keys.L) && !prevKeyboard.IsKeyDown(Keys.L))
            {
                loadLevel(Humper.loadGame());
            }

            if (keyboard.IsKeyDown(Keys.D1) && !prevKeyboard.IsKeyDown(Keys.D1))
            {
                TileIndex = 1;
            }

            if (keyboard.IsKeyDown(Keys.D2) && !prevKeyboard.IsKeyDown(Keys.D2))
            {
                TileIndex = 2;
            }

            if (keyboard.IsKeyDown(Keys.D3) && !prevKeyboard.IsKeyDown(Keys.D3))
            {
                TileIndex = 3;
            }

            if (keyboard.IsKeyDown(Keys.D4) && !prevKeyboard.IsKeyDown(Keys.D4))
            {
                TileIndex = 4;
            }

            if (keyboard.IsKeyDown(Keys.D5) && !prevKeyboard.IsKeyDown(Keys.D5))
            {
                TileIndex = 5;
            }

            if (keyboard.IsKeyDown(Keys.D6) && !prevKeyboard.IsKeyDown(Keys.D6))
            {
                TileIndex = 6;
            }

            if (keyboard.IsKeyDown(Keys.X) && !prevKeyboard.IsKeyDown(Keys.X))
            {
                clearLevel();
            }

            prevKeyboard = keyboard;
        }

        private void loadLevel(int[,] level)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    TileIndex = level[x, y];
                    Tiles[x, y] = null;
                    Tiles[x, y] = LoadTile(new Vector2(x * Tile.Width, y * Tile.Height));
                }
            }
        }

        private void clearLevel()
        {
            for (int x = 0; x < Width; ++x)
            {
                for (int y = 0; y < Height; ++y)
                {
                    Tiles[x, y] = null;
                }
            }
        }
    }
}