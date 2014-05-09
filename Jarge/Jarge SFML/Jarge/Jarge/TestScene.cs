using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarge_SFML;
using Jarge_SFML.Graphics;
using SFML.Graphics;
using Jarge_SFML.Util;

namespace Jarge_SFML
{
    public class TestScene : Scene
    {
        Entity ent1 = new Entity(300, 100);
        Entity ent2 = new Entity(300, 300);
        Entity MoveEnt = new Entity(100, 100);
        float timer = 0;

        public TestScene()
        {
            AddGraphic(new Jarge_SFML.Graphics.Image("Content//player.png"));
            Animation anim = new Animation("Content//player.png", 1, 5);
            anim.Position.Y = 32;
            AddGraphic(anim);
            AddGraphic(new Jarge_SFML.Graphics.Text("Animation!", 0, 64));

            ent1.SetHitbox(32, 32);
            Add(ent1);
            ent2.SetHitbox(32, 32);
            Add(ent2);

            MoveEnt.SetHitbox(64, 64);
            MoveEnt.AddGraphic(new Animation("Content\\je.jpg", 5, 5, .002f));
            Add(MoveEnt);

            AddGraphic(new Jarge_SFML.Graphics.Text("Collision", 348, 200));
        }
        public override void Update()
        {
            if (!ent1.Collide(ent2))
            {
                ent1.Move(0, .07f);
            }
            else
            {
                if(ent1.Position.Y > 100)
                    ent1.Move(0, -100);
            }
            if (Input.KeyDown(SFML.Window.Keyboard.Key.Right))
                MoveEnt.Move(2, 0);
            if (Input.KeyDown(SFML.Window.Keyboard.Key.Left))
                MoveEnt.Move(-2, 0);
            if (Input.KeyDown(SFML.Window.Keyboard.Key.Up))
                MoveEnt.Move(0, -2);
            if (Input.KeyDown(SFML.Window.Keyboard.Key.Down))
                MoveEnt.Move(0, 2);

            timer += 0.009f;
            MoveEnt.graphics[0].CenterOrigin();
            MoveEnt.graphics[0].Angle = (float)Math.Cos(timer) * 5;
            base.Update();
        }
        public override void Draw()
        {
            Render.Hitbox(ent1, Color.White);
            Render.Hitbox(ent2, Color.White);
            Render.Circle(200, 400, 40, Color.Red);
            Render.Triangle(new SFML.Window.Vector2f(-32, 0), new SFML.Window.Vector2f(200, 400), new SFML.Window.Vector2f(250, 30), Color.Blue);
            Render.Pixel(600, 100, SFML.Graphics.Color.Blue);
            Render.Rectangle(600, 300, 100, 100, Color.Yellow);
            base.Draw();
        }
    }
}
