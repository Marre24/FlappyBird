using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    public enum BirdState
    {
        WaitingForStart,
        Flying,
        Dead,
    }

    public class Bird : Component
    {
        public float XCord { get => location.X;}
        public float YCord { get => location.Y; set => location.Y = value; }

        private Vector2 location;
        private readonly Point size = new Point(width, height);
        public const int width = 150;
        public const int height = 100;

        private Texture2D activePeter;
        private readonly Texture2D peterNormal;
        private readonly Texture2D peterFlap;
        private readonly Texture2D peterDrink;

        private const float maxSpeed = 10f;
        private const float jumpForce = 17f;
        private float speed = 0;

        public BirdState activeState = BirdState.Flying;

        public Bird(FlappyBirdGame game) : base(game)
        {
            location.X = (game.GraphicsDevice.DisplayMode.Width / 4) - width / 2;
            YCord = (game.GraphicsDevice.DisplayMode.Height / 2) - height / 2;

            peterNormal = game.Content.Load<Texture2D>("Pics/PeterBirdNormal");
            peterFlap = game.Content.Load<Texture2D>("Pics/PeterFlap");
            peterDrink = game.Content.Load<Texture2D>("Pics/PeterEat");

            activePeter = peterNormal;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(activePeter, new Rectangle(location.ToPoint(), size), Color.White);
        }

        public void DrinkBeer()
        {
            isDrinking = true;
        }

        private bool spaceWasUp = false;
        private bool isDrinking = false;

        public override void Update(GameTime gameTime)
        {
            if (activeState != BirdState.Flying)
                return;

            CheckForCollision();
            foreach (PipePair pipe in game.pipeManager.Pipes)
                pipe.Bottle.CheckCollision(this);

            if (speed <= 0)
                activePeter = peterFlap;
            else if (isDrinking)
                activePeter = peterDrink;
            else
                activePeter = peterNormal;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && spaceWasUp)
                Jump();

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
                spaceWasUp = true;

            if (speed <= maxSpeed)
                speed++;

            YCord += speed;
        }

        private void Jump()
        {
            speed = -jumpForce;
            spaceWasUp = false;
        }


        private void CheckForCollision()
        {
            if (location.Y + size.Y + speed >= game.GraphicsDevice.DisplayMode.Height)
            {
                activeState = BirdState.Dead;
                return;
            }

            foreach (PipePair pipe in game.pipeManager.Pipes)
                if (pipe.IsInsidePipe(new Rectangle(location.ToPoint() + new Point(0, (int)speed), size)))
                    activeState = BirdState.Dead;
        }

    }
}
