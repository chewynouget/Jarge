using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JargeEngine.Graphics
{
    public class Animation : Graphic
    {
        public Texture2D Image { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private string Path = "";
        private float currentFrame;
        private int totalFrames;
        public float animSpeed = .25f;
        private bool paused = false;
        private SpriteEffects sp;
        Rectangle destinationRectangle;
        Rectangle sourceRect;

        public Animation(string path, int rows, int columns)
        {
            Path = path;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            sp = SpriteEffects.None;
        }
        public override void LoadContent()
        {
            Image = ContentPipeline.Texture2D(Path);
            base.LoadContent();
        }
        public override void Update()
        {
            if(!paused)
                currentFrame += animSpeed;
            if (currentFrame == totalFrames)
                currentFrame = 0;
            base.Update();
        }
        public override void Draw()
        {
            SetUpThing();
            Engine.SpriteBatch.Draw(Image, Position, sourceRect, Tint * Alpha, Angle, Origin, Scale, sp, Layer);
        }
        public void Play()
        {
            paused = false;
        }
        public void Pause()
        {
            paused = true;
        }
        public void ResetAnimation()
        {
            currentFrame = 0;
        }
        public void GotoFrame(float frame)
        {
            currentFrame = frame;
        }
        public void PlayFrames(int frame1)
        {
            GotoFrame(frame1);
        }
        public override void CenterOrigin()
        {
            Origin = new Vector2(200, 200);
        }
        public override void FlipHorizontally()
        {
            sp = SpriteEffects.FlipHorizontally;
            base.FlipHorizontally();
        }
        public override void FlipVertically()
        {
            sp = SpriteEffects.FlipVertically;
            base.FlipVertically();
        }
        public override void Normal()
        {
            sp = SpriteEffects.None;
            base.Normal();
        }
        private void SetUpThing()
        {
            int width = Image.Width / Columns;
            int height = Image.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = (int)currentFrame % Columns;

            sourceRect = new Rectangle(width * column, height * row, width, height);
            destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);
        }
    }
}