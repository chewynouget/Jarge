using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace JargeEngine
{
	public static class Render
    {
        static Color _color = Color.White;
        static BasicEffect effect;
        static VertexPositionColor[] vertices;

        public static void Begin()
        {
            Jarge.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullNone);

            effect = new BasicEffect(Jarge.Graphics);
            effect.VertexColorEnabled = true;
            effect.Projection = Matrix.CreateOrthographicOffCenter(0, Jarge.Width, Jarge.Height, 0, 0, 1);
        }
        public static void End()
        {
            Jarge.SpriteBatch.End();
        }
        public static void Rectangle(int x, int y, int width, int height, bool outline=false)
        {
            vertices = new VertexPositionColor[4];
            vertices[0] = new VertexPositionColor(new Vector3(x, y, 0), Color.Blue);
            vertices[1] = new VertexPositionColor(new Vector3(x + width, y, 0), Color.Blue);
            vertices[2] = new VertexPositionColor(new Vector3(x, y + -height, 0), Color.Blue);
            vertices[3] = new VertexPositionColor(new Vector3(x + width, y + height, 0), Color.Blue);

            effect.CurrentTechnique.Passes[0].Apply();
            Jarge.Graphics.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, vertices, 0, 2);
        }
        public static void SetColor(Color color)
        {
            _color = color;
        }
	}
}
