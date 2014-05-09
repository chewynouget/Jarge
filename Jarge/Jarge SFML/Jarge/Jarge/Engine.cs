using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using Jarge_SFML.Util;
using Jarge_SFML;
using System.Collections.Generic;

namespace Jarge_SFML
{
    public class Engine
    {
        public RenderWindow window;
        public Scene scene;
        public Camera camera;
        SFML.Graphics.Image icon;

        public Engine(uint width = 800, uint height = 600, string title = "Jarge", Styles style = Styles.Close)
        {
            window = new RenderWindow(new VideoMode(width, height), title, style);
            window.Closed += new EventHandler(OnClosed);
            window.SetFramerateLimit(60);
        }
        public virtual void Start(Scene scene)
        {
            this.scene = scene;
            Jarge.Scene = this.scene;

            Jarge.Window = window;
            window.SetTitle("Jarge v.0.1 \"Mush Muffin\"");
            /*icon = new Image("Content\\icon");
            window.SetIcon(32, 32, icon.Pixels);*/

            camera = new Camera();
            camera.Init();
            Jarge.Camera = camera;

            while (window.IsOpen())
            {
                Update();
            }
        }
        public virtual void Update()
        {
            window.DispatchEvents();
            window.Clear();
            if (scene == null)
            {
                scene = new DemoScene();
            }
            else
            {
                scene.Update();
            }
            window.Display();
        }
        static void OnClosed(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
            Environment.Exit(1);
        }
        static void Main(string[] args)
        {
            Engine e = new Engine();
        }
    }
}