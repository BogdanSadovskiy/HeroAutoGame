using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HeroAutoGame
{

    public class DarkNight : Weather
    {
        public DarkNight()
        {
            this.Name = "Dark night";
            this.healthRegeneration = -5;
            this.missChance = 20;
            this.magicResistance = -10;
            setImage();
        }

        public override void setImage()
        {
            string fontPath = @"..\..\Images\DarkNight.png";
            this.weatherImage = new Bitmap(Path.Combine(Application.StartupPath, fontPath));
        }
    }

}
