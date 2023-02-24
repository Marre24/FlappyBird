using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    class StartScreen : Screen
    {
        private const string startMessage = "Tryck Space för att starta";
        private readonly FlappyBirdGame game;
        private readonly SpriteFont markerFelt;

        public StartScreen(FlappyBirdGame game)
        {
            this.game = game;
            markerFelt = game.Content.Load<SpriteFont>("Fonts/MarkerFelt-22");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            game.bird.Draw(spriteBatch);
            spriteBatch.DrawString(markerFelt, startMessage, new Vector2(game.GraphicsDevice.DisplayMode.Width / 2, game.GraphicsDevice.DisplayMode.Height / 2) , Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                game.bird.activeState = BirdState.Flying;
                game.bird.Jump();
            }
        }
    }
}
