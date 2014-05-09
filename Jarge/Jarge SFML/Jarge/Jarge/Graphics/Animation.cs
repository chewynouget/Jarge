using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Jarge_SFML.Graphics
{
    public class Animation : Graphic
    {
        Texture tec;
        Sprite sp;

        int Rows;
        int Columns;
        float currentFrame;
        int TotalFrames;
        float animSpeed = .005f;
        bool paused = false;

        public Animation(string path, int rows, int columns, float frameRate=.05f)
        {
            tec = new Texture(new SFML.Graphics.Image(path));
            sp = new Sprite(tec);

            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            TotalFrames = Rows * Columns;
            animSpeed = frameRate;
        }
        public override void Update()
        {
            if (!paused)
            {
                currentFrame += animSpeed;
            }
            if (currentFrame > TotalFrames)
            {
                currentFrame = 0;
            }
            base.Update();
        }
        public override void CenterOrigin()
        {
            sp.Origin = new SFML.Window.Vector2f(sp.TextureRect.Width / 2, 0);
            base.CenterOrigin();
        }
        public override void Draw()
        {
            int width = (int)tec.Size.X / Columns;
            int height = (int)tec.Size.Y / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = (int)currentFrame % Columns;

            IntRect sourceRect = new IntRect(width * column, height * row, width, height);
            sp.TextureRect = sourceRect;

            sp.Color = Tint;
            sp.Position = Position;
            sp.Rotation = Angle;
            sp.Scale = Scale;
            sp.Origin = Origin;
            Update();
            Jarge.Window.Draw(sp);
        }
        public override void SetOrigin(float x, float y)
        {
            sp.Origin = new SFML.Window.Vector2f(x, y);
            base.SetOrigin(x, y);
        }
        public void Play()
        {
            paused = false;
        }
        public void Pause()
        {
            paused = true;
        }
        public void GotoFrame(int frame)
        {
            currentFrame = frame;
        }
    }
}
