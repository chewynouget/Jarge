using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JargeEngine;
using JargeEngine.Graphics;
using JargeEngine.Framework.Utils;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace JargeTest
{
    class Wall : Entity
    {
        public Wall(int x, int y)
            : base(x, y)
        {
            AddGraphic(new Shape(0, 0, 256, 32));
            graphics[0].Tint = Color.Red;
            SetHitbox(256,32);
        }
        public override void Update()
        {
            base.Update();
        }
    }
}
