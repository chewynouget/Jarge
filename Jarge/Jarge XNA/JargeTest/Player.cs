using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JargeEngine;
using JargeEngine.Graphics;
using JargeEngine.Framework.Utils;
using Microsoft.Xna.Framework.Input;

namespace JargeTest
{
    class Player : Entity
    {
        public Player() : base(50,100)
        {
            AddGraphic(new Shape(0, 0, 32, 32));
            SetHitbox(32,32);
        }
        public override void Update()
        {
            if (JInput.KeyDown(Keys.Right))
                Move(5, 0);
            if (JInput.KeyDown(Keys.Left))
                Move(-5, 0);
            if (!Collide(GameScene.WALL))
            {
                Move(0, 5);
            }
            else
            {
                if (JInput.KeyDown(Keys.Up))
                    Speed.Y -= 10;
            }
            base.Update();
        }
    }
}
