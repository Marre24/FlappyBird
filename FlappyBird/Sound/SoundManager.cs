using System;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    public class SoundManager
    {
        public SoundManager(FlappyBirdGame flappyBirdGame)
        {
            MediaPlayer.Play(flappyBirdGame.Content.Load<Song>("Sound/Surfin_Bird"));
        }
    }
}
