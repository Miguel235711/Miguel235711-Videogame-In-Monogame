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
    enum state { left, right,up,down, Jump, staticLeft, staticRight,staticUp,staticDown };
    abstract class AbstractAnimatedCharacter : BasicCollision
    {
        protected SortedDictionary<string, State> states;
        protected Point lastSpeed;
        public abstract Rectangle pos
        {
            get;
            set;
        }
        public abstract Rectangle last_pos
        {
            get;
            set;
        }
        public abstract Color color
        {
            set;
            get;
        }
        protected abstract void AddState(ContentManager Content, string state_name, Point speed, double timePerFrame, string filename, int frameBegCount, int frameEndCount,Rectangle pos,Color color);
        protected abstract void AddState(ContentManager Content, string state_name, Point speed, double timePerFrame, string filename, int frameBegCount, int frameEndCount, int frameWidth, int frameHeight,Rectangle pos,Color Color);
        public abstract override void LoadContent(ContentManager Content, string filename);
        public abstract override void Update(GameTime gameTime);

        public override bool Intersects(Rectangle colIn)
        {
            return pos.Intersects(colIn);
        }

        public override Rectangle GetCollisionRect()
        {
            return pos;
        }
    }
}