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
    class Button : BasicSprite
    {
        bool lastTimeCollision;
        static Color toggleColor = Color.Gray;
        public Button(Rectangle pos) : base(pos,Color.White)
        {
            lastTimeCollision = false;
        }
        public bool pushed()
        {
            return color != Color.White;
        }
        public void ChangeState()
        {
            if (!lastTimeCollision)
            {
                color = color == Color.White ? toggleColor : Color.White;
            }
        }
        public void SetLastTimeCollision(bool lastTimeCollision)
        {
            this.lastTimeCollision = lastTimeCollision;
        }
    }
}
