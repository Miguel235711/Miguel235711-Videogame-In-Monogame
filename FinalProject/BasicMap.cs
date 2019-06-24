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
    public class BasicMap
    {
        BasicSprite trans, notrans,stetic;
        Color[] overData;
        public BasicMap(Viewport viewport,Color color) {
            trans = new BasicSprite(new Rectangle(viewport.X, viewport.Y, viewport.Width, viewport.Height), color);
            notrans = new BasicSprite(new Rectangle(viewport.X, viewport.Y, viewport.Width, viewport.Height), color);
        }
        public BasicMap(int x, int y, int width, int height, Color color)
        {
            trans = new BasicSprite(new Rectangle(x,y,width,height),color);
            notrans = new BasicSprite(new Rectangle(x,y,width,height),color);
        }
        public BasicMap()
        {
            
        }
        public void Draw(SpriteBatch spriteBatch,Camera the_cam)
        {
            //trans.Draw(spriteBatch, the_cam.GetPos(), the_cam.GetOrigin());
            //notrans.Draw(spriteBatch, the_cam.GetPos(), the_cam.GetOrigin());
            stetic.Draw(spriteBatch, the_cam.GetPos(), the_cam.GetOrigin());
        }
      
        public void LoadContent(ContentManager Content, string filenameTrans, string filenameNoTrans)
        {
            trans.LoadContent(Content, filenameTrans);
            overData = new Color[trans.GetWidth() * trans.GetHeight()];
            notrans.LoadContent(Content, filenameNoTrans);
            trans.GetData(overData);
        }
        public void LoadContent(ContentManager Content, string filename)
        {
            trans.LoadContent(Content, filename);
            notrans.LoadContent(Content, filename);
        }

        public void LoadContent(ContentManager Content, string filenameTrans, string filenameNoTrans,string filenameStetic,Color color)
        {
            trans = new BasicSprite(Rectangle.Empty,color);
            notrans = new BasicSprite(Rectangle.Empty,color);
            stetic = new BasicSprite(Rectangle.Empty, color);
            stetic.LoadContent(Content, filenameStetic);
            trans.LoadContent(Content, filenameTrans);
            overData = new Color[trans.GetWidth() * trans.GetHeight()];
            notrans.LoadContent(Content, filenameNoTrans);
            trans.GetData(overData);
            trans.setPos(new Rectangle(0, 0, trans.GetTexture().Width, trans.GetTexture().Height));
            notrans.setPos(new Rectangle(0, 0, notrans.GetTexture().Width, notrans.GetTexture().Height));
            //Console.WriteLine("trans pos"+trans.getPos());
        }
        public void Update(GameTime gameTime)
        {
        }
        public bool CollidingWithTrans(double xVal, double yVal, double characterWidth, double characterHeight)
        {

            //Console.WriteLine("window sizes " + BasicSprite.GetBoundaries().Width + " " + BasicSprite.GetBoundaries().Height);
            //Console.WriteLine("texture sizes " + trans.GetWidth() + " " + trans.GetHeight());
            double width_factor = (double)BasicSprite.GetBoundaries().Width / trans.GetWidth();
            double height_factor = (double)BasicSprite.GetBoundaries().Height / trans.GetHeight();
            //Console.WriteLine("orig vals: " + xVal + " " + yVal); Console.WriteLine("orig vals: " + xVal + " " + yVal);
            xVal /= width_factor;
            yVal /= height_factor;
            //Console.WriteLine("new vals: " + xVal + " " + yVal);
            //Console.WriteLine("orig sizes: " + characterWidth + " " + characterHeight);
            characterWidth /= width_factor;
            characterHeight /= height_factor;
            //Console.WriteLine("new sizes: " + characterWidth + " " + characterHeight);
            Color col1, col2, col3, col4, col5, col6, col7, col8;
            int xTex, yTex;
            ///left point
            xTex = (int)xVal;
            yTex = (int)yVal;
            col1 = overData[yTex * trans.GetWidth() + xTex];
            ///right point
            xTex = (int)(xVal + characterWidth);
            yTex = (int)yVal;
            col2 = overData[yTex * trans.GetWidth() + xTex];
            ///down left point
            xTex = (int)xVal;
            yTex = (int)(yVal + characterHeight);
            col3 = overData[yTex * trans.GetWidth() + xTex];
            ///down right point
            xTex = (int)(xVal + characterWidth);
            yTex = (int)(yVal + characterHeight);
            col4 = overData[yTex * trans.GetWidth() + xTex];
            ///up center
            xTex = (int)(xVal + characterWidth / 2);
            yTex = (int)yVal;
            col5 = overData[yTex * trans.GetWidth() + xTex];
            //left center
            xTex = (int)xVal;
            yTex = (int)(yVal + characterHeight / 2);
            col6 = overData[yTex * trans.GetWidth() + xTex];
            ///down center
            xTex = (int)(xVal + characterWidth / 2);
            yTex = (int)(yVal+characterHeight);
            col7 = overData[yTex * trans.GetWidth() + xTex];
            ///right center
            xTex = (int)(xVal + characterWidth);
            yTex = (int)(yVal+characterHeight/2);
            col8 = overData[yTex * trans.GetWidth() + xTex];
            //Console.WriteLine("cols " + col1+" "+col2+" "+col3+" "+col4+" "+col5+" "+col6+" "+col7+" "+col8);
            return col1.A!=0&&col2.A!=0&&col3.A!=0&&col4.A!=0&&col5.A!=0&&col6.A!=0&&col7.A!=0&&col8.A!=0; /// alpha in trans is differente from zero
        }
    }
}
