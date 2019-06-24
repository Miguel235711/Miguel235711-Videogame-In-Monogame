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
    abstract class AbstractSprite : BasicCollision
    {
        protected Rectangle pos;
        protected Rectangle lastPos;
        protected List<Texture2D> textures;
        protected int frameWidth, frameHeight;
        protected int currentFrame, frameBegCount, frameEndCount;
        protected Color color;
        protected double timer;
        protected static Rectangle Boundaries;
        public abstract bool InsideLimit(Rectangle pos);
        public abstract void setPos(Rectangle pos);
        public abstract Rectangle getPos();
        public abstract override void LoadContent(ContentManager Content, string filename);
        public abstract void LoadContent(ContentManager Content, string filename, int frameBegCount, int frameEndCount);
        public abstract void LoadContent(ContentManager Content, string filename, int frameBegCount, int frameEndCount, int frameWidth, int frameHeight);
        public abstract override void Update(GameTime gameTime);
        public abstract override void Draw(SpriteBatch spriteBatch,Camera the_camera);
        public abstract void SetLastPos(Rectangle lastPos);
        public abstract Rectangle GetLastPos();
    }
}
