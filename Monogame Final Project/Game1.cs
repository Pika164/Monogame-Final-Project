using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Monogame_Final_Project
{
    enum Screen
    {
        Intro,
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
        Texture2D endScreenTexture;
        Texture2D endButtonTexture;

        Rectangle endButtonRect;
        Rectangle endScreenRect;
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
        Rectangle goalArea2Rect;
        Rectangle introButtonRect;
        Rectangle stageTwoRect;
        Rectangle stageTwoFillingRect;
        Rectangle fillingRect;
        Rectangle fillingRect2;
        Rectangle fillingRect3;
        Rectangle fillingRect4;
        Rectangle fillingRect5;
        Rectangle enemyRect4;
        Rectangle enemyRect5;
        Rectangle enemyRect6;
        Rectangle enemyRect7;
        Rectangle enemyRect8;
        Rectangle enemyRect9;

        List<Rectangle> stageOneBarriers;
        List<Rectangle> stageTwoBarriers;

        Vector2 playerSpeed;
        Vector2 enemySpeed;
        Vector2 enemySpeed2;
        Vector2 enemySpeed3;
        Vector2 enemySpeed4;
        Vector2 enemySpeed5;
        Vector2 enemySpeed6;
        Vector2 enemySpeed7;

        KeyboardState keyboardState;
        KeyboardState keyboardState2;

        MouseState mouseState;

        int deaths;

        SpriteFont deathFont;

        SoundEffect bgMusic;
        SoundEffectInstance bgMusicplaying;

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

            goalArea2Rect = new Rectangle(95, 427, 70, 70);

            playerSpeed = new Vector2(0,0);

            introButtonRect = new Rectangle(500,450,240,72);

            enemyRect = new Rectangle(225,320,36,36);

            enemyRect2 = new Rectangle(222, 267, 36, 36);

            enemyRect3 = new Rectangle(222,372,36,36);

            enemyRect4 = new Rectangle(220,50,30,75);

            enemyRect5 = new Rectangle(220, 160, 30, 75);

            enemyRect6 = new Rectangle(630,50,30,120);

            enemyRect7 = new Rectangle(675,385,30,75);

            enemySpeed = new Vector2(0,0);

            enemySpeed2 = new Vector2(3,0);

            enemySpeed3 = new Vector2(3,0);

            enemySpeed4 = new Vector2(4,0);

            enemySpeed5 = new Vector2(4,0);

            enemySpeed6 = new Vector2(-2,0);

            stageTwoRect = new Rectangle(-150, -175, 1100, 900);

            stageTwoFillingRect = new Rectangle(-150, -175, 1100, 900);

            stageOneBarriers = new List<Rectangle>();

            stageTwoBarriers = new List<Rectangle>();

            deaths = 0;

            fillingRect = new Rectangle(573, 262, 30, 200);

            fillingRect2 = new Rectangle(195, 258, 30, 150);

            fillingRect3 = new Rectangle(0,0,800,222);

            fillingRect4 = new Rectangle(0,450,800,150);

            fillingRect5 = new Rectangle(37, 225, 50, 225);

            endScreenRect = new Rectangle(0,0,800,600);

            base.Initialize();
            stageOneBarriers.Add(new Rectangle(195,260,30,150));
            stageOneBarriers.Add(new Rectangle(573, 264, 30, 150));

            stageOneBarriers.Add(new Rectangle(195, 220, 341, 45));
            stageOneBarriers.Add(new Rectangle(262, 416, 341, 40));

            stageOneBarriers.Add(new Rectangle(77, 452, 640, 40));
            stageOneBarriers.Add(new Rectangle(77, 183, 640, 40));

            stageOneBarriers.Add(new Rectangle(39, 225, 50, 225));
            stageOneBarriers.Add(new Rectangle(708, 225, 50, 225));

            stageTwoBarriers.Add(new Rectangle(159, 240, 480, 75));
            stageTwoBarriers.Add(new Rectangle(90,126,75,300));

            stageTwoBarriers.Add(new Rectangle(50, 47, 40, 475));
            stageTwoBarriers.Add(new Rectangle(53, 27, 625, 20));

            stageTwoBarriers.Add(new Rectangle(678,27,35,135));
            stageTwoBarriers.Add(new Rectangle(680, 390, 35, 135));

            stageTwoBarriers.Add(new Rectangle(715, 27, 40, 475));
            stageTwoBarriers.Add(new Rectangle(90, 500, 600, 35));

         
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
            deathFont = Content.Load<SpriteFont>("death");
            bgMusic = Content.Load<SoundEffect>("music");
            endScreenTexture = Content.Load<Texture2D>("endScreen");
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();


            //sound 

            bgMusic.Play();

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

                if (keyboardState.IsKeyDown(Keys.A))
                {
                    playerSpeed.X -= (float)2.0;
                }
                if (keyboardState.IsKeyDown(Keys.D))
                {
                    playerSpeed.X += (float)2.0;
                }
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    playerSpeed.Y -= (float)2.0;
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    playerSpeed.Y += (float)2.0;
                }

                if (keyboardState.IsKeyDown(Keys.LeftShift))
                {
                    playerLocation.X -= 10;
                    playerRect.Location = playerLocation.ToPoint();
                }

                if (keyboardState.IsKeyDown(Keys.RightShift))
                {
                    playerLocation.X += 10;
                    playerRect.Location = playerLocation.ToPoint();

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
                    if (playerRect.Intersects(barrier))
                    {
                        playerLocation.X -= 10;
                        playerRect.Location = playerLocation.ToPoint();
                    }

                foreach (Rectangle barrier in stageOneBarriers)
                    if (barrier.Contains(playerRect))
                    {
                        playerLocation -= playerSpeed;
                        playerLocation.X -= 10;
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
                    deaths += 1;
                }

                if (enemyRect2.Intersects(playerRect))
                {
                    playerLocation.X = 168;
                    playerLocation.Y = 250;
                    playerRect.Location = playerLocation.ToPoint();
                    deaths += 1;
                }

                if (enemyRect3.Intersects(playerRect))
                {
                    playerLocation.X = 168;
                    playerLocation.Y = 250;
                    playerRect.Location = playerLocation.ToPoint();
                    deaths += 1;
                }

                if (fillingRect.Intersects(playerRect))
                {
                    playerLocation.X = 168;
                    playerLocation.Y = 250;
                    playerRect.Location = playerLocation.ToPoint();
                }

                if (fillingRect2.Intersects(playerRect))
                {
                    playerLocation.X = 168;
                    playerLocation.Y = 250;
                    playerRect.Location = playerLocation.ToPoint();
                }

                if (fillingRect3.Intersects(playerRect))
                {
                    playerLocation.X = 168;
                    playerLocation.Y = 250;
                    playerRect.Location = playerLocation.ToPoint();
                }

                if (fillingRect4.Intersects(playerRect))
                {
                    playerLocation.X = 168;
                    playerLocation.Y = 250;
                    playerRect.Location = playerLocation.ToPoint();
                }

                if (fillingRect5.Intersects(playerRect))
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
                enemyRect4.X += (int)enemySpeed4.X;
                enemyRect5.X += (int)enemySpeed5.X;
                enemyRect6.X += (int)enemySpeed6.X;

                this.Window.Title = "X = " + mouseState.X + "Y = " + mouseState.Y;

                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    playerSpeed.X -= (float)1.5;
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    playerSpeed.X += (float)2.0;
                }
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    playerSpeed.Y -= (float)1.5;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    playerSpeed.Y += (float)2.0;
                }

                playerLocation += playerSpeed;
                playerRect2.Location = playerLocation.ToPoint();

                foreach (Rectangle barrier in stageTwoBarriers)
                    if (enemyRect4.Intersects(barrier))
                    {
                        enemySpeed4.X *= -1;
                        enemySpeed5.X *= -1;
                    }

                if (enemyRect4.X <= 168)
                {
                    enemySpeed5.X *= -1;
                    enemySpeed4.X *= -1;
                }

                if (enemyRect4.Intersects(playerRect2))
                {
                    playerRect2.X = 129;
                    playerRect2.Y = 79;
                    playerRect.Location = playerLocation.ToPoint();
                    deaths += 1;
                }

                foreach (Rectangle barrier in stageTwoBarriers)
                    if (enemyRect6.Intersects(barrier))
                    {
                        enemySpeed6.X *= -1;
                    }

                if (enemyRect6.X <= 168)
                {
                    enemySpeed6.X *= -1;
                }

                if (enemyRect6.Intersects(playerRect2))
                {
                    playerRect2.X = 129;
                    playerRect2.Y = 79;
                    playerRect.Location = playerLocation.ToPoint();
                    deaths += 1;
                }

                if (enemyRect5.Intersects(playerRect2))
                {
                    playerRect2.X = 129;
                    playerRect2.Y = 79;
                    playerRect.Location = playerLocation.ToPoint();
                    deaths += 1;
                }

                foreach (Rectangle barrier in stageTwoBarriers)
                    if (playerRect2.Intersects(barrier))
                    {
                        playerLocation -= playerSpeed;
                        playerRect2.Location = playerLocation.ToPoint();
                    }

                if (goalArea2Rect.Contains(playerRect2))
                {
                    screen = Screen.End;
                }

            }

            if (screen == Screen.End)
            {
                this.Window.Title = "X = " + mouseState.X + "Y = " + mouseState.Y;
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

                _spriteBatch.Draw(rectangleTexture, fillingRect, Color.White);

                _spriteBatch.Draw(rectangleTexture, fillingRect2, Color.White);

                _spriteBatch.Draw(rectangleTexture, fillingRect3, Color.White);

                _spriteBatch.Draw(rectangleTexture, fillingRect4, Color.White);

                _spriteBatch.Draw(rectangleTexture, goalArea1Rect, Color.White);

                _spriteBatch.Draw(stageOneTexture, stageOneRect, Color.White);

                _spriteBatch.Draw(stageOneFillingTexture, stageOneFillingRect, Color.White);

                _spriteBatch.Draw(enemyTexture, enemyRect, Color.White);

                _spriteBatch.Draw(enemyTexture2, enemyRect2, Color.White);

                _spriteBatch.Draw(enemyTexture3, enemyRect3, Color.White);

                _spriteBatch.Draw(playerTexture, playerRect, Color.White);

                _spriteBatch.Draw(rectangleTexture, fillingRect5, Color.White);

                _spriteBatch.DrawString(deathFont, (deaths).ToString("000"), new Vector2(675, 45), Color.Black);

                _spriteBatch.DrawString(deathFont, "Deaths", new Vector2(655,15), Color.Black);

            }

            if (screen == Screen.Level2)
            {
                _spriteBatch.Draw(rectangleTexture, goalArea2Rect, Color.White);

                foreach (Rectangle barrier in stageTwoBarriers)
                    _spriteBatch.Draw(rectangleTexture, barrier, Color.White);

                _spriteBatch.Draw(stageTwoTexture, stageTwoRect, Color.White);

                _spriteBatch.Draw(stageTwoFillingTexture, stageTwoFillingRect, Color.White);

                _spriteBatch.Draw(playerTexture, playerRect2, Color.White);

                _spriteBatch.Draw(enemyTexture, enemyRect4, Color.White);

                _spriteBatch.Draw(enemyTexture, enemyRect5, Color.White);

                _spriteBatch.Draw(enemyTexture, enemyRect6, Color.White);

                foreach (Rectangle barrier in stageTwoBarriers)
                    _spriteBatch.Draw(rectangleTexture, barrier, Color.White);

                _spriteBatch.DrawString(deathFont, (0 + deaths).ToString("000"), new Vector2(700, 45), Color.Black);

                _spriteBatch.DrawString(deathFont, "Deaths", new Vector2(675, 15), Color.Black);

            }

            if (screen == Screen.End)
            {
                _spriteBatch.Draw(endScreenTexture, endScreenRect, Color.White);

                _spriteBatch.DrawString(deathFont, (0 + deaths).ToString("000"), new Vector2(415, 225), Color.Black);

                _spriteBatch.DrawString(deathFont, "Deaths", new Vector2(390, 175), Color.Black);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}