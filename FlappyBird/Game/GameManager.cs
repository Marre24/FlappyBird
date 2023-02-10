using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    public class GameManager
    {
        private readonly FlappyBirdGame game;

        public GameManager(FlappyBirdGame game)
        {
            this.game = game;
        }

        public void StartGame()
        {
            game.bird.YCord = (game.GraphicsDevice.DisplayMode.Height / 2) - 100 / 2;

            game.pipeManager.Restart();

            game.bird.activeState = BirdState.Flying;
        }

    }
}
