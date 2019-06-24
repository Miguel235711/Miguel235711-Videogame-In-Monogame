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
    class AnimatedCharacter : AbstractAnimatedCharacter
    {
        string currentStateName;
        protected bool doNotMove ; 
        protected static BasicMap the_map;
        protected static List<Box> the_boxes=new List<Box>();
        protected static List<Enemy> the_enemies= new List<Enemy>();
        public static void SetEnemies(List<Enemy> the_enemies)
        {
            AnimatedCharacter.the_enemies = the_enemies;
        }
        public static void SetMap (BasicMap the_map)
        {
            AnimatedCharacter.the_map = the_map;
        }
        public static void SetBoxes(List<Box> the_boxes)
        {
            AnimatedCharacter.the_boxes = the_boxes;
        }
        protected string GetCurrentStateName()
        {
            return currentStateName;
        }
        public AnimatedCharacter()
        {
            states = new SortedDictionary<string, State>();
            currentStateName = "";
            doNotMove = false;
        }
        public Point GetLastSpeed()
        {
            return lastSpeed;
        }
        public int GetAbsSpeedX()
        {
            return Math.Abs(states[state.left.ToString()].GetSpeed().X);
        }
        public int GetAbsSpeedY()
        {
            return Math.Abs(states[state.up.ToString()].GetSpeed().Y);
        }
        public override Rectangle pos
        {
            get
            {
                State first_state = states[states.Keys.First()];
                return first_state.getPos();
            }
            set
            {
                foreach (KeyValuePair<string, State> the_state in states)
                    the_state.Value.setPos(value);
            }
        }
        public override Rectangle last_pos
        {
            get
            {
                return states[states.Keys.First()].GetLastPos();
            }
            set
            {
                foreach (KeyValuePair<string, State> the_state in states)
                    the_state.Value.SetLastPos(value);
            }
        }
        public override Color color
        {
            set
            {
                foreach (KeyValuePair<string, State> the_state in states)
                    the_state.Value.SetColor(value);
            }
            get
            {
                State first_state = states[states.Keys.First()];
                return first_state.GetColor();
            }
        }
        public override void LoadContent(ContentManager Content, string filename)
        {
            //string first_state_name = states.First().Key;
            currentStateName = state.staticLeft.ToString();
            /*the_sprites = new List<BasicAnimatedSprite>();
            for (state i = state.left; i <= state.staticDown; i++)
            {
                the_sprites.Add(new BasicAnimatedSprite());
            }*/
        }
        protected override void AddState(ContentManager Content, string state_name, Point speed , double timePerFrame, string filename, int frameBegCount, int frameEndCount,Rectangle pos,Color color)
        {
            State new_state = new State(pos,speed,timePerFrame,color);
            new_state.LoadContent(Content, filename, frameBegCount, frameEndCount);
            states.Add(state_name,new_state);
        }
        protected override void AddState(ContentManager Content, string state_name, Point speed , double timePerFrame, string filename, int frameBegCount, int frameEndCount, int frameWidth, int frameHeight, Rectangle pos,Color color)
        {
            State new_state = new State(pos, speed, timePerFrame, color);
            new_state.LoadContent(Content, filename, frameBegCount, frameEndCount,frameWidth,frameHeight);
            states.Add(state_name, new_state);
        }
        public override void Draw(SpriteBatch spriteBatch,Camera the_camera)
        {
            State the_state = states[currentStateName];
            Rectangle finalPos= new Rectangle(pos.X+the_camera.GetOrigin().X- the_camera.GetPos().X,pos.Y+the_camera.GetOrigin().Y-the_camera.GetPos().Y,pos.Width,pos.Height);
            the_state.Draw(spriteBatch,finalPos);
        }
        protected bool InsideLimit(Rectangle pos)
        {
            State first_state = states[states.Keys.First()];
            //Console.WriteLine("inside limit boolean" + first_state.InsideLimit(pos));
            return first_state.InsideLimit(pos);
        }
        public Rectangle Move()
        {
            Rectangle pos = this.pos;
            string lastStateName = currentStateName;
            lastSpeed = Point.Zero;
            foreach (KeyValuePair<string, State> the_state in states)
            {
                if (the_state.Value.IsMovementActive())
                {
                    if (lastStateName != the_state.Key)
                    {
                        the_state.Value.resetAnimation();
                    }
                    currentStateName = the_state.Key;
                    pos.X += the_state.Value.GetSpeed().X;
                    pos.Y += the_state.Value.GetSpeed().Y;
                    //Console.WriteLine("state: " + the_state.Key);
                    //Console.WriteLine("speed: " + the_state.Value.GetSpeed());
                    lastSpeed.X += the_state.Value.GetSpeed().X;
                    lastSpeed.Y += the_state.Value.GetSpeed().Y;
                }
            }
            return pos;
        }
        public override void Update(GameTime gameTime)
        {
            Rectangle hipoteticalPos = Move();
            if (!doNotMove && InsideLimit(hipoteticalPos) && the_map.CollidingWithTrans(hipoteticalPos.X, hipoteticalPos.Y, hipoteticalPos.Width, hipoteticalPos.Height))
            {
                foreach (KeyValuePair<string, State> the_state in states) { 
                    if (the_state.Value.IsMovementActive())
                        the_state.Value.Update(gameTime);
                    the_state.Value.SetMovementActive(false);
                }
                //Console.WriteLine("can move and pos is "+ pos);
                pos = hipoteticalPos;
            }
            doNotMove = false;
            //if(InsideLimit(pos))
            //    this.pos = pos;
            //System.Threading.Thread.Sleep(500);
        }
    }
}
