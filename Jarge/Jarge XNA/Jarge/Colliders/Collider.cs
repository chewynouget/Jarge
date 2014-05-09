using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JargeEngine.Colliders
{
    public class Collider
    {
        /*
         * This class is directly ripped from Flashpunk's "Mask" Class,
         * but edited for C#
         * */

        public Entity Parent;

        public Collider()
        {

        }
        private bool collide(Collider other)
        {
            return Parent.Position.X + Parent.Width > other.Parent.Position.X
                && Parent.Position.Y + Parent.Height > other.Parent.Position.Y
                && Parent.Position.X < other.Parent.Position.X + other.Parent.Width
                && Parent.Position.Y < other.Parent.Position.Y + other.Parent.Height;
        }
        public virtual void Update()
        {
            
        }
        public void AssignTo(Entity parent)
        {
            Parent = parent;
            if (parent != null)
            {
                Update();
            }
        }
        public virtual bool Collide(Collider other) { return false; }
        public virtual bool Collide(Hitbox other) { return false; }
    }
}