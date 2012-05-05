using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MVGame
{
    class Player
    {
        private Texture2D Texture;
        private Vector2 Position;
        private Vector2 Velocity;

        // Corners for collision detection
        private float upY;
        private float downY;
        private float leftX;
        private float rightX;

        private bool upLeft;
        private bool upRight;
        private bool downLeft;
        private bool downRight;

        public Player(Texture2D Texture)
        {
            this.Texture = Texture;

            Position = new Vector2(100, 100);
        }

        public void Update()
        {

        }

        private void GetCorners(Vector2 Pos)
        {
            upY = (Pos.Y - (Texture.Height / 2) / Tile.Size.Y);
            downY = (Pos.Y + (Texture.Height / 2) / Tile.Size.Y);
            leftX = (Pos.X - (Texture.Width / 2) / Tile.Size.X);
            rightX = (Pos.X + (Texture.Width / 2) / Tile.Size.X);
        }

        public void Draw(SpriteBatch sBatch)
        {
            sBatch.Draw(Texture, Position, Color.White);
        }
    }
}
