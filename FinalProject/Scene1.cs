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
    class Scene1 : Scene
    {
        /*
        public struct Progress
        {
            public int progress;
            public Progress(int nivel)
            {
               
            }
        }
        */
        static int boxSide = 115;
        static Point[] coordinates = { new Point(592, 712), new Point(1102, 352), new Point(1712, 712), new Point(1102, 1278) };
        static Point[] mov = { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1) };
        int progresoJuego = 0;
        int cajasFaltantes = 4;
        int cajasMetidas = 0;
        bool BoxInsideCoordinates(Box the_box, Point coordinate)
        {

            return the_box.Intersects(new Rectangle(coordinate.X, coordinate.Y, 1, 1));

        }
        public Scene1(BasicFile the_file) : base(the_file)
        {
            the_enemies.Add(new Enemy(true, 2.5));
            the_enemies.Add(new Enemy(false, 2.5));
            the_enemies.Add(new Enemy(true, 2.5));
            the_enemies.Add(new Enemy(false, 2.5));
            the_enemies.Add(new Enemy(true, 2.5));
            the_enemies.Add(new Enemy(false, 2.5));
            the_enemies.Add(new Enemy(true, 2.5));
            the_enemies.Add(new Enemy(false, 2.5));
            the_enemies.Add(new Enemy(true, 2.5));
            the_enemies.Add(new Enemy(false, 2.5));
            the_boxes.Add(new Box(new Rectangle(100, 300, boxSide, boxSide), Color.White));///left box
            the_boxes.Add(new Box(new Rectangle(1900, 300, boxSide, boxSide), Color.White));///right box
            the_boxes.Add(new Box(new Rectangle(900, 100, boxSide, boxSide), Color.White));///up box
            the_boxes.Add(new Box(new Rectangle(900, 1500, boxSide, boxSide), Color.White));///down box
            BasicSprite.SetBoundaries(new Viewport(new Rectangle(0, 0, 2100, 1620)));
        }
        public void LoadContent(ContentManager Content)
        {
            LoadContent(Content, "Sprites/Map/Map1/Transitable1", "Sprites/Map/Map1/NoTransitable1", "Sprites/Map/Map1/Mapa1-Recuperado");
            the_enemies[0].LoadContent(Content, new Rectangle(200, 500, 50, 50), 0.075, new Point(3, 3));
            the_enemies[1].LoadContent(Content, new Rectangle(200, 900, 50, 50), 0.075, new Point(3, 3));
            the_enemies[2].LoadContent(Content, new Rectangle(200, 1520, 50, 50), 0.075, new Point(3, 3));
            the_enemies[3].LoadContent(Content, new Rectangle(600, 100, 50, 50), 0.075, new Point(3, 3));
            the_enemies[4].LoadContent(Content, new Rectangle(600, 1520, 50, 50), 0.075, new Point(3, 3));
            the_enemies[5].LoadContent(Content, new Rectangle(2000, 100, 50, 50), 0.075, new Point(3, 3));
            the_enemies[6].LoadContent(Content, new Rectangle(2000, 800, 50, 50), 0.075, new Point(3, 3));
            the_enemies[7].LoadContent(Content, new Rectangle(2000, 1520, 50, 50), 0.075, new Point(3, 3));
            the_enemies[8].LoadContent(Content, new Rectangle(1500, 150, 50, 50), 0.075, new Point(3, 3));
            the_enemies[9].LoadContent(Content, new Rectangle(1500, 1520, 50, 50), 0.075, new Point(3, 3));
        }
        public override void Update(GameTime gameTime)
        {
            if (!lost)
            {
                base.Update(gameTime);
                /*foreach(Box the_box in the_boxes)
                {
                    Console.WriteLine("box pos:" + the_box.getPos());
                }*/
                progresoJuego = 100 / cajasFaltantes;
                completed = true;
                for (int coord = 0; coord < 4; coord++)
                {
                    bool yes = false;
                    foreach (Box the_box in the_boxes)
                    {
                        if (BoxInsideCoordinates(the_box, coordinates[coord]))
                        {
                            cajasMetidas++;
                            yes = true;
                            break;
                        }
                    }
                    /*if(yes)
                    {
                        Console.WriteLine("coord: " + coord + " yes");
                    }*/
                    if (!yes)
                    {
                        completed = false;
                    }


                }
                //Console.WriteLine("Cajas metidas: " + cajasMetidas);
                the_hud.porcentaje = progresoJuego * (cajasMetidas);

                cajasMetidas = 0;


                //Console.WriteLine("Scene1:" + (completed ? "completed    " : "in process    "));
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            DrawMap(spriteBatch);
            DrawRest(spriteBatch);
        }
    }
}
