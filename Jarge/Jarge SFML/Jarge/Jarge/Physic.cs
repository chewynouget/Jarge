using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jarge_SFML
{
    public class Physic : Entity
    {
        public string CollisionType = "";

        public Physic(float x, float y):base(x, y)
        {

        }
        public override void Update()
        {
            AdjustX();
            base.Update();
        }
        public void AdjustX()
        {
            for (int i = 0; i < Velocity.X; i++)
            {
                if (!Collide(CollisionType))
                {
                    Position.X += Velocity.X;
                }
                else
                {
                    Velocity.X = 0;
                    break;
                }
            }
        }
    }
}
