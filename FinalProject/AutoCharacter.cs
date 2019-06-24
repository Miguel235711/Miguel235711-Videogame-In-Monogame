using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FinalProject
{
    class AutoCharacter : AnimatedCharacter
    {
        bool isHorizontalMovement;
        bool walkToThatWay;
        double wayTimer, wayTimeLimit;
        public AutoCharacter(bool isHorizontalMovement,double wayTimeLimit) : base()
        {
            this.isHorizontalMovement = isHorizontalMovement;
            wayTimer = 0;
            this.wayTimeLimit = wayTimeLimit;
            walkToThatWay = false;
        }
        void CheckWay(GameTime gameTime)
        {
            wayTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (wayTimer >= wayTimeLimit)
            {
                wayTimer -= wayTimeLimit;
                walkToThatWay = !walkToThatWay;
            }
        }
        bool NoCollisionWithBox()
        {
            foreach(Box the_box in the_boxes)
            {
                if (Move().Intersects(the_box.getPos()))
                    return false;
            }
            return true;
        }
        public override void Update(GameTime gameTime)
        {
            CheckWay(gameTime);
            if (isHorizontalMovement)
            {
                if (walkToThatWay)
                {
                    states[state.left.ToString()].SetMovementActive(true);
                }
                else
                {
                    states[state.right.ToString()].SetMovementActive(true);
                }
            }
            else
            {
                if (walkToThatWay)
                {
                    states[state.up.ToString()].SetMovementActive(true);
                }
                else
                {
                    states[state.down.ToString()].SetMovementActive(true);
                }
            }
            if(NoCollisionWithBox())
                base.Update(gameTime);
        }
    }
}
