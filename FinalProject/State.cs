using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FinalProject
{
    class State : BasicAnimatedSprite
    {
        Point speed;
        bool movement_is_active;
        public State(Rectangle pos,Point speed,double timePerFrame,Color color) : base(pos,timePerFrame,color)
        {
            this.speed = speed;
        }
        public void SetMovementActive(bool movement_is_active)
        {
            this.movement_is_active = movement_is_active;
        }
        public Point GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(Point speed)
        {
            this.speed = speed;
        }
        public bool IsMovementActive()
        {
            return movement_is_active;
        }
    }
}
