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
    class Hero : UserCharacter
    {
        public Hero(Keys leftKey,Keys rightKey,Keys upKey,Keys downKey) : base(leftKey, rightKey, upKey,downKey)
        {
        }

        public void LoadContent(ContentManager Content, Rectangle pos, double timeAnimation, Point speed)
        {

            /*AddState(Content ,state.left.ToString(), new Point(-Math.Abs(speed.X),0), timeAnimation, "HeroSprite/HeroSprite", 117,125,64,64,pos,Color.White);
            AddState(Content, state.right.ToString(), new Point(Math.Abs(speed.X),0), timeAnimation, "HeroSprite/HeroSprite",143,151,64,64,pos, Color.White);
            AddState(Content, state.up.ToString(), new Point(0, -Math.Abs(speed.Y)),timeAnimation, "HeroSprite/HeroSprite", 104, 112, 64, 64, pos, Color.White);
            AddState(Content, state.down.ToString(),new Point(0,Math.Abs(speed.Y)), timeAnimation, "HeroSprite/HeroSprite", 130, 138, 64, 64, pos, Color.White);
            AddState(Content, state.staticLeft.ToString(),new Point(0,0), timeAnimation, "HeroSprite/HeroSprite", 117, 117, 64, 64, pos,Color.White);
            AddState(Content, state.staticRight.ToString(), new Point(0, 0), timeAnimation, "HeroSprite/HeroSprite", 143, 143, 64, 64, pos, Color.White);
            AddState(Content, state.staticUp.ToString(), new Point(0, 0), timeAnimation, "HeroSprite/HeroSprite", 104, 104, 64, 64, pos, Color.White);
            AddState(Content, state.staticDown.ToString(), new Point(0, 0), timeAnimation, "HeroSprite/HeroSprite", 130, 138, 64, 64, pos, Color.White);*/
            ///kid
            AddState(Content, state.left.ToString(), new Point(-Math.Abs(speed.X), 0), timeAnimation, "Sprites/HeroSprite/kid", 8, 11, 460, 600, pos, Color.White);
            AddState(Content, state.right.ToString(), new Point(Math.Abs(speed.X), 0), timeAnimation, "Sprites/HeroSprite/kid", 4, 7, 460, 600, pos, Color.White);
            AddState(Content, state.up.ToString(), new Point(0, -Math.Abs(speed.Y)), timeAnimation, "Sprites/HeroSprite/kid", 12, 15, 460, 600, pos, Color.White);
            AddState(Content, state.down.ToString(), new Point(0, Math.Abs(speed.Y)), timeAnimation, "Sprites/HeroSprite/kid", 0, 3, 460, 600, pos, Color.White);
            AddState(Content, state.staticLeft.ToString(), new Point(0, 0), timeAnimation, "Sprites/HeroSprite/kid", 8, 8, 460,600, pos, Color.White);
            AddState(Content, state.staticRight.ToString(), new Point(0, 0), timeAnimation, "Sprites/HeroSprite/kid", 7,7, 460,600, pos, Color.White);
            AddState(Content, state.staticUp.ToString(), new Point(0, 0), timeAnimation, "Sprites/HeroSprite/kid", 12, 12, 460, 600, pos, Color.White);
            AddState(Content, state.staticDown.ToString(), new Point(0, 0), timeAnimation, "Sprites/HeroSprite/kid", 0, 0, 460, 600, pos, Color.White);
            //AddState(Content, direction.staticUp.ToString(), new Point(0, 0), timeAnimation, "Content - Link in XNB/LinkBackStand/LinkBackStand_f", 1, 1, pos, Color.White);
            //AddState(Content, direction.staticDown.ToString(), new Point(0, 0), timeAnimation, "Content - Link in XNB/LinkFrontStand/LinkFrontStand_f", 1, 1, pos, Color.White);
            base.LoadContent(Content, "Hero");
            //this.speed = speed;
            color = Color.White;
            this.pos = pos;
            //AddState(Content, direction., timeAnimation, "Content - Link in XNB/LinkLeftStand/LinkLeftStand_f", 1, 1);
            //AddState(Content, direction.staticRight, timeAnimation, "Content - Link in XNB/LinkRightStand/LinkRightStand_f", 1, 1);
            //AddState(Content, direction.staticUp, timeAnimation, "Content - Link in XNB/LinkBackStand/LinkBackStand_f", 1, 1);
            //AddState(Content, direction.staticDown, timeAnimation, "Content - Link in XNB/LinkFrontStand/LinkFrontStand_f", 1, 1);
        }
    }
}

