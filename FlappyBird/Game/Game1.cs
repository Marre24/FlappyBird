using Cocos2D;
using CocosDenshion;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace FlappyBird
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Bird bird;
        public PipeManager pipeManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }   

        protected override void Initialize()
        {
            base.Initialize();
            bird = new Bird(this);
            pipeManager = new PipeManager(this);
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            IsMouseVisible = true;
            graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            switch (bird.activeState)
            {
                case BirdState.WaitingForStart:
                    break;
                case BirdState.Flying:
                    bird.Update(gameTime);
                    pipeManager.Update(gameTime);
                    break;
                case BirdState.Dead:
                    MessageBox.Show("död");
                    break;
                default:
                    break;
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            pipeManager.Draw(spriteBatch);

            bird.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
