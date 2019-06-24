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
    abstract class BasicMenu
    {
        protected BasicFile the_file;
        protected List<BasicGUIButton> the_buttons = new List<BasicGUIButton>();
        protected List<Label> the_labels = new List<Label>();
        protected BasicSprite background;
        public BasicMenu(BasicFile the_file)
        {
            this.the_file = the_file;
            background = new BasicSprite(new Rectangle(Scene.GetViewport().X,Scene.GetViewport().Y,Scene.GetViewport().Width,Scene.GetViewport().Height), Color.White);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            foreach (BasicGUIButton the_button in the_buttons)
                the_button.Draw(spriteBatch);
            foreach(Label the_label in the_labels)
            {
                the_label.Draw(spriteBatch);
            }
        }
        public virtual void Update(GameTime gameTime)
        {
            background.Update(gameTime);
            foreach(BasicGUIButton the_button in the_buttons)
            {
                the_button.Update(gameTime);
            }
        }
        abstract public void LoadContent(ContentManager Content);
        protected void addButton(ContentManager Content, Rectangle pos, Color noOverMouseColor , Color overMouseColor, string filename)
        {
            the_buttons.Add(new BasicGUIButton(pos,noOverMouseColor,overMouseColor));
            the_buttons.Last().LoadContent(Content, filename, 1, 1);
        }
        protected void addLabel(ContentManager Content, string filenameFont,Vector2 pos)
        {
            the_labels.Add(new Label(pos));
            the_labels.Last().LoadContent(Content, filenameFont);
        }
    }
}
