using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JargeEngine.Graphics
{
    public class Image : Graphic
    {
        string Path = "";
        Texture2D img;
        bool centeredOrigin = false;
        SpriteEffects sp;

        public Image(string path)
        {
            Path = path;
        }
        public Image(string path, int x, int y)
        {
            Path = path;
            Position = new Vector2(x, y);
        }
        public override void LoadContent()
        {
            img = ContentPipeline.Texture2D(Path);
            sp = SpriteEffects.None;
            base.LoadContent();
        }
        public override void Draw()
        {
            if(!centeredOrigin)
                Engine.SpriteBatch.Draw(img, Position, null, Tint * Alpha, Angle, Origin, Scale, sp, Layer);
            else
                Engine.SpriteBatch.Draw(img, Position, null, Tint * Alpha, Angle, new Vector2(img.Width / 2, img.Height / 2), Scale, sp, Layer);
        }
        public override void Update()
        {

            base.Update();
        }
        public override void CenterOrigin()
        {
            centeredOrigin = true;
        }
        public void Visible(bool f)
        {
            if (f)
            {
                Alpha = Alpha;
            }
            else
            {
                Alpha = 0;
            }
        }
        public override void FlipHorizontally()
        {
            sp = SpriteEffects.FlipHorizontally;
            base.FlipHorizontally();
        }
        public override void FlipVertically()
        {
            sp = SpriteEffects.FlipVertically;
            base.FlipVertically();
        }
        public override void Normal()
        {
            sp = SpriteEffects.None;
            base.Normal();
        }
    }
}
