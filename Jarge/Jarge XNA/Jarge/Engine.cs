using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using JargeEngine.Utils;
using JargeEngine.Util;

namespace JargeEngine
{
    public class Engine : Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch SpriteBatch;
        public static GameTime GameTime;
        public static Scene scene;
        
        public static SpriteFont Font;
        public static Color GameColor = Color.Black;
        public static Camera camera;

        public static bool EscapeCloses = true;
        public bool ShowMouse = true;
        public bool Resizable = false;
        public bool Fullscreen = false;
        public static float FrameRate;

        public Engine(string title=null, int width=800, int height=450)
        {
            graphics = new GraphicsDeviceManager(this);
            SetContentRootDirectory("Content");

            SetWindowSize(width, height);

            Jarge.Engine = this;
            Jarge.Graphics = GraphicsDevice;
            IsFixedTimeStep = false;

            camera = new Camera();
            camera.Init();
            Jarge.Camera = camera;

            Jarge.Input = new JInput();

            Console.WriteLine("Jarge has Initilized");

            if (title == null)
            {
                title = Window.Title;
            }
            else
            {
                SetTitle(title); 
            }
        }
        /// <summary>
        /// Loads our games content.
        /// </summary>
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Jarge.SpriteBatch = SpriteBatch;
            Font = ContentPipeline.SpriteFont("font");

            if (scene == null)
            {
                throw new Exception("No scene to load! Use SetScene() to set scene!");
            }
            else
            {
                scene.LoadContent();
            }

            base.LoadContent();
        }
        /// <summary>
        /// Set the Content Directory our Game info will be taken from.
        /// </summary>
        /// <param name="rootDirectory">Directory to take from</param>
        public void SetContentRootDirectory(string rootDirectory)
        {
            Content.RootDirectory = rootDirectory;
        }

        protected override void Update(GameTime gameTime)
        {
            if (JInput.KeyDown(Keys.Escape))
            {
                if (EscapeCloses)
                    Exit();
            }

            JInput.Update();
            
            if (!Jarge.Paused)
                scene.Update();

            Window.AllowUserResizing = Resizable;
            IsMouseVisible = ShowMouse;
            Jarge.FrameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            GameTime = gameTime;
            camera.Update();
            base.Update(gameTime);
        }
        /// <summary>
        /// Draws everything
        /// </summary>
        /// <param name="gameTime">Time is updates (only available in Engine Class)</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(GameColor);
            //SpriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, camera.Transform);
            Render.Begin();

            scene.Draw();

            Render.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// Set Window Size. Default is 800x450
        /// </summary>
        /// <param name="width">Width of window</param>
        /// <param name="height">Height of window</param>
        public void SetWindowSize(int width, int height)
        {
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.ApplyChanges();

            Jarge.Width = width;
            Jarge.Height = height;

            Console.WriteLine("Window Width = " + Jarge.Width);
            Console.WriteLine("Window Height = " + Jarge.Height + "\n");
        }
        public void SetFullscreen(bool isF)
        {
            Fullscreen = isF;
            graphics.IsFullScreen = Fullscreen;
        }
        /// <summary>
        /// Set Window Title
        /// </summary>
        /// <param name="title">Window Title</param>
        public void SetTitle(string title)
        {
            Window.Title = title;
        }
        /// <summary>
        /// The scene our game will take place in. This can be used anywhere, including transitions.
        /// </summary>
        /// <param name="s"></param>
        public void SetScene(Scene s)
        {
            scene = s;
            Jarge.Scene = scene;
        }
        public static void ChangeScene(Scene s)
        {
            scene = s;
            Jarge.Scene = scene;
        }
        /// <summary>
        /// Set the font to be used [[EXPERIMENTAL]]
        /// </summary>
        /// <param name="font">Font to load</param>
        public void SetFont(string font)
        {
            Font = ContentPipeline.SpriteFont(font);
        }
        /// <summary>
        /// If the window is resizable
        /// </summary>
        /// <param name="f">Should the window resize?</param>
        public void SetResizable(bool f)
        {
            Resizable = f;
        }
    }
}
