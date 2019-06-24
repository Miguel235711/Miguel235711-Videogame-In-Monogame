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
    class GameOver : BasicMenu
    {
        public GameOver(BasicFile the_file):base(the_file)
        {
           
        }
        public override void LoadContent(ContentManager Content)
        {
            background.LoadContent(Content, "Sprites/GameOver/gameOverBackground");
            addLabel(Content, "Fonts/font", new Vector2(90, 10));
            addButton(Content, new Rectangle(90, 200, 250, 100), Color.White, Color.WhiteSmoke, "MenuPrincipal");
            addButton(Content, new Rectangle(360, 200, 250, 100), Color.White, Color.WhiteSmoke, "ReiniciarNivel");
        }
        public bool isMainMenuPressed()
        {
            return the_buttons[0].isPressed();
        }
        public bool isRestartPressed()
        {
            return the_buttons[1].isPressed();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            the_labels[0].SetText("LV: " + the_file.GetLevel(), Color.Black);
        }
    }
}
