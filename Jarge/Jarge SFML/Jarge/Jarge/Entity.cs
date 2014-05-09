using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarge_SFML.Graphics;
using SFML.Window;
using Jarge_SFML.Colliders;

namespace Jarge_SFML
{
    public class Entity
    {
        public List<Graphic> graphics = new List<Graphic>();
        public Vector2f Position;
        public Vector2f Origin;
        public Vector2f Velocity = new Vector2f(0,0);
        public Vector2f Friction = new Vector2f(85f, 85f);
        public Vector2f Speed;
        public Hitbox hitbox;
        public int Width, Height;
        public float X, Y;
        public string Tag;

        public Entity(float x, float y)
        {
            Console.WriteLine("Entity Added : " + this);
            SetPosition(x, y);
        }
        public virtual void Draw()
        {
            for (int i = 0; i < graphics.Count; i++)
            {
                graphics[i].Draw();
            }
        }
        public virtual void Update()
        {
            for (int i = 0; i < graphics.Count; i++)
            {
                graphics[i].Update();
                graphics[i].Position = this.Position;
            }
            Velocity.X *= Friction.X;
            Velocity.Y *= Friction.Y;
            Position.X += Speed.X;
            Position.Y += Speed.Y;
        }
        public virtual void Move(float x, float y)
        {
            Speed = new Vector2f(Speed.X + x, Speed.Y + y);
        }
        public void SetPosition(float x, float y)
        {
            Position = new Vector2f(x, y);
        }
        public void AddGraphic(Graphic g)
        {
            graphics.Add(g);
        }
        public void RemoveGraphic(Graphic g)
        {
            graphics.Remove(g);
        }
        public void SetHitbox(int width, int height)
        {
            hitbox = new Hitbox(width, height);
            hitbox.AssignTo(this);
            this.Width = hitbox.Width;
            this.Height = hitbox.Height;
        }
        public void CenterOrigin()
        {
            Origin = new Vector2f(hitbox.Width / 2, hitbox.Height / 2);
        }
        public void SetOrigin(Vector2f pos)
        {
            Origin = new Vector2f(pos.X, pos.Y);
        }
        public bool Collide(Entity ent)
        {
            return hitbox.Collide(ent.hitbox);
        }
        public bool Collide(string name)
        {
            return hitbox.CollideTag(name);
        }
    }
}