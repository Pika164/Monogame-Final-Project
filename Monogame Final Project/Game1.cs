using System.Collections.Generic;
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

        Rectangle playerRect;
        Rectangle window;
        Rectangle stageOneRect;

        List<Rectangle> stageOneBarriers;
        List<Rectangle> stageTwoBarriers;

        Vector2 playerSpeed;

        KeyboardState keyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {


            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            // TODO: Add your initialization logic here

            playerRect = new Rectangle(0,0,50,50);

            stageOneRect = new Rectangle(-100,-80,1000,800);

            playerSpeed = new Vector2(0,0);

            base.Initialize();
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


        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            playerSpeed.X = 0;
            playerSpeed.Y = 0;


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                playerSpeed.X -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                playerSpeed.X += 2;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
               playerSpeed.Y -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                playerSpeed.Y += 2;
            }
            playerRect.X += (int)playerSpeed.X;
            playerRect.Y += (int)playerSpeed.Y;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(stageOneTexture, stageOneRect, Color.White);

            _spriteBatch.Draw(stageOneFillingTexture, new Vector2(-100,-75), Color.White);

            _spriteBatch.Draw(playerTexture, playerRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
