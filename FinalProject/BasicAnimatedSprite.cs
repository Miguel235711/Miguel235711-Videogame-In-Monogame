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
    class BasicAnimatedSprite : BasicSprite
    {

        double timePerFrame;
        protected int animationExecutions;
        bool spriteSheet;
        public BasicAnimatedSprite(Rectangle pos, double timePerFrame, Color color) : base(pos, color)
        {
            spriteSheet = false;
            this.timePerFrame = timePerFrame;
            animationExecutions = 0;
        }
        public BasicAnimatedSprite() : base() { }
        public override void LoadContent(ContentManager Content, string filename, int frameBegCount, int frameEndCount)
        {
            for (int i = frameBegCount; i <= frameEndCount; i++)
            {
                base.LoadContent(Content, filename + (i).ToString("00"), frameBegCount, frameEndCount);
            }
            spriteSheet = false;
        }
        public override void LoadContent(ContentManager Content, string filename, int frameBegCount, int frameEndCount, int frameWidth, int frameHeight)
        {
            base.LoadContent(Content, filename, frameBegCount, frameEndCount, frameWidth, frameHeight);
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            spriteSheet = true;
        }
        public override void Draw(SpriteBatch spriteBatch,Camera the_camera)
        {
            if (spriteSheet)
            {
                //int imageHeight = image.
                int imageHeight = textures[0].Height, imageWidth = textures[0].Width;
                int framesPerRow = imageWidth / frameWidth;
                int x = (currentFrame % framesPerRow) * frameWidth;
                int y = (currentFrame / framesPerRow) * frameHeight;
                Rectangle sourceRectangle = new Rectangle(x, y, frameWidth, frameHeight);
                spriteBatch.Begin();
                spriteBatch.Draw(textures[0], pos, sourceRectangle, color);
                spriteBatch.End();
            }
            else
            {
                base.Draw(spriteBatch,the_camera);
            }
        }
        public override void Draw(SpriteBatch spriteBatch,Rectangle rectangle_dest)
        {
            if (spriteSheet)
            {
                //int imageHeight = image.
                int imageHeight = textures[0].Height, imageWidth = textures[0].Width;
                int framesPerRow = imageWidth / frameWidth;
                if (framesPerRow != 0)
                {
                    int x = (currentFrame % framesPerRow) * frameWidth;
                    int y = (currentFrame / framesPerRow) * frameHeight;
                    Rectangle sourceRectangle = new Rectangle(x, y, frameWidth, frameHeight);
                    spriteBatch.Begin();
                    spriteBatch.Draw(textures[0], rectangle_dest, sourceRectangle, color);
                    spriteBatch.End();
                }
            }
            else
            {
                base.Draw(spriteBatch);
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (timer >= timePerFrame)
            {
                if (currentFrame == frameEndCount)
                {
                    resetAnimation();
                }
                else
                {
                    currentFrame++;
                }
                timer -= timePerFrame;
            }
            //Console.WriteLine(frameCount+" "+currentFrame+" "+timer+" "+timePerFrame);
        }
        public void resetAnimation()
        {
            animationExecutions++;
            currentFrame = frameBegCount;
        }
        public void SetColor(Color color)
        {
            this.color = color;
        }
        public Color GetColor()
        {
            return color;
        }
    }
}
