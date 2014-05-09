using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JargeEngine
{
    public class Component
    {
        public Vector2 Position = default(Vector2);
        public string Name = "";
        public bool Visible = true;
        public bool Active = true;
        public float Rotation;

        public Entity Entity
        {
            get;
            internal set;
        }
        public float X
        {
            get { return this.Position.X; }
            set { this.Position.X = value; }
        }
        public float Y
        {
            get { return this.Position.Y; }
            set { this.Position.Y = value; }
        }

        public virtual void Begin()
        {
        }
        public virtual void Update()
        {
        }
        public virtual void Remove()
        {

        }
    }
}
