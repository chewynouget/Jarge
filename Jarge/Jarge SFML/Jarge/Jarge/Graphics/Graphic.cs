using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Jarge_SFML.Graphics
{
    public abstract class Graphic
    {
        public float Angle { get; set; }
        public float Alpha { get; set; }

        public Color Tint { get; set; }
        public Vector2f Scale;
        public Vector2f Position;
        public Vector2f Origin { get; set; }

        public abstract void Draw();
        public virtual void Update() { }
        public virtual void SetScale(float x, float y) 
        {
            Scale = new Vector2f(x, y);
        }

        public virtual void SetPosition(float x, float y)
        {
            Position = new Vector2f(x, y);
        }

        public virtual void CenterOrigin() 
        {
        }

        public virtual void SetOrigin(float x, float y)
        {
        }

        public Graphic()
        {
            Origin = new Vector2f(0, 0);
            Angle = 0;
            Scale = new Vector2f(1, 1);
            Alpha = 1;
            Tint = Color.White;
        }
    }
}
