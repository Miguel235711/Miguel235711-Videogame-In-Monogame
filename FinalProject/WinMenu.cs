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
    class WinMenu : BasicMenu
    {
        public WinMenu(BasicFile the_file) : base(the_file) { }
        public override void LoadContent(ContentManager Content)
        {
            background.LoadContent(Content, "Sprites/WinMenu/winMenu");
            addButton(Content, new Rectangle(225, 180, 250, 100), Color.White, Color.WhiteSmoke, "MenuPrincipal");
        }
        public bool isMainMenuPressed()
        {
            return the_buttons[0].isPressed();
        }
    }
}
