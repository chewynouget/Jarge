using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JargeEngine;
using Microsoft.Xna.Framework;

namespace JargeEngine
{
    public class Hitbox
    {
        public Entity Parent;
        public Rectangle Bounds;

        public Hitbox(int width=1, int height=1)
        {
            Bounds = new Rectangle(0, 0, width, height);
        }
        public void AssignTo(Entity ent)
        {
            Parent = ent;
            if (ent != null)
                Update();
        }
        public void Update()
        {
            Bounds.X = (int)Parent.X;
            Bounds.Y = (int)Parent.Y;
        }
        public bool Collide(Hitbox h)
        {
            return Bounds.Intersects(h.Bounds);
        }
        public bool Collide(Entity ent)
        {
            if (ent.Hitbox != null)
                return Collide(ent.Hitbox);
            else
                throw new NotImplementedException("No hitbox!");
        }
    }
}
