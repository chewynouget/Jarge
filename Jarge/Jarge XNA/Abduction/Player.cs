using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JargeEngine;
using JargeEngine.Graphics;
using JargeEngine.Framework.Utils;
using Microsoft.Xna.Framework.Input;
using JargeEngine.Util;

namespace Abduction
{
    class Player : Entity
    {
        Image image;
        float timer;

        public Player() : base(100, 100)
        {
            image = new Image("player");
            CenterOrigin();
            image.CenterOrigin();
            AddGraphic(image);

            Friction = new Microsoft.Xna.Framework.Vector2(.65f, .69f);
        }
        public override void Update()
        {
            timer += 0.09f;
            Position.Y += (float)Math.Sin(timer);
            
            if (JInput.KeyDown(Keys.D) || GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One).ThumbSticks.Left.X > 0.5)
            {
                Move(2, 0);
                image.Normal();
            }
            if (JInput.KeyDown(Keys.A) || GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One).ThumbSticks.Left.X < -0.5)
            {
                Move(-2, 0);
                image.FlipHorizontally();
            }
            if (JInput.KeyDown(Keys.S) || GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One).ThumbSticks.Left.Y < 0.5)
            {
                Move(0, 1);
            }
            if (JInput.KeyDown(Keys.W) || GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One).ThumbSticks.Left.Y > -0.5)
            {
                Move(0, -1);
            }
            base.Update();
        }
    }
}
