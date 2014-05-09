using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarge_SFML;
using Jarge_SFML.Graphics;
using Jarge_SFML.Util;

namespace Jarge_SFML
{
    public class DemoScene : Scene
    {
        float timer = 0;
        Image logo = new Image("Content\\logo.png");
        Text title = new Text("Welcome to Jarge .1!");

        public DemoScene()
        {
            AddGraphic(logo);
            logo.CenterOrigin();
            logo.Scale = new SFML.Window.Vector2f(2, 2);
            logo.SetPosition(400, 300);

            title.Position.X = 250;
            AddGraphic(title);
        }
        public override void Update()
        {
            timer += 0.09f;
            logo.Angle = (float)Math.Cos(timer);
            base.Update();
        }
        public override void Draw()
        {
            //Render.Rectangle(400, 300, (float)Math.Cos(timer) * 500, (float)Math.Cos(timer) * 500, SFML.Graphics.Color.Blue);
            Render.Rectangle(0, 0, 800, 600, SFML.Graphics.Color.Blue);
            Render.Rectangle(400, 300, (float)Math.Sin(timer) * 500, (float)Math.Cos(timer) * 500, SFML.Graphics.Color.Yellow);
            Render.Rectangle(400, 300, (float)Math.Sin(-timer) * 500, (float)Math.Cos(-timer) * 500, SFML.Graphics.Color.Red);
            base.Draw();
        }
    }
}
