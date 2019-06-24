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
    /// <summary>
    /// implement this
    /// </summary>
    class HUD
    {
        public double porcentaje=0;
        Vector2 pos;
        string text;
        SpriteFont font;
        BasicSprite progressBar, fillingBar, timeBackground;
        Color color;
        double time;
        static string prefix = "Time: ";
        public HUD(Vector2 pos,double time)
        {
            this.pos = pos;
            this.time=time;
            SetText(prefix + time.ToString("0.00")+"         Progreso:"+porcentaje+"%",Color.Black);
            timeBackground = new BasicSprite(new Rectangle((int)pos.X, (int)pos.Y, 200, 50), Color.White);
            progressBar = new BasicSprite(new Rectangle((int)pos.X+200,(int)pos.Y,200,50),Color.White);
            fillingBar = new BasicSprite(new Rectangle((int)pos.X + 200, (int)pos.Y, 2 * (int) porcentaje, 50), Color.LightGreen);
        }
        void SetText(string text,Color color)
        {
            this.text = text;
            this.color = color;
        }
        public void LoadContent(ContentManager Content,string filename)
        {
            font = Content.Load<SpriteFont>(filename);
            progressBar.LoadContent(Content, "Sprites/Progress/ProgressBar");
            fillingBar.LoadContent(Content, "Sprites/Progress/ProgressBar");
            timeBackground.LoadContent(Content, "Sprites/Progress/ProgressBar");
        }
        public void Update(GameTime gameTime) {
            time += gameTime.ElapsedGameTime.TotalSeconds;
            if (time < 0) time = 0;
            string timeIndicator = prefix + time.ToString("0.00");
            if (porcentaje == 100)
            {
                timeIndicator = "Find    key!";
            }
            fillingBar.setPos(new Rectangle(fillingBar.getPos().X, fillingBar.getPos().Y, 2 * (int)porcentaje, fillingBar.getPos().Height));
            SetText(timeIndicator + "         Progress:"+porcentaje+"%", Color.Black);


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            progressBar.Draw(spriteBatch);
            fillingBar.Draw(spriteBatch);
            timeBackground.Draw(spriteBatch);
            spriteBatch.Begin();
            //spriteBatch.DrawString(font, text,pos , color);
            spriteBatch.DrawString(font, text,pos , color);
            spriteBatch.End();
        }
    }
}
