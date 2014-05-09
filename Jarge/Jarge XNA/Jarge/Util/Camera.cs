using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JargeEngine.Util
{
    public class Camera : Component
    {
        protected float _viewPortHeight;
        protected float _viewPortWidth;

        public Camera()
        {

        }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }
        public Vector2 ScreenCenter { get; protected set; }
        public Matrix Transform { get; set; }
        public float MoveSpeed { get; set; }
        public void Init()
        {
            _viewPortWidth = Jarge.Graphics.Viewport.Width;
            _viewPortHeight = Jarge.Graphics.Viewport.Height;
            ScreenCenter = new Vector2(_viewPortWidth / 2, _viewPortHeight / 2);
            Scale = 1;
            MoveSpeed = 1.25f;
        }
        public override void Update()
        {
            Transform = Matrix.Identity *
                Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateTranslation(Origin.X, Origin.Y, 0) *
                Matrix.CreateScale(new Vector3(Scale, Scale, Scale));

            Origin = ScreenCenter / Scale;

            var delta = (float)Engine.GameTime.ElapsedGameTime.TotalSeconds;
            base.Update();
        }
        public void SetPosition(int x, int y)
        {
            Position = new Vector2(x, y);
        }
    }
}
