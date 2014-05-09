using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace Jarge_SFML.Util
{
    public class Debug
    {
        public static bool Running = false;
        private static List<Text> textToWrite = new List<Text>();

        public static void Start()
        {
            Running = true;
            AddText();
        }
        public static void Stop()
        {
            Running = false;
        }
        private static void AddText()
        {
            Text title = new Text("Jarge DEBUG", Jarge.Font);
            title.Color = Color.Red;
            
            //Text sceneName = new Text("Scene in use : " + Jarge.Scene.Name, Jarge.Font, 12);
            //sceneName.Position = new SFML.Window.Vector2f(0, 64);
            //sceneName.Color = Color.Red;

            AddToDrawQue(title);
            //AddToDrawQue(sceneName);
        }
        private static void AddToDrawQue(Text t)
        {
            textToWrite.Add(t);
        }
        public static void Draw()
        {
            RectangleShape s = new RectangleShape();
            s.Size = new SFML.Window.Vector2f(250, 400);
            s.OutlineThickness = 5;
            s.Position = new SFML.Window.Vector2f(0, 0);
            Jarge.Window.Draw(s);
            for(int i = 0; i < textToWrite.Count; i++)
            {
                Jarge.Window.Draw(textToWrite[i]);
            }
        }
    }
}
