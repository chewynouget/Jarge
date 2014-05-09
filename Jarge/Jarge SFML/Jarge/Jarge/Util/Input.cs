using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Jarge_SFML.Util
{
    public class Input
    {
        public static float MouseX, MouseY;

        public static bool KeyDown(Keyboard.Key key)
        {
            if (Keyboard.IsKeyPressed(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool KeyUp(Keyboard.Key key)
        {
            if (!Keyboard.IsKeyPressed(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool KeyPressed(Keyboard.Key key)
        {
            int g = 0;
            if (g < 1)
            {
                if (KeyDown(key))
                {
                    g = 1;
                    return true;
                }
                else
                {
                    g = 0;
                    return false;
                }
            }
            else
            {
                return false;
            }
            Console.WriteLine(g);
        }
        public static bool MouseDown(SFML.Window.Mouse.Button btn)
        {
            if (Mouse.IsButtonPressed(btn))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Update()
        {
            MouseX = Mouse.GetPosition().X;
            MouseY = Mouse.GetPosition().Y;
        }
    }
}
