using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Snake
{
    class Block
    {
        public static readonly int Size = 50;
        public float x;
        public float y;

        public Block(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            Texture2D rect = new Texture2D(graphics.GraphicsDevice, Block.Size, Block.Size);

            Color[] data = new Color[Block.Size * Block.Size];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Black;
            rect.SetData(data);

            Vector2 coor = new Vector2(x, y);
            spriteBatch.Draw(rect, coor, Color.White);
        }
    }
}
