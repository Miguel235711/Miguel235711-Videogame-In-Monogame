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
    class Label
    {
        Vector2 pos;
        SpriteFont font;
        string text;
        Color color;
        public Label(Vector2 pos)
        {
            this.pos = pos;
            text = "";
        }
        public void SetText(string text, Color color)
        {
            this.text = text;
            this.color = color;
        }
        public void LoadContent(ContentManager Content, string filename)
        {
            font = Content.Load<SpriteFont>(filename);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, pos, color);
            spriteBatch.End();
        }
    }
}
