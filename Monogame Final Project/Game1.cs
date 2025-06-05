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
        Texture2D enemyTexture2;
        Texture2D enemyTexture3;

        Rectangle enemyRect;
        Rectangle enemyRect2;
        Rectangle enemyRect3;
        Rectangle playerRect;
        Rectangle playerRect2;
        Vector2 playerLocation;
        Rectangle window;
        Rectangle stageOneRect;
        Rectangle stageOneFillingRect;
        Rectangle goalArea1Rect;
        Rectangle introButtonRect;
        Rectangle stageTwoRect;
        Rectangle stageTwoFillingRect;

        List<Rectangle> stageOneBarriers;
        List<Rectangle> stageTwoBarriers;

        Vector2 playerSpeed;
        Vector2 enemySpeed;
        Vector2 enemySpeed2;
        Vector2 enemySpeed3;

        KeyboardState keyboardState;
        KeyboardState keyboardState2;

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

            playerRect2 = new Rectangle(129,77,15,15);

            stageOneRect = new Rectangle(-150,-100,1100,900);

            stageOneFillingRect = new Rectangle(-150, -100, 1100, 900);

            goalArea1Rect = new Rectangle(607,267,100,180);

            playerSpeed = new Vector2(0,0);

            introButtonRect = new Rectangle(500,450,240,72);

            enemyRect = new Rectangle(220,320,35,35);

            enemyRect2 = new Rectangle(222, 267, 33, 33);

            enemyRect3 = new Rectangle(222,372,33,33);

            enemySpeed = new Vector2(7,0);

            enemySpeed2 = new Vector2(4,0);

            enemySpeed3 = new Vector2(4,0);

            stageTwoRect = new Rectangle(-150, -175, 1100, 900);

            stageTwoFillingRect = new Rectangle(-150, -175, 1100, 900);

            stageOneBarriers = new List<Rectangle>();

            stageTwoBarriers = new List<Rectangle>();

            base.Initialize();
            stageOneBarriers.Add(new Rectangle(195,260,30,150));
            stageOneBarriers.Add(new Rectangle(573, 264, 30, 150));

            stageOneBarriers.Add(new Rectangle(195, 220, 341, 40));
            stageOneBarriers.Add(new Rectangle(262, 414, 341, 40));

            stageOneBarriers.Add(new Rectangle(77, 452, 640, 40));
            stageOneBarriers.Add(new Rectangle(77, 183, 640, 40));

            stageOneBarriers.Add(new Rectangle(39, 225, 50, 225));
            stageOneBarriers.Add(new Rectangle(708, 225, 50, 225));

            stageTwoBarriers.Add(new Rectangle(159, 240, 480, 75));

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
            enemyTexture = Content.Load<Texture2D>("enemy");
            enemyTexture2 = Content.Load<Texture2D>("enemy (1)");
            enemyTexture3 = Content.Load<Texture2D>("enemy (2)");

        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

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
                
                playerSpeed.X = 0;
                playerSpeed.Y = 0;

                enemyRect.X += (int)enemySpeed.X;
                enemyRect2.X += (int)enemySpeed2.X;
                enemyRect3.X += (int)enemySpeed3.X;

                this.Window.Title = "X = " + mouseState.X + "Y = " + mouseState.Y;

                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    playerSpeed.X -= (float)2.0;
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    playerSpeed.X += (float)2.0;
                }
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    playerSpeed.Y -= (float)2.0;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    playerSpeed.Y += (float)2.0;
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

                foreach (Rectangle barrier in stageOneBarriers)
                    if (enemyRect.Intersects(barrier))
                    {
                        enemySpeed.X *= -1;
                    }

                foreach (Rectangle barrier in stageOneBarriers)
                    if (enemyRect2.Intersects(barrier))
                    {
                        enemySpeed2.X *= -1;
                    }

                foreach (Rectangle barrier in stageOneBarriers)
                    if (enemyRect3.Intersects(barrier))
                    {
                        enemySpeed3.X *= -1;
                    }

                if (enemyRect.Intersects(playerRect))
                {
                        playerLocation.X = 168;
                        playerLocation.Y= 250;
                        playerRect.Location = playerLocation.ToPoint();
                }

                if (enemyRect2.Intersects(playerRect))
                {
                    playerLocation.X = 168;
                    playerLocation.Y = 250;
                    playerRect.Location = playerLocation.ToPoint();
                }

                if (enemyRect3.Intersects(playerRect))
                {
                    playerLocation.X = 168;
                    playerLocation.Y = 250;
                    playerRect.Location = playerLocation.ToPoint();
                }

            }

            if (screen == Screen.Level2)
            {

                keyboardState = Keyboard.GetState();
                playerSpeed.X = 0;
                playerSpeed.Y = 0;
                playerLocation.X = playerRect2.X;
                playerLocation.Y = playerRect2.Y;

                this.Window.Title = "X = " + mouseState.X + "Y = " + mouseState.Y;

                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    playerSpeed.X -= (float)1.0;
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    playerSpeed.X += (float)1.5;
                }
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    playerSpeed.Y -= (float)1.0;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    playerSpeed.Y += (float)1.5;
                }

                playerLocation += playerSpeed;
                playerRect2.Location = playerLocation.ToPoint();

                foreach (Rectangle barrier in stageTwoBarriers)
                    if (playerRect2.Intersects(barrier))
                    {
                        playerLocation -= playerSpeed;
                        playerRect2.Location = playerLocation.ToPoint();
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

                _spriteBatch.Draw(enemyTexture, enemyRect, Color.White);

                _spriteBatch.Draw(enemyTexture2, enemyRect2, Color.White);

                _spriteBatch.Draw(enemyTexture3, enemyRect3, Color.White);

                _spriteBatch.Draw(playerTexture, playerRect, Color.White);

            }

            if (screen == Screen.Level2)
            {
                _spriteBatch.Draw(stageTwoTexture, stageTwoRect, Color.White);

                _spriteBatch.Draw(stageTwoFillingTexture, stageTwoFillingRect, Color.White);

                _spriteBatch.Draw(playerTexture, playerRect2, Color.White);

                foreach (Rectangle barrier in stageTwoBarriers)
                    _spriteBatch.Draw(rectangleTexture, barrier, Color.White);

            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
