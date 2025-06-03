using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Final_Project
{
    enum Screen
    {
        Intro,
        Controls,
        Level1,
        Level2,
        End
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Screen screen;

        Texture2D playerTexture;
        Texture2D stageOneTexture;
        Texture2D stageTwoTexture;
        Texture2D stageOneFillingTexture;
        Texture2D stageTwoFillingTexture;
        Texture2D currentPlayerTexture;
        Texture2D rectangleTexture;
        Texture2D introScreenTexture;
        Texture2D introButtonTexture;
        Texture2D enemyTexture;

        Rectangle enemyRect;
        Rectangle playerRect;
        Vector2 playerLocation;
        Rectangle window;
        Rectangle stageOneRect;
        Rectangle stageOneFillingRect;
        Rectangle goalArea1Rect;
        Rectangle introButtonRect;

        List<Rectangle> stageOneBarriers;
        List<Rectangle> stageTwoBarriers;

        Vector2 playerSpeed;

        KeyboardState keyboardState;
        KeyboardState oldState;

        MouseState mouseState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screen = Screen.Intro;

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            // TODO: Add your initialization logic here

            playerLocation = new Vector2(168, 250);

            playerRect = new Rectangle(168, 250, 15,15);

            stageOneRect = new Rectangle(-150,-100,1100,900);

            stageOneFillingRect = new Rectangle(-150, -100, 1100, 900);

            goalArea1Rect = new Rectangle(607,267,100,180);

            playerSpeed = new Vector2(0,0);

            introButtonRect = new Rectangle(500,450,240,72);

            stageOneBarriers = new List<Rectangle>();

            base.Initialize();
            stageOneBarriers.Add(new Rectangle(195,260,30,150));
            stageOneBarriers.Add(new Rectangle(573, 264, 30, 150));

            stageOneBarriers.Add(new Rectangle(195, 220, 341, 40));
            stageOneBarriers.Add(new Rectangle(262, 414, 341, 40));

            stageOneBarriers.Add(new Rectangle(77, 452, 640, 40));
            stageOneBarriers.Add(new Rectangle(77, 183, 640, 40));

            stageOneBarriers.Add(new Rectangle(39, 225, 50, 225));
            stageOneBarriers.Add(new Rectangle(708, 225, 50, 225));

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            playerTexture = Content.Load<Texture2D>("Cube");
            stageOneTexture = Content.Load<Texture2D>("levelOne");
            stageTwoTexture = Content.Load<Texture2D>("levelTwo");
            stageOneFillingTexture = Content.Load<Texture2D>("stageFilling");
            stageTwoFillingTexture = Content.Load<Texture2D>("stageFillingTwo");
            rectangleTexture = Content.Load<Texture2D>("images");
            introButtonTexture = Content.Load<Texture2D>("introButton");
            introScreenTexture = Content.Load<Texture2D>("introScreen");
            enemyTexture = Content.Load<Texture2D>("projectile");

        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (screen == Screen.Intro)
            {

                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (introButtonRect.Contains(mouseState.Position))
                    {
                        screen = Screen.Level1;
                    }
                }
            }

            if (screen == Screen.Level1)
            {
                keyboardState = Keyboard.GetState();
                KeyboardState newState = Keyboard.GetState();
                
                playerSpeed.X = 0;
                playerSpeed.Y = 0;

                this.Window.Title = "X = " + mouseState.X + "Y = " + mouseState.Y;

                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    playerSpeed.X -= (float)1.5;
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    playerSpeed.X += (float)1.5;
                }
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    playerSpeed.Y -= (float)1.5;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    playerSpeed.Y += (float)1.5;
                }

                if (goalArea1Rect.Contains(playerRect))
                {
                    screen = Screen.Level2;
                }

                playerLocation += playerSpeed;
                playerRect.Location = playerLocation.ToPoint();

                foreach (Rectangle barrier in stageOneBarriers)
                    if (playerRect.Intersects(barrier))
                    {
                        playerLocation -= playerSpeed;
                        playerRect.Location = playerLocation.ToPoint();
                    }

            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introScreenTexture, new Vector2(0,0), Color.White);
                
                _spriteBatch.Draw(introButtonTexture,introButtonRect,Color.White);
            }

            if (screen == Screen.Level1)
            {
                foreach (Rectangle barrier in stageOneBarriers)
                    _spriteBatch.Draw(rectangleTexture, barrier, Color.White);

                _spriteBatch.Draw(rectangleTexture, goalArea1Rect, Color.White);

                _spriteBatch.Draw(stageOneTexture, stageOneRect, Color.White);

                _spriteBatch.Draw(stageOneFillingTexture, stageOneFillingRect, Color.White);

                _spriteBatch.Draw(playerTexture, playerRect, Color.White);

            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
