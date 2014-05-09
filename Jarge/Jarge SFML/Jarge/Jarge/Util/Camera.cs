using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jarge_SFML.Util
{
    public class Camera
    {
        View camera;

        public void Init()
        {
            camera = new View(new Vector2f(0, 0), new Vector2f(Jarge.Width, Jarge.Height));
            Jarge.Camera = this;
        }
        public void Rotate(float rot)
        {
            camera.Rotate(rot);
        }
    }
}
