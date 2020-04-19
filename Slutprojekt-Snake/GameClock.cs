using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt_Snake
{
    class GameClock
        
    {
        int fps = 5;
        public bool didAdvanceFrame = false;
        TimeSpan previousTime = new TimeSpan();

        public void Tick(GameTime gameTime)
        {
            TimeSpan currentTime = gameTime.TotalGameTime;
            int currentFrame = Convert.ToInt32(currentTime.TotalSeconds * fps);
            int previousFrame = Convert.ToInt32(previousTime.TotalSeconds * fps);

            didAdvanceFrame = currentFrame > previousFrame;

            previousTime = currentTime;
        }
    }
}
