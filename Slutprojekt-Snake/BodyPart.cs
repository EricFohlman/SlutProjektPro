using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Snake
{
    class BodyPart
    {
        public float x;
        public float y;

        public BodyPart(float x, float y)
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

    }
}
