using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace Jarge_SFML.Graphics
{
    public class Image : Graphic
    {
        Texture tec;
        Sprite sp;
        bool SheetReferance;

        public Image(string path)
        {
            tec = new Texture(new SFML.Graphics.Image(path));
            sp = new Sprite(tec);
        }
        public void referanceSheet(IntRect box)
        {
            sp.TextureRect = box;
            SheetReferance = true;
        }
        public override void CenterOrigin()
        {
            if(!SheetReferance)
                Origin = new SFML.Window.Vector2f(tec.Size.X / 2, tec.Size.Y / 2);
            else
                Origin = new SFML.Window.Vector2f(sp.TextureRect.Width / 2, sp.TextureRect.Height / 2);
            base.CenterOrigin();
        }
        public override void SetOrigin(float x, float y)
        {
            if (!SheetReferance)
                Origin = new SFML.Window.Vector2f(x, y);
            else
                Origin = new SFML.Window.Vector2f(sp.TextureRect.Left + x, sp.TextureRect.Top + y);
            base.SetOrigin(x, y);
        }
        public override void Draw()
        {
            sp.Color = Tint;
            sp.Position = Position;
            sp.Rotation = Angle;
            sp.Scale = Scale;
            sp.Origin = Origin;
            Update();

            Jarge.Window.Draw(sp);
        }
    }
}
