using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace Jarge_SFML.Graphics
{
    public class Text : Graphic
    {
        public static Font Font = Jarge.Font;
        public SFML.Graphics.Text text;
        public string Name;
        public static Color Color = Color.White;

        public Text(string name)
        {
            text = new SFML.Graphics.Text(name, Font);
            Name = name;
        }
        public Text(string name, float x, float y)
        {
            text = new SFML.Graphics.Text(name, Font);
            Name = name;
            Position = new SFML.Window.Vector2f(x, y);
        }
        public override void CenterOrigin()
        {
            //text.Origin = new SFML.Window.Vector2f(100, 800);
            base.CenterOrigin();
        }
        public override void Draw()
        {
            text.Color = Tint;
            text.Position = Position;
            text.Rotation = Angle;
            text.Scale = Scale;
            text.Origin = Origin;
            Update();

            Jarge.Window.Draw(text);
        }
    }
}
