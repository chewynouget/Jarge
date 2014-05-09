using System;
using System.Collections.Generic;
using System.Diagnostics;
using Jarge_SFML;

namespace Jarge_SFML.Colliders
{
    /// <summary>
    /// Base class for Entity collision Colliders.
    /// </summary>
    public class Collider
    {
        /// <summary>
        /// The Parent entity of this Collider.
        /// </summary>
        public Entity Parent;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Collider()
        {
            _class = GetType().Name;
            _check = new Dictionary<string, ColliderCallback>();

            _check[typeof(Collider).Name] = CollideMask;
        }

        /// <summary>
        /// Check for collision with another Collider.
        /// </summary>
        /// <param name="other">The other Collider to check against.</param>
        /// <returns>If the Colliders overlap.</returns>
        public virtual bool Collide(Collider other)
        {
            if (Parent == null)
                throw new Exception("Collider must be attacked to an Entity.");

            //	Check local handler first
            if (_check.ContainsKey(other._class))
                return _check[other._class](other);

            //	Check other Collider for a handler
            if (other._check.ContainsKey(_class))
                return other._check[_class](this);

            return false;
        }

        /// <summary>
        /// Collide against an Entity.
        /// </summary>
        protected virtual bool CollideMask(Collider other)
        {
            return Parent.Position.X - Parent.Origin.X + Parent.Width > other.Parent.Position.X - other.Parent.Origin.X
                && Parent.Position.Y - Parent.Origin.Y + Parent.Height > other.Parent.Position.Y - other.Parent.Origin.Y
                && Parent.Position.X - Parent.Origin.X < other.Parent.Position.X - other.Parent.Origin.X + other.Parent.Width
                && Parent.Position.Y - Parent.Origin.Y < other.Parent.Position.Y - other.Parent.Origin.Y + other.Parent.Height;
        }

        /// <summary>
        ///	Collide against a Colliderlist.
        /// </summary>
        protected virtual bool CollideColliderlist(Collider other)
        {
            return other.Collide(this);
        }

        public virtual bool CollideTag(string tag)
        {
            for (int i = 0; i < Jarge.Scene.Entities.Count; i++)
            {
                if (Jarge.Scene.Entities[i].Tag == tag)
                {
                    return Collide(Jarge.Scene.Entities[i].hitbox);
                }
            }
            return true;
        }

        /// <summary>
        /// Assign this Collider to an Entity.
        /// </summary>
        public virtual void AssignTo(Entity parent)
        {
            Parent = parent;
            if (parent != null)
                Update();
        }

        /// <summary>
        /// Update the parent's bounds for this Collider.
        /// </summary>
        public virtual void Update()
        {
        }

        //	Collider information
        protected string _class;
        protected Dictionary<string, ColliderCallback> _check;
        protected delegate bool ColliderCallback(Collider Collider);

    }
}