using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
/*problem when drawing multiple characters, each one with its own camera*/
namespace FinalProject
{
    public class Camera 
    {
        Rectangle pos, origin;
        public Rectangle GetPos()
        {
            return pos;
        }
        public Camera(Rectangle pos)
        {
            origin = pos;
            this.pos = pos;
        }
        public Rectangle GetOrigin()
        {
            return origin;
        }
        public void Update(Rectangle character_pos)
        {

            //pos = character_pos;
            character_pos.X+=character_pos.Width/2;
            character_pos.Y += character_pos.Height / 2;
            pos.X = character_pos.X - pos.Width / 2;
            pos.Y = character_pos.Y - pos.Height / 2;
            pos.X = Math.Max(pos.X, 0);
            pos.Y = Math.Max(pos.Y, 0);
            pos.X = Math.Min(pos.X, BasicAnimatedSprite.GetBoundaries().Width - pos.Width);
            pos.Y = Math.Min(pos.Y,BasicAnimatedSprite.GetBoundaries().Height - pos.Height);
            //Console.WriteLine("Character pos" + character_pos);
            //Console.WriteLine("camera position: " + pos);
        }
    }
}
