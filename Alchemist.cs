using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAutoGame
{
    public class Alchemist : Hero
    {
        public Alchemist()
        {

            this.Name = "Alchemist";
            this.HeroDescr = "Starting gold - 1200\nHas increased gold income by 48\n" +
                "When Sunny - gold income + 10\n" + "When Cloudy - gold income + 5\n"
                + "When Dark night - gold income +19 / physical damage -30";

            this.defaultHealth = 2500;
            this.defaultHealthRegeneration = 27;
            this.damageType = DamageType.Physical;
            this.defaultPhysicleDamage = 150;
            this.defaultMagicalDamage = 0;
            this.defaultCriticalChance = 0;
            this.defaultDodgeChance = 5;
            this.defaultMagicalResistance = 20;
            this.defaultPhysicalResistance = 25;
            this.defaultMissChance = 0;

            this.Health = this.defaultHealth;
            this.currenthealth = Health;
            this.HealthRegeneration = this.defaultHealthRegeneration;
            this.PhysicalDamage = this.defaultPhysicleDamage;
            this.MagicalDamage = this.defaultMagicalDamage;
            this.PhysicalResistance = this.defaultPhysicalResistance;
            this.MagicalResistance = this.defaultMagicalResistance;
            this.CriticalChance = this.defaultCriticalChance;
            this.DodgeChance = this.defaultDodgeChance;
            this.MissChance = this.defaultMissChance;
            this.numberOFAttack = 0;
            this.returnedDamage = 0;
            this.damageDealt = 0;
            this.damageRecived = 0;
            this.Gold = 1200;
            this.GoldIncrease = 48;
        }

        public override int heroFeatureMagicalAttack()
        {
            return commonMagicalAttack();
        }

        public override int heroFeaturePhysicalAttack()
        {
            return commonPhisicalAttack();
        }

        public override void weatherFactors(Weather weather)
        {

            if (weather.getName().Equals( "Sunny"))
            {
                this.GoldIncrease += 10;
            }
            if (weather.getName().Equals("Dark night"))
            {
                this.GoldIncrease += 19;
                this.PhysicalDamage -= 30;
            }
            if (weather.getName().Equals("Cloudy"))
            {
                this.GoldIncrease += 5;
            }
            this.HealthRegeneration += weather.healthRegeneration;
            this.MagicalResistance += weather.magicResistance;
            this.MissChance += weather.missChance;

        }




    }
}
