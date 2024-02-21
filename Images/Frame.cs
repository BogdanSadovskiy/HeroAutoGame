using System.Drawing;

namespace HeroAutoGame.Images
{
    internal class Frame
    {

        Image gameFrame = new Bitmap( global::HeroAutoGame.Properties.Resources.frame);
        public void drawFrame(Graphics graphics, Size clientSize)
        {
           
            graphics.DrawImage(gameFrame,0,0,clientSize.Width, clientSize.Height );
        }


    }
}
