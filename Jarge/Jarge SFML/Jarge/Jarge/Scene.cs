using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarge_SFML.Util;
using Jarge_SFML.Graphics;
using SFML.Window;
using SFML.Graphics;

namespace Jarge_SFML
{
    public class Scene
    {
        public List<Entity> Entities = new List<Entity>();
        public List<Graphic> Graphics = new List<Graphic>();
        public int Zoom = 1;

        public Scene()
        {
            //AddGraphic(new Jarge_SFML.Graphics.Text("TEdn"));
        }
        public virtual void Draw()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Draw();
            }
            for (int d = 0; d < Graphics.Count; d++)
            {
                Graphics[d].Draw();
            }
        }
        public virtual void Update()
        {
            Draw();
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Update();
            }
            for (int d = 0; d < Graphics.Count; d++)
            {
                Graphics[d].Update();
            }
        }
        public void Add(Entity ent)
        {
            Entities.Add(ent);
        }
        public void Remove(Entity ent)
        {
            Entities.Remove(ent);
        }
        public void AddGraphic(Graphic graphic)
        {
            Graphics.Add(graphic);
        }
        public void RemoveGraphic(Graphic graphic)
        {
            Graphics.Remove(graphic);
        }
        public void RemoveAll()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities.Remove(Entities[i]);
            }
            for (int d = 0; d < Graphics.Count; d++)
            {
                Graphics.Remove(Graphics[d]);
            }
        }
    }
}
