using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Snake
{
    class BodyPart : Block /*Denna gör kropsdelarna också till block som är storleken av alla delar*/
    {
        public BodyPart(float x, float y) : base(x, y)
        {
           
        }
    }
}
