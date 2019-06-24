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
    class Scene2 : Scene
    {
        static int width = 2100, height = 1620;
        static int enemyWidth = 30, enemyHeight = 30;
        public Scene2(BasicFile the_file) : base(the_file)
        {
            BasicSprite.SetBoundaries(new Viewport(new Rectangle(0, 0, width, height)));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(true, 2));
            the_enemies.Add(new Enemy(true, 2));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(true, 2.5));
            the_enemies.Add(new Enemy(true, 2.5));
            the_enemies.Add(new Enemy(true, 2.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_enemies.Add(new Enemy(false, 1.5));
            the_boxes.Add(new Box(new Rectangle(1702, 390, 90, 90),Color.SaddleBrown));
            the_boxes.Add(new Box(new Rectangle(1702, 500, 90, 90),Color.SaddleBrown));
            the_boxes.Add(new Box(new Rectangle(292, 808, 90, 90),Color.SaddleBrown));
            the_boxes.Add(new Box(new Rectangle(292, 908, 90, 90),Color.SaddleBrown));
        }
        public void LoadContent(ContentManager Content)
        {
            LoadContent(Content, "Sprites/Map/Map2/Transitable2", "Sprites/Map/Map2/NoTransitable2", "Sprites/Map/Map2/Mapa2Vista");
            the_enemies[0].LoadContent(Content, new Rectangle(150, 100, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[1].LoadContent(Content, new Rectangle(500, 100, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[2].LoadContent(Content, new Rectangle(850, 100, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[3].LoadContent(Content, new Rectangle(1200, 100, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[4].LoadContent(Content, new Rectangle(1550, 100, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[5].LoadContent(Content, new Rectangle(1702, 150, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[6].LoadContent(Content, new Rectangle(2048, 358, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[7].LoadContent(Content, new Rectangle(1656, 472, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[8].LoadContent(Content, new Rectangle(1272, 472, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[9].LoadContent(Content, new Rectangle(888, 472, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[10].LoadContent(Content, new Rectangle(504, 472, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[11].LoadContent(Content, new Rectangle(4, 602, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[12].LoadContent(Content, new Rectangle(366, 756, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[13].LoadContent(Content, new Rectangle(4, 950, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[14].LoadContent(Content, new Rectangle(390, 880, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[15].LoadContent(Content, new Rectangle(774, 880, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[16].LoadContent(Content, new Rectangle(1158, 880, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
            the_enemies[17].LoadContent(Content, new Rectangle(1542, 880, enemyWidth, enemyHeight), 0.075, new Point(2, 2));
        }
        public override void Update(GameTime gameTime)
        {
            if (!lost)
            {
                base.Update(gameTime);
                int rightInferiorXHero = the_hero.GetCollisionRect().X + the_hero.GetCollisionRect().Width;
                int rightInferiorYHero = the_hero.GetCollisionRect().Y + the_hero.GetCollisionRect().Height;
                the_hud.porcentaje = Math.Max(rightInferiorXHero * rightInferiorYHero * 100 / width / height, the_hud.porcentaje);
                if (the_hud.porcentaje >= 99)
                {
                    the_hud.porcentaje = 100;
                    completed = true;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            DrawMap(spriteBatch);
            DrawRest(spriteBatch);

        }


    }
}
