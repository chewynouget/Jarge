using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Jarge_SFML
{
    public class Component
    {
        public Vector2f Position = default(Vector2f);
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
