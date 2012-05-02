using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MVGame
{
    class Player
    {
        private Texture2D Texture;
        private Vector2 Position;
        private Vector2 Velocity;

        public Player(Texture2D Texture)
        {
            this.Texture = Texture;

            Position = new Vector2(100, 100);
        }

        public void Draw(SpriteBatch sBatch)
        {
            sBatch.Begin();

            sBatch.Draw(Texture, Position, Color.White);

            sBatch.End();
        }
    }
}
