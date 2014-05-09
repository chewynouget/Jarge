using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JargeEngine.Graphics
{
    public abstract class Graphic
    {
        public float Angle { get; set; }
        public float Scale { get; set; }
        public float Alpha { get; set; }
        public float Layer { get; set; }

        public Color Tint { get; set; }
        public Vector2 Position;
        public Vector2 Origin { get; set; }
        public static bool Flipped { get; set; }
        
        public abstract void Draw();
        public virtual void CenterOrigin() { }
        public virtual void UncenterOrigin() { }
        public virtual bool IsOriginCentered() { return false; }
        public virtual void SetAlign(string align, SpriteFont font) { }
        public virtual void LoadContent() { }
        public virtual void Update() { }

        public virtual void FlipHorizontally() { }
        public virtual void FlipVertically() { }
        public virtual void Normal() { }

        public virtual void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
        }

        public virtual void SetTint(Color newTint)
        {
            Tint = newTint;
        }

        public Graphic()
        {
            Origin = new Vector2(0, 0);
            Angle = 0;
            Scale = 1;
            Alpha = 1;
            Tint = Color.White;
            Position = new Vector2(0, 0);
            Layer = 0.5f;
        }
    }
}