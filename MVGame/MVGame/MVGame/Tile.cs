using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MVGame
{
    class Tile
    {
        public const int Width = 32;
        public const int Height = 32;

        public static readonly Vector2 Size = new Vector2(Width, Height);

        public Texture2D Texture { get; set; }
        public Vector2 Pos { get; set; }
        public bool Passable;
        public int TexNum { get; set; }

        private Color TileColour = Color.White;

        public Tile(Texture2D Texture, Vector2 Pos, int TexNum, bool Passable)
        {
            this.Texture = Texture;
            this.Pos = Pos;
            this.TexNum = TexNum;
            this.Passable = Passable;
        }
    }
}
