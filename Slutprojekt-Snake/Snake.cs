using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;



namespace Slutprojekt_Snake
{
    class Snake
    {
        public float x;
        public float y;
        Vector2 direction;
        Vector2 previousDirection;
        List<BodyPart> body = new List<BodyPart>();

        public Snake(float x, float y)
        {
            this.x = x;
            this.y = y;
            direction = new Vector2(0, -1);
            body.Add(new BodyPart(x, y));
            body.Add(new BodyPart(x, y + Block.Size));
            body.Add(new BodyPart(x, y + Block.Size * 2));
        }

        public void Grow()
        {
            body.Add(new BodyPart(x, y));
        }
        public void ReadInput()
        {
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.Right) || kState.IsKeyDown(Keys.D))
            {
                if (previousDirection != new Vector2(-1, 0))
                    direction = new Vector2(1, 0);
            }
            else if (kState.IsKeyDown(Keys.Left) || kState.IsKeyDown(Keys.A))
            {
                if (previousDirection != new Vector2(1, 0))
                    direction = new Vector2(-1, 0);
            }
            else if (kState.IsKeyDown(Keys.Up) || kState.IsKeyDown(Keys.W))
            {
                if (previousDirection != new Vector2(0, 1))
                    direction = new Vector2(0, -1);
            }
            else if (kState.IsKeyDown(Keys.Down) || kState.IsKeyDown(Keys.S))
            {
                if (previousDirection != new Vector2(0, -1))
                    direction = new Vector2(0, 1);
            }
        }

        public void Move()
        {   
            x += direction.X * Block.Size;
            y += direction.Y * Block.Size;
            for(int i=body.Count-1; i>0; i--)
            {
                BodyPart previous = body[i - 1];
                BodyPart current = body[i];

                current.x = previous.x;
                current.y = previous.y;
            }

            body[0].x = x;
            body[0].y = y;

            previousDirection = direction;
        }

        public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < body.Count; i++)
            {
                body[i].Draw(graphics, spriteBatch);
            }
        }
    }
}
