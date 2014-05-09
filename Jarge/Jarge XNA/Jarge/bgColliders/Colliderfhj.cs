using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JargeEngine.Colliders
{
    public class Colliderfhj
    {
        public Vector2 Position;
        public Entity Parent;
        
        public Colliderfhj()
        {
            
        }
        public virtual void AssignTo(Entity parent)
        {
            Parent = parent;
            if (parent != null)
            {
                Update();
            }
        }
        public virtual void Update()
        {

        }
    }
}
