using System;

namespace FlappyBird
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var game = new FlappyBirdGame();
            game.Run();
        }
    }
}
