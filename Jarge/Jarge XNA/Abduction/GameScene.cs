using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JargeEngine;
using JargeEngine.Graphics;

namespace Abduction
{
    public class GameScene : Scene
    {
        public GameScene()
        {
            AddGraphic(new Text("Hello Jarge"));
            Add(new Player());
            Add(new Pointer());
            Zoom = 2;
        }
    }
}
