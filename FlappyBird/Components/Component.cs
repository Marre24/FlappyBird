using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    public class Component
    {
        protected readonly FlappyBirdGame game;
        public Component(FlappyBirdGame game)
        {
            this.game = game;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
        
    }
}
