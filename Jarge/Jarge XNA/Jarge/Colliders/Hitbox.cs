using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JargeEngine.Colliders
{
    public class Hitbox : Collider
    {
        public static Rectangle Bounds;

        public Hitbox(float w, float h, int _x, int _y)
        {
            Bounds = new Rectangle(_x, _y, (int)w, (int)h);
        }
        public override void Update()
        {
            Parent.Width = Bounds.Width;
            Parent.Height = Bounds.Height;
            Bounds.X = (int)Parent.X;
            Bounds.Y = (int)Parent.Y;

            base.Update();
        }
        public override bool Collide(Hitbox h)
        {
            return Collide(h);
        }
        public static Rectangle GetBounds()
        {
            return Bounds;
        }
    }
}
