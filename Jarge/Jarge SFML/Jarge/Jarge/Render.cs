using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Jarge_SFML
{
    /// <summary>
    /// Render Must Be called within the scenes Draw() class
    /// </summary>
    public class Render
    {

        public static void Rectangle(float x, float y, float width, float height, Color color)
        {
            RectangleShape shape = new RectangleShape();
            shape.Size = new SFML.Window.Vector2f(width, height);
            shape.FillColor = color;
            shape.Position = new SFML.Window.Vector2f(x, y);
            Jarge.Window.Draw(shape);
        }
        public static void Circle(float x, float y, float radius, Color color)
        {
            CircleShape shape = new CircleShape(radius);
            shape.Position = new SFML.Window.Vector2f(x, y);
            shape.FillColor = color;
            Jarge.Window.Draw(shape);
        }
        public static void Triangle(Vector2f p1, Vector2f p2, Vector2f p3, Color color)
        {
            ConvexShape shape = new ConvexShape();
            shape.FillColor = color;
            shape.SetPointCount(3);
            shape.SetPoint(0, p1);
            shape.SetPoint(1, p2);
            shape.SetPoint(2, p3);
            Jarge.Window.Draw(shape);
        }
        public static void Pixel(float x, float y, Color color)
        {
            CircleShape shape = new CircleShape(2);
            shape.Position = new SFML.Window.Vector2f(x, y);
            shape.FillColor = color;
            Jarge.Window.Draw(shape);
        }
        public static void Hitbox(Entity ent, Color color)
        {
            RectangleShape shape = new RectangleShape();
            shape.Size = new SFML.Window.Vector2f(ent.hitbox.Width, ent.hitbox.Height);
            shape.FillColor = color;
            shape.Position = new SFML.Window.Vector2f(ent.Position.X, ent.Position.Y);
            Jarge.Window.Draw(shape);
        }
    }
}
