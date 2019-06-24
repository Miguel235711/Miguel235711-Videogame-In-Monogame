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
    interface IBasicCollision
    {
        // Method to check intersection of this (eventual)
        // object with a rectangle
        bool Intersects(Rectangle colIn);
        // Method for this (eventual) object to provide a
        // rectangle for collision
        Rectangle GetCollisionRect();
    }
}
