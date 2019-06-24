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
    interface IGame
    {
        void LoadContent(ContentManager Content, string filename);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch,Camera the_camera);
    }
}

