using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    public class PipeManager
    {
        public List<PipePair> Pipes { get => activePipes; }

        private readonly List<PipePair> activePipes = new List<PipePair>();
        private readonly Game1 game1;
        private float pipeSpawningSpeed = 6f;
        private double timeSinceUpdate = -12;

        public PipeManager(Game1 game1)
        {
            this.game1 = game1;
        }

        public void AddPipe(PipePair pipe) { activePipes.Add(pipe); }

        public void Update(GameTime gameTime)
        {
            foreach (PipePair pipe in activePipes)
                if (!pipe.IsOutSideOfScreen())
                    pipe.Update(gameTime);

            if (gameTime.TotalGameTime.TotalSeconds >= pipeSpawningSpeed + timeSinceUpdate)
            {
                timeSinceUpdate = gameTime.TotalGameTime.TotalSeconds;

                if (pipeSpawningSpeed >= 0.5f)
                    pipeSpawningSpeed -= 0.4f;

                AddPipe(new PipePair(game1));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (PipePair pipe in activePipes)
                if (!pipe.IsOutSideOfScreen())
                    pipe.Draw(spriteBatch);
        }
    }
}
