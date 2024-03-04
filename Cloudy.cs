using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroAutoGame
{
    internal class Cloudy : Weather
    {
        public Cloudy()
        {
            this.Name = "Cloudy";
            this.missChance = 10;
            this.magicResistance = -5;
            this.healthRegeneration = 5;
            setImage();
        }

        public override void setImage()
        {
            string fontPath = @"..\..\Images\Cloudy.png";
            this.weatherImage = new Bitmap(Path.Combine(Application.StartupPath, fontPath));
        }
    }
}
