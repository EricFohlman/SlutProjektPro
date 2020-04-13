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
        Vector2 direction;
        List<BodyPart> body = new List<BodyPart>();

        public Snake(float x, float y)
        {
            this.x = x;
            this.y = y;
            direction = new Vector2(0, -1);
            body.Add(new BodyPart(x, y));
            body.Add(new BodyPart(x, y + 50));
            body.Add(new BodyPart(x, y + 100));
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

            
            x += direction.X * 50;
            y += direction.Y * 50;
            for(int i=body.Count-1; i>0; i--)
            {
                BodyPart previous = body[i - 1];
                BodyPart current = body[i];

                current.x = previous.x;
                current.y = previous.y;

            }

            body[0].x = x;
            body[0].y = y;
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
