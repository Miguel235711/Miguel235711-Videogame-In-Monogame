using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FinalProject
{
    class Menu : BasicMenu
    {
        
        public Menu(BasicFile the_file) : base(the_file)
        {
            
        }
        public override void LoadContent(ContentManager Content)
        {
            background.LoadContent(Content, "Sprites/Menu/menuBackground");
            addButton(Content, new Rectangle(225, 130, 250, 100), Color.White, Color.WhiteSmoke, "NuevoJuego");
            addButton(Content, new Rectangle(225, 280, 250, 100), Color.White, Color.WhiteSmoke, "ReanudarJuego");
            addButton(Content, new Rectangle(225, 430, 250, 100), Color.White, Color.WhiteSmoke, "Salir");
            addLabel(Content, "Fonts/font", new Vector2(320, 285));
        }
        public bool isNewGamePressed()
        {
            return the_buttons[0].isPressed();
        }
        public bool isContinueGamePressed()
        {
            return the_buttons[1].isPressed();
        } 
        public bool isExitPressed()
        {
            return the_buttons[2].isPressed();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            the_labels[0].SetText("LV: " + the_file.GetLevel(),Color.Black);
        }
    }
}
