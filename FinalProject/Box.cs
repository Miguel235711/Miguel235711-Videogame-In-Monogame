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
    class Box : BasicSprite
    {
        public Box(Rectangle pos,Color color):base(pos,color)
        {

        }
        public void LoadContent(ContentManager Content)
        {
            LoadContent(Content, "Sprites/Box/Box", 1, 1);
        }
    }
}
