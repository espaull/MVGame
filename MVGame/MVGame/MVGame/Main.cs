using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MVGame
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont Font;
        private KeyboardState prevKeyboard;
        private KeyboardState keyboard;
        private Level Level;
        private Vector2 Center;
        private Vector2 FontCenter;
        bool paused = false;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 736;
            graphics.ApplyChanges();

            IsMouseVisible = true;

            Level = new Level(this.Content, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Center = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            Components.Add(new FrameRateCounter(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Font = Content.Load<SpriteFont>("fonts/Font");
            FontCenter = Font.MeasureString("PAUSED") / 2;
            
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // If escape is pressed, exit game. Yay.
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (keyboard.IsKeyDown(Keys.P) && !prevKeyboard.IsKeyDown(Keys.P))
            {
                checkPause();
            }

            if (paused == false)
            {
                Level.Update();
            }

            prevKeyboard = keyboard;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Level.Draw(spriteBatch);

            spriteBatch.Begin();

            spriteBatch.DrawString(Font, "P = Pause", new Vector2(5, 30), Color.White);

            if (paused == true)
            {
                spriteBatch.DrawString(Font, "PAUSED", Center, Color.White, 0, FontCenter, 1, SpriteEffects.None, 0);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            paused = true;
        }

        private void checkPause()
        {
            if (paused == true)
            {
                paused = false;
            }
            else
            {
                paused = true;
            }
        }
    }
}
