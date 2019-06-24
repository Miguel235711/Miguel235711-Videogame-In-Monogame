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
    class BasicGUIButton:BasicSprite
    {
        Color noOverMouseColor, overMouseColor;
        bool pressed;
        static double timeLimitForNextPressing, timerForNextPressing;
        public BasicGUIButton(Rectangle pos,Color noOverMouseColor,Color overMouseColor ) : base(pos,noOverMouseColor)
        {
            this.noOverMouseColor = noOverMouseColor;
            this.overMouseColor = overMouseColor;
            pressed = false;
        }
        public static void SetLimitForNextPressing(double timeLimitForNextPressing)
        {
            timerForNextPressing=BasicGUIButton.timeLimitForNextPressing = timeLimitForNextPressing;
        }
        public static void UpdateLimitForNextPressing(GameTime gameTime)
        {
            //Console.WriteLine("what"+timerForNextPressing);
            timerForNextPressing += gameTime.ElapsedGameTime.TotalSeconds;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (pos.Contains(Mouse.GetState().X, Mouse.GetState().Y))///mouse over
            {
                color = overMouseColor;
            }
            else
            {
                color = noOverMouseColor;
            }
        }
        public bool readyForPressing()
        {
            return timerForNextPressing >= timeLimitForNextPressing;
        }
        public void resetPressingLimit()
        {
            timerForNextPressing =0;
        }
        public bool isPressed()
        {
            if (readyForPressing()&&Mouse.GetState().LeftButton == ButtonState.Pressed && !pressed && pos.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                resetPressingLimit();
                pressed = true;
                return true;
            }
            pressed = false;
            return false;
        }
    }
}
