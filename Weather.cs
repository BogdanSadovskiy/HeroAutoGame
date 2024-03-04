using System.Drawing;

namespace HeroAutoGame
{
    public abstract class Weather
    {
        protected Image weatherImage { get ; set; }
        protected string Name { get; set; }
        protected int missChance { get; set; }
        protected int magicResistance { get; set; }
        protected int healthRegeneration { get; set; }
        public abstract void setImage(); 
        public Image getWeatherImage(){ return weatherImage; }
        public string getName() { return Name; }
        public int getMissChance() {  return missChance; }
        public int getMagicResistance() {  return magicResistance; }
        public int getHealthRegeneration() { return healthRegeneration; }
        public override string ToString()
        {
            return $"{Name}\nMiss chance: {missChance}\n" +
                $"Magic resistance: {magicResistance}\n" +
                $"Health regeneration: {healthRegeneration}";
        }
    };
}
