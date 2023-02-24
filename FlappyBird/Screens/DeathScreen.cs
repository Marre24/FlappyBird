using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    class DeathScreen : Screen
    {
        private const string deathMessage = "Du dog, du fick: ";
        private readonly Point spaceSize = new Point(96, 32);
        private const int scale = 4;
        private readonly Point location;

        private readonly FlappyBirdGame game;
        private bool buttonIsUp;

        private readonly Texture2D buttonUpTexture;
        private readonly Texture2D buttonDownTexture;
        private readonly SpriteFont MarkerFelt;
        private Rectangle buttonHitBox;

        public DeathScreen(FlappyBirdGame game)
        {
            buttonDownTexture = game.Content.Load<Texture2D>("Pics/SpacePressed");
            buttonUpTexture = game.Content.Load<Texture2D>("Pics/Space");
            MarkerFelt = game.Content.Load<SpriteFont>("Fonts/MarkerFelt-22");
            this.game = game;

            location = new Point(game.GraphicsDevice.DisplayMode.Width / 2 - (spaceSize.X * scale) / 2, game.GraphicsDevice.DisplayMode.Height / 2 - (spaceSize.Y * scale) / 2);

            buttonHitBox = new Rectangle(location, new Point(spaceSize.X * scale, spaceSize.Y * scale));

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(MarkerFelt, deathMessage + game.bird.Points + " poäng", new Vector2(game.GraphicsDevice.DisplayMode.Width / 2 - 200, game.GraphicsDevice.DisplayMode.Height / 2 - 200), Color.White);
            if (buttonIsUp)
                spriteBatch.Draw(buttonUpTexture, buttonHitBox, Color.White);
            else
                spriteBatch.Draw(buttonDownTexture, buttonHitBox, Color.White);
        }
        double time = 0;
        const double interval = 2;

        public override void Update(GameTime gameTime)
        {
            if (time + interval >= gameTime.TotalGameTime.TotalSeconds)
                return;
            time = gameTime.TotalGameTime.TotalSeconds;
            var mouseState = Mouse.GetState();

            if (!buttonHitBox.Contains(mouseState.Position))
                buttonIsUp = true;
            else
                buttonIsUp = false;

            if (((mouseState.LeftButton == ButtonState.Pressed && !buttonIsUp) || Keyboard.GetState().IsKeyDown(Keys.Space)) && game.bird.activeState == BirdState.Dead)
            {
                game.gameManager.StartGame();

            }
        }





    }
}
