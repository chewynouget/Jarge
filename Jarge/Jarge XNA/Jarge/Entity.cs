using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using JargeEngine.Graphics;
using JargeEngine.Colliders;
using JargeEngine.Utils;

namespace JargeEngine
{
    public class Entity : Component
    {
        public string Info = "";
        private string Tag = "";

        public Vector2 Speed;
        public Vector2 Friction = new Vector2(.95f, .95f);
        public Vector2 Origin = new Vector2(0,0);

        public int Width;
        public int Height;

        public List<Graphic> graphics = new List<Graphic>();
        public Scene scene;
        public Collider Collider;

        public Entity(int x, int y, bool active=true, bool visible=true)
        {
            scene = Jarge.Scene;
            SetPosition(x, y);
            this.Visible = visible;
            this.Active = active;
        }
        public override void Begin()
        {
            base.Begin();
        }
        public override void Remove()
        {
            if (scene != null) scene.Remove(this);
            base.Remove();
        }
        public void AddGraphic(Graphic g)
        {
            graphics.Add(g);
        }
        public void RemoveGraphic(Graphic g)
        {
            graphics.Remove(g);
        }
        public void AddInfo(string addInfo)
        {
            Info += "\n" + addInfo + "\n";
        }
        public void AddTag(string tag)
        {
            this.Tag += tag;
            AddInfo(tag);
        }
        public override void Update()
        {
            if (Active)
            {
                Position.X += Speed.X;
                Position.Y += Speed.Y;

                Speed.X *= Friction.X;
                Speed.Y *= Friction.Y;
                for (int i = 0; i < graphics.Count; i++)
                {
                    graphics[i].Update();
                    graphics[i].Position = this.Position;
                    graphics[i].Origin = this.Origin;
                }
                if (Collider != null)
                {
                    Collider.Update();
                }
            }
            base.Update();
        }
        public void LoadContent()
        {
            for (int i = 0; i < graphics.Count; i++)
            {
                graphics[i].LoadContent();
                graphics[i].Scale = Jarge.Scene.Zoom * graphics[i].Scale;
            }
        }
        public virtual void Draw()
        {
            if (Visible)
            {
                for (int i = 0; i < graphics.Count; i++)
                {
                    graphics[i].Draw();
                }
            }
        }
        public void Move(float x, float y)
        {
            Speed.X += x;
            Speed.Y += y;
        }
        public void SetOrigin(float x, float y)
        {
            Origin = new Vector2(x, y);
        }
        /// <summary>
        /// Hitbox must be made before this function can be called.
        /// </summary>
        public void CenterOrigin()
        {
            Origin = new Vector2(Width / 2, Height / 2);
        }
        public void Wrap()
        {
            if (Position.X > Jarge.Width)
                Position.X = 0;
            if (Position.X < 0)
                Position.X = Jarge.Width;
        }
        public void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
        }
        public void SetHitbox(float width, float height)
        {
            Collider = new Hitbox(width, height, (int)Position.X, (int)Position.Y);
            Collider.AssignTo(this);
        }
        public bool Collide(Entity ent)
        {
            if (Collider is Hitbox)
                return Collider.Collide(ent.Collider);
            else
                return false;
        }
        public bool Collide(string tag)
        {
            for (int i = 0; i < Jarge.Scene.entities.Count; i++)
            {
                if (Jarge.Scene.entities[i].Tag == tag)
                {
                    return Jarge.Scene.entities[i].Collide(this);
                }
            }
            return false;
        }
        public void MoveTowardsPoint(float posX, float posY, float speed)
        {
            Vector2 dir = new Vector2(posX, posY) - Position;
            dir.Normalize();

            Position += dir * speed;
        }
    }
}
