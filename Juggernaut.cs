using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAutoGame
{
    public class Juggernaut : Hero
    {
        public Juggernaut()
        {

            this.Name = "Juggernaut";
            this.HeroDescr = "Every 3 deals 175% damage\n" +
                "When Sunny - magical resistance +15";

            this.defaultHealth = 2600;
            this.defaultHealthRegeneration = 27;
            this.damageType = DamageType.Physical;
            this.defaultPhysicleDamage = 160;
            this.defaultMagicalDamage = 0;
            this.defaultCriticalChance = 20;
            this.defaultDodgeChance = 5;
            this.defaultMagicalResistance = 20;
            this.defaultPhysicalResistance = 30;
            this.defaultMissChance = 0;
            this.defaultReturnedDamage = 0;

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
            this.returnedDamage = this.defaultReturnedDamage;
            this.damageDealt = 0;
            this.damageRecived = 0;
            this.Gold = 1000;
            this.GoldIncrease = 0;
        }



        public override void weatherFactors(Weather weather)
        {
            this.HealthRegeneration += weather.healthRegeneration;
            if (weather.getName().Equals("Sunny"))
            {
                this.MagicalResistance += 15;
            }
            else
            {
                this.MagicalResistance += weather.magicResistance;
            }
            this.MissChance += weather.missChance;

        }
        public override int heroFeaturePhysicalAttack()
        {
            double dmg = (double)commonPhisicalAttack();
            if (dmg > 0 && this.numberOFAttack == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Ability used 1.75% dmg");
                numberOFAttack = 0;
                this.damageDealt -= (int)dmg;
                damageDealt += (int)(dmg * 1.75);
                Console.ResetColor();
                return (int)(dmg * 1.75); /// hero ability to get increased damage

            }
            numberOFAttack++;
            return (int)dmg;
        }

        public override int heroFeatureMagicalAttack()
        {
            return commonMagicalAttack();
        }
    }
}
