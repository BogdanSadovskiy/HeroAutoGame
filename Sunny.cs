using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroAutoGame
{
    public class Sunny : Weather
    {
        public Sunny()
        {
            this.Name = "Sunny";
            this.healthRegeneration = 10;
            this.magicResistance = 5;
            this.missChance = 0;
            setImage();
        }

        public override void setImage()
        {
            string fontPath = @"..\..\Images\Sunny.png";
            this.weatherImage = new Bitmap( Path.Combine(Application.StartupPath, fontPath));
        }
    }
}
