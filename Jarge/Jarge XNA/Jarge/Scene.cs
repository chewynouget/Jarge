using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Media;
using JargeEngine.Graphics;
using JargeEngine.Util;

namespace JargeEngine
{
    public class Scene
    {
        public List<Entity> entities = new List<Entity>();
        public List<Graphic> graphics = new List<Graphic>();
        public List<GUIComponent> gui = new List<GUIComponent>();
        public Dictionary<string, List<Entity>> tagBook = new Dictionary<string,List<Entity>>();

        public int Width { get; set; }
        public int Height { get; set; }
        public int Zoom = 1;

        public Color _bgColor = Color.Black;

        public Scene()
        {
            this.Width = Jarge.Width;
            this.Height = Jarge.Height;

            Console.WriteLine("Scene Added!\n");
        }
        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="ent"></param>
        public void Add(Entity ent)
        {
            entities.Add(ent);
            Console.WriteLine("Entity Added! " + "\n[INFO]" + ent.Info + "\n");
        }

        /// <summary>
        /// Remove Entity
        /// </summary>
        /// <param name="ent"></param>
        public void Remove(Entity ent)
        {
            entities.Remove(ent);
            ent.Remove();
            ent.scene = null;
            Console.WriteLine("Entity Removed!");
        }
        public bool Contains(Entity ent)
        {
            return this.entities.Contains(ent);
        }
        public void AddGraphic(Graphic g)
        {
            graphics.Add(g);
        }

        public void RemoveGraphic(Graphic g)
        {
            graphics.Remove(g);
        }

        public virtual void Update()
        {
            if (!Jarge.Paused)
            {
                UpdateGraphics();
                UpdateSprites();
            }
        }

        public void LoadContent()
        {
            for (int i = 0; i < graphics.Count; i++)
            {
                graphics[i].LoadContent();
            }
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].LoadContent();
            }
        }

        public virtual void Draw()
        {
            Jarge.Graphics.Clear(_bgColor);
            DrawEntities();
            DrawGraphics();
            DrawButtons();
        }

        public void UpdateSprites()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update();
            }
        }

        public void UpdateGraphics()
        {
            for (int i = 0; i < graphics.Count; i++)
            {
                graphics[i].Update();
            }
        }

        public void DrawEntities()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw();
            }
        }

        public void DrawGraphics()
        {
            for (int i = 0; i < graphics.Count; i++)
            {
                graphics[i].Draw();
                graphics[i].Scale = Zoom;
            }
        }

        public void SetBackgroundColor(Color _col)
        {
            _bgColor = _col;
        }

        public void AddButton(Button butt)
        {
            gui.Add(butt);
        }
        public void DrawButtons()
        {
            for (int i = 0; i < gui.Count; i++)
            {
                gui[i].Draw();
            }
        }
    }
}
