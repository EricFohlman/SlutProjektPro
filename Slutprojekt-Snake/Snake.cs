using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Slutprojekt_Snake
{
    class Snake
    {
        float x;
        float y;
        float speed = 4;
        Vector2 direction;
        public Snake(float x, float y)
        {
            this.x = x;
            this.y = y;

        }

        public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 50, 50);

            Color[] data = new Color[50 * 50];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Black;
            rect.SetData(data);

            Vector2 coor = new Vector2(x, y);
            spriteBatch.Draw(rect, coor, Color.White);
        }
        public void Move()
        {
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.Right) || kState.IsKeyDown(Keys.D))  
            {
                direction = new Vector2(1, 0);
            }
            else if (kState.IsKeyDown(Keys.Left) || kState.IsKeyDown(Keys.A))
            {
                direction = new Vector2(-1, 0);
            }
            else if (kState.IsKeyDown(Keys.Up) || kState.IsKeyDown(Keys.W))
            {
                direction = new Vector2(0, -1);
            }
            else if (kState.IsKeyDown(Keys.Down) || kState.IsKeyDown(Keys.S))
            {
                direction = new Vector2(0, 1);
            }

            x += direction.X * speed;
            y += direction.Y * speed;
        }
    }
}
