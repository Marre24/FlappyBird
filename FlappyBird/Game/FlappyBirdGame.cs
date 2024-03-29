﻿using Cocos2D;
using CocosDenshion;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace FlappyBird
{
    public class FlappyBirdGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public Bird bird;
        public PipeManager pipeManager;
        public GameManager gameManager;
        private DeathScreen deathScreen;
        private StartScreen startScreen;
        private FlyScreen flyScreen;
        public FlappyBirdGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }   

        protected override void Initialize()
        {
            base.Initialize();
            bird = new Bird(this);
            pipeManager = new PipeManager(this);
            gameManager = new GameManager(this);
            startScreen = new StartScreen(this);
            deathScreen = new DeathScreen(this);
            flyScreen = new FlyScreen();
            new SoundManager(this);
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
                    startScreen.Update(gameTime);
                    break;
                case BirdState.Flying:
                    flyScreen.Update(gameTime);
                    bird.Update(gameTime);
                    pipeManager.Update(gameTime);
                    break;
                case BirdState.Dead:
                    deathScreen.Update(gameTime);
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

            switch (bird.activeState)
            {
                case BirdState.WaitingForStart:
                    startScreen.Draw(spriteBatch);
                    break;
                case BirdState.Flying:
                    flyScreen.Draw(spriteBatch);
                    pipeManager.Draw(spriteBatch);
                    bird.Draw(spriteBatch);
                    break;
                case BirdState.Dead:
                    deathScreen.Draw(spriteBatch);
                    break;
                default:
                    break;
            }


            

            spriteBatch.End();
        }
    }
}
