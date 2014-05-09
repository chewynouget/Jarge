using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using Jarge_SFML.Util;

namespace Jarge_SFML
{
    /// <summary>
    /// Global Jarge Class. Controls everything.
    /// </summary>
    public class Jarge
    {
        //for FPS
        private static int lastTick;
        private static int lastFrameRate;
        private static int frameRate;

        /// <summary>
        /// Engine instance
        /// </summary>
        public static Engine Engine;
        /// <summary>
        /// Scene instance
        /// </summary>
        public static Scene Scene;
        /// <summary>
        /// Window instance from Engine
        /// </summary>
        public static RenderWindow Window;
        /// <summary>
        /// Camera for our Game.
        /// </summary>
        public static Camera Camera;
        /// <summary>
        /// Global font
        /// </summary>
        public static Font Font = new Font("Content\\CORBEL.ttf");
        /// <summary>
        /// Width and Height of Jarge Scene, defined by Window size.
        /// </summary>
        public static uint Width, Height;
        public static double Build = 0.01;
        public static string BuildName = "Mush Muffin";
        /// <summary>
        /// Get game FPS, Capped at 60.
        /// </summary>
        /// <returns></returns>
        public static int GetFPS()
        {
            if (System.Environment.TickCount - lastTick >= 1000)
            {
                lastFrameRate = frameRate;
                frameRate = 0;
                lastTick = System.Environment.TickCount;
            }
            frameRate++;
            return lastFrameRate;
        }
        /// <summary>
        /// Get distance between two points.
        /// </summary>
        /// <param name="x1">X Point 1</param>
        /// <param name="y1">Y Point 1</param>
        /// <param name="x2">X Point 2</param>
        /// <param name="y2">Y Point 2</param>
        /// <returns>Returns Distance</returns>
        public static float Distance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
        /// <summary>
        /// Get angle Differance
        /// </summary>
        /// <param name="a">Angle 1</param>
        /// <param name="b">Angle 2</param>
        /// <returns>Angle Differance</returns>
        public static float angleDiff(float a, float b)
		{
			float diff = b - a;

			while (diff > 180) { diff -= 360; }
			while (diff <= -180) { diff += 360; }

			return diff;
		}
    }
}
