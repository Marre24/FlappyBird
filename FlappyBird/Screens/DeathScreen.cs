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
        private const string deathMessage = "Du dog :(";
        private bool buttonIsUp;
        private Texture2D buttonUpTexture;
        private Texture2D buttonDownTexture;
        private Rectangle buttonHitBox;

        public DeathScreen(Game1 game)
        {
            buttonDownTexture = game.Content.Load<Texture2D>("Pics/SpacePressed");
            buttonUpTexture = game.Content.Load<Texture2D>("Pics/Space");

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (buttonIsUp)
                spriteBatch.Draw(buttonUpTexture, buttonHitBox, Color.White);
            else
                spriteBatch.Draw(buttonDownTexture, buttonHitBox, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();

            if (!buttonHitBox.Contains(mouseState.Position))
            {
                buttonIsUp = true;
                buttonHitBox = new Rectangle();
                return;
            }
            buttonIsUp = false;
            buttonHitBox = new Rectangle();
            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {



            }
        }
    }
}
