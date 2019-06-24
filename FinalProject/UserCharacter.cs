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
    class UserCharacter : AnimatedCharacter
    {
        protected List<Keys> the_keys;
        bool touchedByEnemy;
        public bool IsDeath()
        {
            return touchedByEnemy;
        }
        public UserCharacter(Keys leftKey, Keys rightKey, Keys upKey,Keys downKey) : base()
        {
            the_keys = new List<Keys>();
            the_keys.Add(leftKey);
            the_keys.Add(rightKey);
            the_keys.Add(upKey);
            the_keys.Add(downKey);
            touchedByEnemy = false;
        }
        Point getDirection()
        {
            Point direction = Point.Zero;
            if (states[state.left.ToString()].IsMovementActive())
            {
                direction.X -= GetAbsSpeedX();
            }
            if (states[state.right.ToString()].IsMovementActive())
            {
                direction.X += GetAbsSpeedX();
            }
            if (states[state.down.ToString()].IsMovementActive())
            {
                direction.Y += GetAbsSpeedY();
            }
            if (states[state.up.ToString()].IsMovementActive())
            {
                direction.Y -= GetAbsSpeedY();
            }
            return direction;
        }
        bool CollidingPosWithEnemies(Rectangle pos)
        {
            foreach(Enemy the_enemy in the_enemies)
            {
                if (the_enemy.pos.Intersects(pos))return true;
            }
            return false;
        }
        bool CollidingPosWithBoxes(Rectangle pos,int index)
        {
            for (int i = 0 ; i < the_boxes.Count();i++)
            {
                if (index!=i&&the_boxes[i].getPos().Intersects(pos)) return true;
            }
            return false;
        }
        bool CheckCollisionWithBoxes()
        {
            bool collide = false;
            for(int i = 0 ; i < the_boxes.Count(); i++)
            {
                Box the_box = the_boxes[i];
                if (CheckCollision(the_box))
                {
                    collide = true;
                    Rectangle boxPos = the_box.getPos();
                    Point direction = getDirection();
                    boxPos.X += direction.X;
                    boxPos.Y += direction.Y;
                    if (!CollidingPosWithEnemies(boxPos)&&!CollidingPosWithBoxes(boxPos,i)&&InsideLimit(boxPos) && the_map.CollidingWithTrans(boxPos.X, boxPos.Y, boxPos.Width, boxPos.Height)) {
                        the_box.setPos(boxPos);
                        if (CheckCollision(the_box))
                        {
                            the_box.setPos(the_box.GetLastPos());
                        }
                    }
                    else
                    {
                        doNotMove = true;
                    }
                }
            }
            return collide;
        }
        public override void Update(GameTime gameTime)
        {
            ///prepare keyboard input
            bool character_moved = false;
            ///check movement right or left
            for (state i = state.left; i <= state.down; i++)
            {
                State the_state = states[i.ToString()];///dangerous
                bool x = Keyboard.GetState().IsKeyDown(the_keys[(int)i]);
                character_moved |= x;
                the_state.SetMovementActive(x);
                //Console.WriteLine((int)i + " " + x);
                //Console.WriteLine("current dir " + currentStateName);
            }
            if (!character_moved)
            {
                ///set corresponding static state
                if (GetCurrentStateName() == state.left.ToString())
                {
                    //currentStateName = state.staticLeft.ToString();
                    State the_state = states[state.staticLeft.ToString()];
                    the_state.SetMovementActive(true);
                }
                else if (GetCurrentStateName() == state.right.ToString())
                {
                    //currentStateName = state.staticRight.ToString();
                    State the_state = states[state.staticRight.ToString()];
                    the_state.SetMovementActive(true);
                }
            }
            Console.WriteLine("position" + pos);
            //Console.WriteLine("new state: " + GetCurrentStateName());
            CheckCollisionWithBoxes();
            base.Update(gameTime);
        }
        public override bool CheckCollision<T>(T check)
        {
            bool result = base.CheckCollision(check);
            //Console.WriteLine("what: " + check.GetType().ToString());
            //Console.WriteLine("result: " + result + " what: " + check.GetType() + " " + typeof(Enemy) );
            Type type = check.GetType();
            if (type== typeof(Enemy))
            {
                touchedByEnemy |= result;
            }
            return result;
        }
    }
}
