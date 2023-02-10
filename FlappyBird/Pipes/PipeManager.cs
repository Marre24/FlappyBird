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
        private readonly FlappyBirdGame game;
        private float pipeSpawningSpeed = 5.0f;
        private double timeSinceUpdate = -12;
        private const int speedUpPipe = 2;
        private readonly SpriteFont markerFelt;

        public PipeManager(FlappyBirdGame game)
        {
            this.game = game;

            markerFelt = game.Content.Load<SpriteFont>("Fonts/MarkerFelt-22");
        }

        public void Restart()
        {
            activePipes.Clear();
            pipeSpawningSpeed = 6f;
            timeSinceUpdate = -12;
        }


        public void AddPipe(PipePair pipe) { activePipes.Add(pipe); }

        private int i = 0;

        public void Update(GameTime gameTime)
        {
            foreach (PipePair pipe in activePipes)
                if (!pipe.IsOutSideOfScreen())
                    pipe.Update(gameTime);

            if (gameTime.TotalGameTime.TotalSeconds >= pipeSpawningSpeed + timeSinceUpdate)
            {
                timeSinceUpdate = gameTime.TotalGameTime.TotalSeconds;
                if (speedUpPipe <= i && pipeSpawningSpeed >= 1.4f)
                {
                    pipeSpawningSpeed -= 0.2f;
                    i = 0;
                }
                else
                    i++;

                AddPipe(new PipePair(game));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(markerFelt, pipeSpawningSpeed.ToString(), Vector2.Zero, Color.White);

            foreach (PipePair pipe in activePipes)
                if (!pipe.IsOutSideOfScreen())
                    pipe.Draw(spriteBatch);
        }
    }
}
