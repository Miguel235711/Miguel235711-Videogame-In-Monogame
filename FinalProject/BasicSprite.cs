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
    class BasicSprite : AbstractSprite
    {
        public BasicSprite(Rectangle pos, Color color)
        {
            textures = new List<Texture2D>();
            this.pos = pos;
            this.color = color;
            timer = 0;
            lastPos = pos;
        }
        public BasicSprite() { }
        public Texture2D GetTexture()
        {
            Console.WriteLine("texture " + textures.First().Width);
            
            return textures.First();
        }
        public static void SetBoundaries(Viewport viewport)
        {
            BasicSprite.Boundaries = new Rectangle(viewport.X, viewport.Y, viewport.Width, viewport.Height);
        }
        public static Rectangle GetBoundaries()
        {
            return BasicSprite.Boundaries;
        }
        public bool InsideDownLimit(Rectangle pos)
        {
            
            return pos.Y + pos.Height < BasicSprite.GetBoundaries().Height + BasicSprite.GetBoundaries().Y;
        }
        public bool InsideUpLimit(Rectangle pos)
        {
            //Console.WriteLine("character pos: " + pos + " basic sprite up limit " + BasicSprite.GetBoundaries().Y+" bool "+ (pos.Y > BasicSprite.GetBoundaries().Y));
            return pos.Y > BasicSprite.GetBoundaries().Y;
        }
        public bool InsideLeftLimit(Rectangle pos)
        {
            //Console.WriteLine("character pos: " + pos + " basic sprite left limit " + BasicSprite.GetBoundaries().X+" bool " + (pos.X > BasicSprite.GetBoundaries().Y));
            return pos.X > BasicSprite.GetBoundaries().X;
        }
        public bool InsideRightLimit(Rectangle pos)
        {
            //Console.WriteLine("character pos: "+pos+" basic sprite right limit " + BasicSprite.GetBoundaries().Width + BasicSprite.GetBoundaries().X+" bool " + (pos.X + pos.Width < BasicSprite.GetBoundaries().Width + BasicSprite.GetBoundaries().X));
            return pos.X + pos.Width < BasicSprite.GetBoundaries().Width + BasicSprite.GetBoundaries().X;
        }
        public override bool InsideLimit(Rectangle pos)
        {
            return InsideLeftLimit(pos) & InsideRightLimit(pos) & InsideUpLimit(pos) & InsideDownLimit(pos);
        }
        public override void setPos(Rectangle pos)
        {
            lastPos = this.pos;
            this.pos = pos;
        }
        public override Rectangle getPos()
        {
            return pos;
        }
        public override void SetLastPos(Rectangle lastPos)
        {
            this.lastPos = lastPos;
        }
        public override Rectangle GetLastPos()
        {
            return lastPos;
        }
        public override void LoadContent(ContentManager Content, string filename)
        {
            textures.Add(Content.Load<Texture2D>(filename));
        }
        public override void LoadContent(ContentManager Content, string filename, int frameBegCount, int frameEndCount)
        {
            LoadContent(Content, filename);
            frameWidth = textures.Last().Width;
            frameHeight = textures.Last().Height;
            this.frameBegCount = frameBegCount;
            this.frameEndCount = frameEndCount;
            currentFrame = frameBegCount;
        }
        public override void LoadContent(ContentManager Content, string filename, int frameBegCount, int frameEndCount, int frameWidth, int frameHeight)
        {
            LoadContent(Content, filename);
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameBegCount = frameBegCount;
            this.frameEndCount = frameEndCount;
            currentFrame = frameBegCount;
        }
        public override void Update(GameTime gameTime)
        {
            timer = timer + (double)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void Draw(SpriteBatch spriteBatch)///for animated
        {
            spriteBatch.Begin();
            spriteBatch.Draw(textures[currentFrame - frameBegCount], pos, color);
            spriteBatch.End();
        }
        public override void Draw(SpriteBatch spriteBatch, Camera the_camera)
        {
            Rectangle finalPos = new Rectangle(pos.X + the_camera.GetOrigin().X - the_camera.GetPos().X, pos.Y + the_camera.GetOrigin().Y - the_camera.GetPos().Y, pos.Width, pos.Height);
            Draw(spriteBatch, finalPos);
        }
        public virtual void Draw(SpriteBatch spriteBatch,Rectangle dest_rectangle)///for animated
        {
            spriteBatch.Begin();
            spriteBatch.Draw(textures[currentFrame - frameBegCount], dest_rectangle, color);
            spriteBatch.End();
        }
        public void Draw(SpriteBatch spriteBatch,Rectangle source_rectangle,Rectangle dest_rectangle) /// general
        {
            spriteBatch.Begin();
            spriteBatch.Draw(textures[currentFrame - frameBegCount],dest_rectangle,source_rectangle, color);
            spriteBatch.End();
        }
        public int GetWidth()
        {
            return textures.First().Width;
        }
        public int GetHeight()
        {
            return textures.First().Height;
        }
        public void GetData(Color[] overData)
        {
            textures.First().GetData(overData);
        }

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
