using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Xml;

namespace JargeEngine
{
    public class ContentPipeline
    {
        public static Texture2D Texture2D(string image)
        {
            return Jarge.Engine.Content.Load<Texture2D>(image);
        }
        public static SpriteFont SpriteFont(string font)
        {
            return Jarge.Engine.Content.Load<SpriteFont>(font);
        }
        public static SoundEffect SoundEffect(string sound)
        {
            return Jarge.Engine.Content.Load<SoundEffect>(sound);
        }
        public static XmlDocument XmlDoc(string doc)
        {
            return Jarge.Engine.Content.Load<XmlDocument>(doc);
        }
    }
}
