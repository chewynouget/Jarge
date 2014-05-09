#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using JargeEngine;
#endregion

namespace JargeTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Engine
    {
        public Game1()
            : base("Thing foo")
        {
            SetScene(new GameScene());
        }
    }
}
