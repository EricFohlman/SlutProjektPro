using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Slutprojekt_Snake
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game /*Här anropas variabler samt metoder*/
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Snake snake;
        Food food;
        Random random;
        GameClock clock;
        int screenWidth = 750;
        int screenHeight = 750;

        public Game1() /*Ändrar spelskärmens storlek och spawnar en random*/
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.ApplyChanges();


            random = new Random();
        }

        private void SpawnFood() /*Spawnar maten i rätt storlek och i rätt postion med ormen*/
        {
            int blockWidth = screenWidth / Block.Size;
            int blockHeight = screenHeight / Block.Size;
            food = new Food(random.Next(0, blockWidth) * Block.Size, random.Next(0, blockHeight) * Block.Size);
        }

        private void Restart() /*Ser till att ormen inte försvinner halvägs utanför bannan alltså att den är alignad med banan samt maten.*/
        {
            float width = GraphicsDevice.Viewport.Width / 2 - 25;
            float height = GraphicsDevice.Viewport.Height / 2 - 25;

            snake = new Snake(width, height);

            SpawnFood();   
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()/*När ormen dör startar spelet om dvs vid rör sig själv endast i detta fallet*/
        {
            // TODO: Add your initialization logic here
            spriteBatch = new SpriteBatch(GraphicsDevice);
            clock = new GameClock();

            Restart();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) /*Kollisionen för maten och ormen och att den lägger till maten som en bodypart,*/
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (snake.x == food.x && snake.y == food.y)
            {
                snake.Grow();
                SpawnFood();
            }

            clock.Tick(gameTime);
            snake.ReadInput();

            if (clock.didAdvanceFrame)
            {
                snake.Move();
            }
            for(int i = 0; i < snake.Tail.Count; i++)
                if(snake.Head.x == snake.Tail[i].x && snake.Head.y == snake.Tail[i].y)
                {
                    Restart();
                }
            
            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) /*Denna skriver ut allt som spelet behöver för att fungera*/
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            snake.Draw(graphics, spriteBatch);

            food.Draw(graphics, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
