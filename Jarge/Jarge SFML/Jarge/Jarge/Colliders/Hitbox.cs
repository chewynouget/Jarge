using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Jarge_SFML.Colliders
{
    public class Hitbox : Collider
    {
        public Hitbox(int width, int height, int offsetX = 0, int offsetY = 0)
            : base()
        {
            Width = width;
            Height = height;
            X = offsetX;
            Y = offsetY;

            _check[typeof(Hitbox).Name] = CollideHitbox;
        }

        protected override bool CollideMask(Collider other)
        {
            return Parent.Position.X + _x + _width > other.Parent.Position.X - other.Parent.Origin.X
                && Parent.Position.Y + _y + _height > other.Parent.Position.Y - other.Parent.Origin.Y
                && Parent.Position.X + _x < other.Parent.Position.X - other.Parent.Origin.X + other.Parent.Width
                && Parent.Position.Y + _y < other.Parent.Position.Y - other.Parent.Origin.Y + other.Parent.Height;
        }

        protected virtual bool CollideHitbox(Collider other)
        {
            //	cast required because C# is bad at contravariance
            var hitbox = other as Hitbox;

            return Parent.Position.X + _x + _width > hitbox.Parent.Position.X + hitbox._x - 5
                && Parent.Position.Y + _y + _height > hitbox.Parent.Position.Y + hitbox._y - 5
                && Parent.Position.X + _x < hitbox.Parent.Position.X + hitbox._x + hitbox._width
                && Parent.Position.Y + _y < hitbox.Parent.Position.Y + hitbox._y + hitbox._height;
        }

        public override bool CollideTag(string tag)
        {
            for (int i = 0; i < Jarge.Scene.Entities.Count; i++)
            {
                if (Jarge.Scene.Entities[i].Tag == tag)
                {
                    if(CollideHitbox(Jarge.Scene.Entities[i].hitbox))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override void Update()
        {
            if (Parent != null)
            {
                // update entity bounds
                Parent.Origin.X = -_x;
                Parent.Origin.Y = -_y;
                Parent.Width = _width;
                Parent.Height = _height;
            }
        }

        /// <summary>
        /// X offset.
        /// </summary>
        public int X
        {
            get { return _x; }
            set
            {
                if (_x == value) return;
                _x = value;
                if (Parent != null) Update();
            }
        }

        /// <summary>
        /// Y offset.
        /// </summary>
        public int Y
        {
            get { return _y; }
            set
            {
                if (_y == value) return;
                _y = value;
                if (Parent != null) Update();
            }
        }

        /// <summary>
        /// Width of the hitbox.
        /// </summary>
        public int Width
        {
            get { return _width; }
            set
            {
                if (_width == value) return;
                _width = value;
                if (Parent != null) Update();
            }
        }

        /// <summary>
        /// Height of the hitbox.
        /// </summary>
        public int Height
        {
            get { return _height; }
            set
            {
                if (_height == value) return;
                _height = value;
                if (Parent != null) Update();
            }
        }

        protected internal int _width;
        protected internal int _height;
        protected internal int _x;
        protected internal int _y;
    }
}
