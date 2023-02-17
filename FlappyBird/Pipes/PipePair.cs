using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace FlappyBird
{
    public class PipePair : Component
    {
        private readonly Bottle bottle;

        private readonly Vector2 overpipeLocation;
        private const int headWidth = 32;
        private const int pipeWidth = 28;
        private readonly int overpipeHeight;
        private const int distanceBetweenPipes = 285;
        private const int scale = 4;

        private readonly Texture2D overpipeHeadTexture;     // 32 x 15
        private readonly Texture2D underpipeHeadTexture;    // 32 x 15
        private readonly Texture2D pipeShaft;               // 28 x 4
        private const int pipeSpeed = 6;

        private Rectangle overpipeShaft;
        private Rectangle overpipeHead;
        private Rectangle underpipeShaft;
        private Rectangle underpipeHead;
        readonly Random random = new Random();

        public Bottle Bottle { get => bottle; }

        public PipePair(FlappyBirdGame game) : base(game)
        {
            overpipeHeadTexture = game.Content.Load<Texture2D>("Pics/OverPipeHead");
            underpipeHeadTexture = game.Content.Load<Texture2D>("Pics/UnderPipeHead");
            pipeShaft = game.Content.Load<Texture2D>("Pics/PipeShaft");

            overpipeHeight = random.Next(15 * scale, game.GraphicsDevice.DisplayMode.Height - distanceBetweenPipes - 100);
            overpipeLocation = new Vector2(game.GraphicsDevice.DisplayMode.Width, 0);

            overpipeHead = new Rectangle((int)overpipeLocation.X, overpipeHeight - 15 * scale, headWidth * scale, 15 * scale);
            overpipeShaft = new Rectangle((int)overpipeLocation.X + 2 * scale, 0, pipeWidth * scale, overpipeHeight - 15 * scale);

            underpipeHead = new Rectangle((int)overpipeLocation.X, overpipeHead.Bottom + distanceBetweenPipes, headWidth * scale, 15 * scale);
            underpipeShaft = new Rectangle((int)overpipeLocation.X + 2 * scale, overpipeHeight + distanceBetweenPipes + 15 * scale,
                pipeWidth * scale, game.GraphicsDevice.DisplayMode.Height - (overpipeHeight + distanceBetweenPipes + 15 * scale));

            bottle = new Bottle(game, overpipeHead.Location + new Point(underpipeHead.Width / 2, 150));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!bottle.collected)
                bottle.Draw(spriteBatch);

            spriteBatch.Draw(overpipeHeadTexture, overpipeHead, Color.White);
            spriteBatch.Draw(pipeShaft, overpipeShaft, Color.White);
            spriteBatch.Draw(underpipeHeadTexture, underpipeHead, Color.White);
            spriteBatch.Draw(pipeShaft, underpipeShaft, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (!bottle.collected)
                bottle.UpdatePosition(pipeSpeed);

            overpipeShaft.Location -= new Point(pipeSpeed, 0);
            overpipeHead.Location -= new Point(pipeSpeed, 0);
            underpipeHead.Location -= new Point(pipeSpeed, 0);
            underpipeShaft.Location -= new Point(pipeSpeed, 0);
        }

        public bool IsOutSideOfScreen()
        {
            if (overpipeLocation.X + headWidth + 50 <= 0)
                return true;
            return false;
        }

        public bool IsInsidePipe(Rectangle playerHitbox)
        {
            return playerHitbox.Intersects(overpipeHead) || playerHitbox.Intersects(overpipeShaft) || 
                playerHitbox.Intersects(underpipeHead) || playerHitbox.Intersects(underpipeShaft);
        }
    }
}
