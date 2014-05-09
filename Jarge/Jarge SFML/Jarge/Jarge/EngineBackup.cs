using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using Jarge_SFML.Util;
using Jarge_SFML;

namespace Jarge_SFML
{
    public class Engine
    {
        RenderWindow window;
        public Scene scene;
        public Scene sceneToSet;

        //edit class to handle proper framerate. as oppose to 1200, have 60.

        public Engine(Scene _scene = null, uint width = 800, uint height = 600, string title = "Jarge", Styles style = Styles.Close)
        {
            window = new RenderWindow(new VideoMode(width, height), title, style);
            window.Closed += new EventHandler(OnClosed);
            //window.SetFramerateLimit(60);

            Jarge.Engine = this;
            Jarge.Window = this.window;
            Jarge.Width = Jarge.Window.Size.X;
            Jarge.Height = Jarge.Window.Size.Y;

            SetIcon();
            SetSize(width, height);
            SetScene(_scene);

            while (window.IsOpen())
            {
                Update();
            }
        }

        public virtual void Update()
        {
            window.DispatchEvents();

            window.Clear();

            if (Input.KeyDown(Keyboard.Key.Escape))
                window.Close();

            Input.Update();

            //window.Draw(new Text("Hello, World!", new Font("Content\\CORBEL.TTF")));

            if (scene == null)
                scene = sceneToSet;
            else
                scene.Update();

            window.Display();
        }
        public void SetTitle(string title)
        {
            window.SetTitle(title);
        }
        public void SetSize(uint width, uint height)
        {
            window.Size = new Vector2u(width, height);
        }
        public void SetScene(Scene _scene)
        {
            sceneToSet = scene;
        }
        public void SetIcon(string path = "Content\\icon.png")
        {
            Image image = new Image(path);
            window.SetIcon(32, 32, image.Pixels);
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