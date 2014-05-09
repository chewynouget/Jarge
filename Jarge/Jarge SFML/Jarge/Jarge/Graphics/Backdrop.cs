using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace Jarge_SFML.Graphics
{
    public class Backdrop : Graphic
    {
        Texture tec;
        Sprite sp;

        public Backdrop(string path)
        {
            tec = new Texture(new SFML.Graphics.Image(path));
            sp = new Sprite(tec);
        }
        public override void Draw()
        {
            sp.Color = Tint;
            sp.Position = Position;
            sp.Rotation = Angle;
            sp.Scale = Scale;
            sp.Origin = Origin;
            tec.Repeated = true;
            Update();

            Jarge.Window.Draw(sp);
        }
    }
}
