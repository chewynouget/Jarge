using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JargeEngine.Graphics
{
    public class Text : Graphic
    {
        public string text;
        bool centeredOrigin;

        public Text(string newText, float x, float y)
        {
            text = newText;
            Tint = Color.White;
            Position = new Vector2(x, y);
        }
        public Text(string newText)
        {
            text = newText;
        }
        public override void Draw()
        {
            if(!centeredOrigin)
                Engine.SpriteBatch.DrawString(Engine.Font, text, Position, Tint * Alpha, Angle, Origin, Scale, SpriteEffects.None, Layer);
            else
                Engine.SpriteBatch.DrawString(Engine.Font, text, Position, Tint * Alpha, Angle, new Vector2(Engine.Font.MeasureString(text).X / 2, Engine.Font.MeasureString(text).Y / 2), Scale, SpriteEffects.None, Layer);
        }
        public override void CenterOrigin() 
        {
            centeredOrigin = true;
        }
    }
}
