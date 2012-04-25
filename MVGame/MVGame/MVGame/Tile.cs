using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MVGame
{
    class Tile
    {
        public const int Width = 32;
        public const int Height = 32;

        public Texture2D Texture { get; set; }
        public Vector2 Pos { get; set; }
        public Rectangle TileRect { get; set; }
        public int TexNum { get; set; }

        private Color TileColour = Color.White;

        public Tile(Texture2D Texture, Vector2 Pos, int TexNum)
        {
            this.Texture = Texture;
            this.Pos = Pos;
            this.TexNum = TexNum;

            TileRect = new Rectangle((int)Pos.X, (int)Pos.Y, Texture.Width, Texture.Height);
        }
    }
}
