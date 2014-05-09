using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JargeEngine;
using Microsoft.Xna.Framework.Input;
using JargeEngine.Framework.Utils;
using JargeEngine.Graphics;

namespace Abduction
{
    class Pointer : Entity
    {
        public Pointer() : base(Jarge.Width / 2, Jarge.Height / 2)
        {
            
        }
        public override void Update()
        {
            if (JInput.KeyDown(Keys.Right))
            {
                Position.X += 5;
            }
            if (JInput.KeyDown(Keys.Left))
            {
                Position.X -= 5;
            }
            if (JInput.KeyDown(Keys.Down))
            {
                Position.Y += 5;
            }
            if (JInput.KeyDown(Keys.Up))
            {
                Position.Y -= 5;
            }
            base.Update();
        }
        public override void Draw()
        {
            Render.Rectangle((int)Position.X, (int)Position.Y, 100, 100);
            base.Draw();
        }
    }
}
