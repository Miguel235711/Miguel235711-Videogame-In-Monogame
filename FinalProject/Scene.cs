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
    /// </summary>
    class Scene
    {
        protected Hero the_hero;
        protected BasicMap the_map;
        protected Camera the_cam;
        protected List<Button> the_buttons = new List<Button>();
        protected List<Box> the_boxes = new List<Box>();
        List<Llaves> the_key = new List<Llaves>();
        protected List<Enemy> the_enemies = new List<Enemy>();
        protected bool completed;
        protected HUD the_hud;
        static Viewport viewport;
        protected bool lost;
        Label levelIndicator;
        BasicFile the_file;
        public bool Won()
        {
            return !lost & completed & the_hero.CheckCollision(the_key.First());
        }
        public bool Lost()
        {
            return lost;
        }
        public static void setViewport(Viewport viewport)
        {
            Scene.viewport = viewport;
        }
        public static Viewport GetViewport()
        {
            return Scene.viewport;
        }
        public Scene(BasicFile the_file)
        {
            this.the_file = the_file;
            levelIndicator = new Label(new Vector2(viewport.Width-100, 0));
            AnimatedCharacter.SetBoxes(the_boxes);
            AnimatedCharacter.SetEnemies(the_enemies);
            the_hero = new Hero(Keys.Left, Keys.Right, Keys.Up, Keys.Down);
            the_cam = new Camera(new Rectangle(0, 0, viewport.Width, viewport.Height));
            the_hud = new HUD(Vector2.Zero,0);
            the_map = new BasicMap(viewport, Color.White);
            AnimatedCharacter.SetMap(the_map);
            the_key.Add(new Llaves(new Rectangle(10, 10, 60,60), Color.White));///left box
            completed = false;
            lost = false;
        }
        public void LoadContent(ContentManager Content,string transFile,string noTransFile,string filenameStetic)
        {
            the_hero.LoadContent(Content, new Rectangle(4, 48, 100, 100), 0.075, new Point(3, 3));
            the_map.LoadContent(Content, transFile, noTransFile,filenameStetic, Color.White);
            the_hud.LoadContent(Content, "Fonts/font");
            foreach (Box the_box in the_boxes)
                the_box.LoadContent(Content);
            foreach (Llaves the_key in the_key)
                the_key.LoadContent(Content);
            levelIndicator.LoadContent(Content, "Fonts/font");
        }
        void CheckHeroCollisionWithEnemies()
        {
            foreach (Enemy the_enemy in the_enemies)
                the_hero.CheckCollision(the_enemy);
        }
        public virtual void Update(GameTime gameTime)
        {
                the_hero.Update(gameTime);
                the_cam.Update(the_hero.pos);
                the_map.Update(gameTime);
                the_hud.Update(gameTime);
                CheckHeroCollisionWithEnemies();
                lost = the_hero.IsDeath();
                foreach (Enemy the_enemy in the_enemies)
                    the_enemy.Update(gameTime);
                foreach (Box the_box in the_boxes)
                    the_box.Update(gameTime);
            levelIndicator.SetText("LV: " + the_file.GetLevel(), Color.White);
            //Console.WriteLine(the_hero.IsDeath());
        }
        public virtual void DrawMap(SpriteBatch spriteBatch)
        {
            the_map.Draw(spriteBatch, the_cam);
        }
        public virtual void DrawRest(SpriteBatch spriteBatch)
        {
            the_hero.Draw(spriteBatch, the_cam);
            the_hud.Draw(spriteBatch);
            foreach (Enemy the_enemy in the_enemies)
                the_enemy.Draw(spriteBatch, the_cam);
            foreach (Box the_box in the_boxes)
                the_box.Draw(spriteBatch, the_cam);
            if (completed)
            {
                foreach (Llaves the_key in the_key)
                    the_key.Draw(spriteBatch, the_cam);
            }
            levelIndicator.Draw(spriteBatch);
        }
    }
}
