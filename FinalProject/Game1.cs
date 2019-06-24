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
    /// Videogame
    /// You are a Hero controlled with the keyboard keys, you have to find items and solve puzzles 
    /// on each map. You complete a map when you get the key, which is unlocked when completing the puzzles.
    /// Then you move on to the next map
    /// /// Team:Miguel Ángel Muñoz Vázquez - A01423629 , Aarón Pérez Ontiveros - A01422524 , Juan Pablo Hernádez González - A01423444
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int windowWidth = 700, windowHeight = 540;
        Scene1 scene1;
        Scene2 scene2;
        Scene3 scene3;
        Menu the_menu;
        GameOver the_game_over;
        WinMenu the_win_menu;
        BasicFile the_file = new BasicFile("gameData.txt");
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            BasicSprite.SetBoundaries(new Viewport(new Rectangle(0, 0, 2100, 1620)));
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.ApplyChanges();
            Scene.setViewport(GraphicsDevice.Viewport);
            BasicGUIButton.SetLimitForNextPressing(0.1);
            the_menu = new Menu(the_file);
            //scene2 = new Scene2();
            //the_game_over_menu = new GameOver();
            //scene1 = new Scene1();
            //scene2 = new Scene2();
            //scene3 = new Scene3();
            //graphics.PreferredBackBufferHeight =253 ;
            //graphics.PreferredBackBufferWidth = 320;
            //graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void SetMenusNull()
        {
            the_menu = null;
            the_game_over = null;
            the_win_menu = null;
        }
        void SetScenesNull()
        {
            scene1 = null;
            scene2 = null;
            scene3 = null;
        }
        void SetEverythingNull()
        {
            SetMenusNull();
            SetScenesNull();
        }
        void SetScene1()
        {
            SetEverythingNull();
            scene1 = new Scene1(the_file);
            the_file.SetLevel(1);
            scene1.LoadContent(Content);
        }
        void SetScene2()
        {
            SetEverythingNull();
            scene2 = new Scene2(the_file);
            the_file.SetLevel(2);
            scene2.LoadContent(Content);
        }
        void SetScene3()
        {
            SetEverythingNull();
            scene3 = new Scene3(the_file);
            the_file.SetLevel(3);
            scene3.LoadContent(Content);
        }
        void SetMainMenu()
        {
            SetEverythingNull();
            the_menu = new Menu(the_file);
            the_menu.LoadContent(Content);
        }
        void SetGameOver()
        {
            SetEverythingNull();
            the_game_over = new GameOver(the_file);
            the_game_over.LoadContent(Content);
        }
        void SetWinMenu()
        {
            SetEverythingNull();
            the_win_menu = new WinMenu(the_file);
            the_win_menu.LoadContent(Content);
        }
        void SetFileLevel()
        {
            int level = the_file.GetLevel();
            switch (level)
            {
                case 1:
                    SetScene1();
                    break;
                case 2:
                    SetScene2();
                    break;
                case 3:
                    SetScene3();
                    break;
                default:
                    break;
            }
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;
            //SetScene1();
            //scene2.LoadContent(Content);
            SetMainMenu();
            //the_game_over_menu.LoadContent(Content);
            //scene1.LoadContent(Content);
            //scene2.LoadContent(Content);
            //scene3.LoadContent(Content);
            // TODO: use this.Content to load your game content here

        }
        void CheckIfSceneIsWonAndChange()
        {
            if (scene1 != null&&scene1.Won())
            {
                SetScene2();
                return;
            }
            else if(scene2!=null&&scene2.Won())
            {
                SetScene3();
            }else if(scene3!=null && scene3.Won())
            {
                SetWinMenu();
            }
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //scene2.Update(gameTime);
            if (the_menu != null) {
                the_menu.Update(gameTime);
                if (the_menu.isNewGamePressed())
                {
                    SetScene1();
                }else if (the_menu.isContinueGamePressed())
                {
                    SetFileLevel();
                }else if (the_menu.isExitPressed())
                {
                    Exit();
                }
            }
            if (the_game_over != null)
            {
                the_game_over.Update(gameTime);
                if (the_game_over.isMainMenuPressed())
                {
                    SetMainMenu();
                }else if (the_game_over.isRestartPressed())
                {
                    SetFileLevel();
                }
            }
            if (the_win_menu != null)
            {
                the_win_menu.Update(gameTime);
                if (the_win_menu.isMainMenuPressed())
                {
                    SetMainMenu();
                }
            }
            if (scene1 != null) {
                if (!scene1.Lost()) {
                    scene1.Update(gameTime);
                }else{
                    SetGameOver();
                }
            }
            if (scene2 != null)
            {
                if (!scene2.Lost())
                {
                    scene2.Update(gameTime);
                }
                else
                {
                    SetGameOver();
                }
            }
            if (scene3 != null)
            {
                if (!scene3.Lost())
                {
                    scene3.Update(gameTime);
                }
                else
                {
                    SetGameOver();
                }
            }
            CheckIfSceneIsWonAndChange();
            BasicGUIButton.UpdateLimitForNextPressing(gameTime);
            //the_game_over_menu.Update(gameTime);
            //scene1.Update(gameTime);
            //scene2.Update(gameTime);
            //scene3.Update(gameTime);
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //scene1.Draw(spriteBatch);
            //scene2.Draw(spriteBatch);
            //scene3.Draw(spriteBatch);
            if(the_menu!=null)
                the_menu.Draw(spriteBatch);
            if (the_game_over != null)
                the_game_over.Draw(spriteBatch);
            if (the_win_menu != null)
            {
                the_win_menu.Draw(spriteBatch);
            }
            if(scene1!=null)
                scene1.Draw(spriteBatch);
            if (scene2 != null)
                scene2.Draw(spriteBatch);
            if (scene3 != null)
                scene3.Draw(spriteBatch);
            //the_game_over_menu.Draw(spriteBatch);
            //scene2.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
