using System.Drawing;

namespace HeroAutoGame
{
    public abstract class Weather
    {
        public Image weatherImage { get; set; }
        protected string Name { get; set; }
        public int missChance { get; set; }
        public int magicResistance { get; set; }
        public int healthRegeneration { get; set; }
        public abstract void setImage();
        public Image getWeatherImage() { return weatherImage; }
        public string getName() { return Name; }
        public int getMissChance() { return missChance; }
        public int getMagicResistance() { return magicResistance; }
        public int getHealthRegeneration() { return healthRegeneration; }
        public override string ToString()
        {
            string weatherMissChance = "Miss chance:" + missChance.ToString();
            string weatherMagicResistance = "Magic resistance:" + magicResistance.ToString();
            string weatherHealthRegeneration = "Health regeneration:" + healthRegeneration.ToString();
            string buildString = Name;
            if (missChance != 0) buildString += "\n" + weatherMissChance;
            if (magicResistance != 0) buildString += "\n" + weatherMagicResistance;
            if (healthRegeneration != 0) buildString += "\n" + weatherHealthRegeneration;
            return buildString;
        }
    }
}
