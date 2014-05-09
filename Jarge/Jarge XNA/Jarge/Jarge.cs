using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JargeEngine.Util;
using JargeEngine.Utils;

namespace JargeEngine
{
    public class Jarge
    {
        public static Engine Engine;
        public static Scene Scene;
        public static JInput Input;
        public static int Width;
        public static int Height;
        public static bool Paused;
        public static float FrameRate;
        public static bool FullScreen = false;
        public static GraphicsDevice Graphics;
        public static Camera Camera = Engine.camera;
        public static SpriteBatch SpriteBatch;

        public static Scene GetScene()
        {
            return Jarge.Scene;
        }
        public static string GetTitle()
        {
            return Engine.Window.Title;
        }

        public static string GetFPS()
        {
            return FrameRate.ToString();
        }
        public static int GetRandomFromList(List<int> list)
        {
            Random r = new Random();
            int f = r.Next(list.Count);
            return f;
        }
        public static float FaceMouse(Vector2 pos)
        {
            Vector2 mousePos = new Vector2(JInput.MouseX, JInput.MouseY);
            Vector2 dir = mousePos - pos;
            float angle = (float)(Math.Atan2(dir.Y, dir.X));
            return angle;
        }
        public static float GetDistance(Vector2 p1, Vector2 p2)
        {
            return Vector2.Distance(p1, p2);
        }
    }
}
