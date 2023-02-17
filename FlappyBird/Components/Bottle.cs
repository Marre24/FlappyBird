using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    public class Bottle : Component
    {
        private readonly Texture2D bottleTexture;
        private readonly Point beerBotleSize = new Point(14, 41);
        private Point location;
        private const int scale = 4;
        public bool collected = false;

        public Bottle(FlappyBirdGame game, Point location) : base(game)
        {
            this.location = location - new Point(scale * beerBotleSize.X / 2);
            bottleTexture = game.Content.Load<Texture2D>("Pics/PawtucketAle");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bottleTexture, new Rectangle(location, new Point(beerBotleSize.X * scale, beerBotleSize.Y * scale)), Color.White);

        }

        public void UpdatePosition(int xIncrement)
        {
            location -= new Point(xIncrement, 0);
        }

        public void CheckCollision(Bird bird)
        {
            if (new Rectangle(location, new Point(beerBotleSize.X * scale, beerBotleSize.Y * scale)).Intersects(new Rectangle((int)bird.XCord, (int)bird.YCord, Bird.width, Bird.height)))
                collected = true;
            bird.DrinkBeer();
        }


    }
}
