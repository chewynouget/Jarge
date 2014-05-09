using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JargeEngine;
using JargeEngine.Graphics;
using Microsoft.Xna.Framework;

namespace JargeTest
{
    class GameScene : Scene
    {
        public static Entity WALL;

        public GameScene()
        {
            Add(new Player());
            Add(new Wall(0, 200));
            WALL = entities[1];
        }
        public override void Update()
        {
            base.Update();
        }
    }
}
