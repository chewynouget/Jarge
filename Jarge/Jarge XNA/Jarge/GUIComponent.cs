using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using JargeEngine.Graphics;

namespace JargeEngine
{
    public class GUIComponent
    {
        public Vector2 Position = default(Vector2);
        public string Name = "";
        public bool Visible = true;
        public bool Active = true;
        public float Rotation;
        public List<Graphic> graphics = new List<Graphic>();

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
        public virtual void Draw()
        {
            for (int i = 0; i < graphics.Count; i++)
            {
                graphics[i].Draw();
            }
        }
        public void AddGraphic(Graphic g)
        {
            graphics.Add(g);
        }
        public void RemoveGraphic(Graphic g)
        {
            graphics.Remove(g);
        }
    }
}
