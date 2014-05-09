using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Jarge_SFML
{
    public class Button
    {
        Vector2f Position;
        Vector2i Size;

        public Button(float x, float y, int width, int height)
        {
            Size = new Vector2i(width, height);
            Position = new Vector2f(x, y);
        }
    }
}
