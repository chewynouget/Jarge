using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JargeEngine.Graphics
{
    public class Backdrop : Graphic
    {
        string Path = "";
        Texture2D img;

        public Backdrop(string path)
        {
            Path = path;
            Layer = 0.9f;
        }
        public override void LoadContent()
        {
            img = ContentPipeline.Texture2D(Path);
            base.LoadContent();
        }
        public override void Draw()
        {
            for (int i = 0; i < Jarge.Scene.Width / 30; i++)
            {
                for (int j = 0; j < Jarge.Scene.Height / 30; j++)
                {
                    Engine.SpriteBatch.Draw(img, new Vector2(i * img.Width, j * img.Height), null, Tint * Alpha, Angle, Origin, Scale, SpriteEffects.None, Layer);
                }
            }
        }
    }
}
