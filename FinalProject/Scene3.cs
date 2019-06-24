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
    class Scene3:Scene
    {
        static int buttonWidth = 200, buttonHeight = 200;
        static int width = 2100, height = 1620;
        static int[] okButtons = { 1, 5, 7, 11 };
        public Scene3(BasicFile the_file) : base(the_file)
        {
            int widthSectionSize = width / 9; 
            the_buttons.Add(new Button(new Rectangle(widthSectionSize - buttonWidth / 2, 0, buttonWidth, buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize - buttonWidth / 2, height/2-buttonHeight/2, buttonWidth, buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize - buttonWidth / 2, height-buttonHeight, buttonWidth, buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize*3 - buttonWidth / 2, 0, buttonWidth, buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize*3 - buttonWidth / 2, height / 2 - buttonHeight / 2, buttonWidth, buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize*3 - buttonWidth / 2, height - buttonHeight, buttonWidth, buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize*5 - buttonWidth / 2, 0, buttonWidth, buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize*5 - buttonWidth / 2, height/2-buttonHeight/2, buttonWidth, buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize*5 - buttonWidth / 2, height-buttonHeight, buttonWidth, buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize*7 - buttonWidth / 2, 0, buttonWidth , buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize*7 - buttonWidth / 2,height/2-buttonHeight/2,buttonWidth, buttonHeight)));
            the_buttons.Add(new Button(new Rectangle(widthSectionSize*7 - buttonWidth / 2, height-buttonHeight,buttonWidth, buttonHeight)));
            BasicSprite.SetBoundaries(new Viewport(new Rectangle(0, 0, 2100, 1620)));
        }
        void adjustProgress()
        {
            the_hud.porcentaje = 0;
            for(int i = 0; i < the_buttons.Count;i++)
                if (Array.Exists(okButtons, p => p == i)&&the_buttons[i].pushed())///if part of solution and pushed
                {
                    the_hud.porcentaje += 25;   
                }else if (the_buttons[i].pushed())///there is one button pushed that it's incorrect
                {
                    the_hud.porcentaje = 0;
                    return;
                }
            if (the_hud.porcentaje == 100)
            {
                completed = true;
            }
        }
        void CheckCollisionWithButtons()
        {
            ///change states
            for(int i = 0 ; i < the_buttons.Count; i ++)
            {

                if (the_hero.CheckCollision(the_buttons[i]))
                {///colliding
                    the_buttons[i].ChangeState();///change state if necessary
                    the_buttons[i].SetLastTimeCollision(true);
                }
                else
                {
                    the_buttons[i].SetLastTimeCollision(false);
                }
            }
        }
        public void LoadContent(ContentManager Content)
        {
            LoadContent(Content, "Sprites/Map/Map3/NoTransitable3", "Sprites/Map/Map3/NoTransitable3", "Sprites/Map/Map3/M3");
            the_buttons[0].LoadContent(Content, "Sprites/Map/Map3/items/dos", 1, 1);
            the_buttons[1].LoadContent(Content, "Sprites/Map/Map3/items/uno", 1, 1);
            the_buttons[2].LoadContent(Content, "Sprites/Map/Map3/items/tres", 1, 1);
            the_buttons[3].LoadContent(Content, "Sprites/Map/Map3/items/siete", 1, 1);
            the_buttons[4].LoadContent(Content, "Sprites/Map/Map3/items/ocho", 1, 1);
            the_buttons[5].LoadContent(Content, "Sprites/Map/Map3/items/cuatro", 1, 1);
            the_buttons[6].LoadContent(Content, "Sprites/Map/Map3/items/cinco", 1, 1);
            the_buttons[7].LoadContent(Content, "Sprites/Map/Map3/items/nueve", 1, 1);
            the_buttons[8].LoadContent(Content, "Sprites/Map/Map3/items/dos", 1, 1);
            the_buttons[9].LoadContent(Content, "Sprites/Map/Map3/items/siete", 1, 1);
            the_buttons[10].LoadContent(Content, "Sprites/Map/Map3/items/seis", 1, 1);
            the_buttons[11].LoadContent(Content, "Sprites/Map/Map3/items/diezyseis", 1, 1);
        }
        public override void Update(GameTime gameTime)
        {
            if (!lost)
            {
                base.Update(gameTime);
                foreach (Button the_button in the_buttons)
                    the_button.Update(gameTime);
                CheckCollisionWithButtons();
                adjustProgress();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            DrawMap(spriteBatch);
            foreach (Button the_button in the_buttons)
                the_button.Draw(spriteBatch,the_cam);
            DrawRest(spriteBatch);
        }
    }
}
