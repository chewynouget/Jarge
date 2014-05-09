using JargeEngine;
using JargeEngine.Graphics;
using JargeEngine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JargeEngine.Util
{
    public class Button : GUIComponent
    {
        public float width;
        public float height;
        public Image image;

        public Button(int x, int y)
            : base()
        {
            image = new Image("aaron");
            image.Position = this.Position;
            AddGraphic(image);
        }
        public bool Clicked()
        {
            if (Over() && JInput.MousePressed())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Over()
        {
            if (JInput.MousePressed())
            {
                if (JInput.MouseX < Position.X + width && JInput.MouseX > this.Position.X)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override void Draw()
        {
            image.Draw();
            base.Draw();
        }
    }
}
