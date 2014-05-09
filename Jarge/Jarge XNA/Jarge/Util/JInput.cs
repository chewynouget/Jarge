using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace JargeEngine.Utils
{
    public class JInput
    {
        public static int MouseX = Mouse.GetState().X;
        public static int MouseY = Mouse.GetState().Y;

        public static float Right = 0.5f;
        public static float Left = -0.5f;

        public static bool KeyDown(Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key))
            {
                return true;
            }
            else
                return false;
        }
        public static bool KeyUp(Keys key)
        {
            if (Keyboard.GetState().IsKeyUp(key))
            {
                return true;
            }
            else
                return false;
        }

        static KeyboardState curState;
        static KeyboardState oldState;

        public static bool KeyPressed(Keys key)
        {
            oldState = curState;
            curState = Keyboard.GetState();

            if (curState.IsKeyDown(key) && oldState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
        static bool mousePressed = false;
        public static bool LeftMouseDown()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                return true;
            else
            {
                mousePressed = false;
                return false;
            }
        }
        public static bool RightMouseDown()
        {
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                return true;
            else
                return false;
        }
        public static bool MousePressed()
        {
            if (LeftMouseDown() && !mousePressed)
            {
                mousePressed = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        /*public static bool GamePadStickHorizontal(string Joystick, PlayerIndex player)
        {
            if (Joystick == "Left" || Joystick == "left")
            {
                if (GamePad.GetState(player).ThumbSticks.Left.X > Right)
                    return true;
                if (GamePad.GetState(player).ThumbSticks.Left.X < Left)
                    return true;
            }
            if (Joystick == "Right" || Joystick == "right")
            {
                if (GamePad.GetState(player).ThumbSticks.Right.X > Right)
                    return true;
                if (GamePad.GetState(player).ThumbSticks.Right.X < Left)
                    return true;
            }
            return false;
        }
        public static bool GamePadStickVertical(string Joystick, PlayerIndex player)
        {
            if (Joystick == "Left" || Joystick == "left")
            {
                if (GamePad.GetState(player).ThumbSticks.Left.Y > Right)
                    return true;
                if (GamePad.GetState(player).ThumbSticks.Left.Y < Left)
                    return true;
            }
            if (Joystick == "Right" || Joystick == "right")
            {
                if (GamePad.GetState(player).ThumbSticks.Right.Y > Right)
                    return true;
                if (GamePad.GetState(player).ThumbSticks.Right.Y < Left)
                    return true;
            }
            return false;
        }*/
        public static bool GamePadButtonDown(Buttons btn, PlayerIndex player)
        {
            if (GamePad.GetState(player).IsButtonDown(btn))
                return true;
            else return false;
        }
        public static void Update()
        {
            MouseX = Mouse.GetState().X;
            MouseY = Mouse.GetState().Y;
        }
    }
}
