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
    abstract class BasicCollision : IBasicCollision , IGame
    {
        public abstract bool Intersects(Rectangle colIn);
        // Method from interface
        public abstract Rectangle GetCollisionRect();
        // GENERIC CheckCollision Method
        // Can be used with any class derived from IBasicCollision
        public virtual bool CheckCollision<T>(T check) where T : IBasicCollision
        {
            // NOTICE THAT ATTRIBUTES ARE NOT DIRECTLY REFERENCED
            return Intersects(check.GetCollisionRect());
        }
        public abstract void Draw(SpriteBatch spriteBatch,Camera the_camera);
        public abstract void Update(GameTime gameTime);
        public abstract void LoadContent(ContentManager Content, string filename);
    }
}
