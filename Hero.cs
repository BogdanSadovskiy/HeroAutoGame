using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroAutoGame
{


    abstract public class Hero
    {
        public Random random = new Random();
        public List<Artefact> artefacts = new List<Artefact>();
        public int numberOFAttack;
        public string Name { get; set; }
        public string HeroDescr { get; set; }
        public int defaultHealth { get; set; }
        public int defaultHealthRegeneration { get; set; }
        public DamageType damageType { get; set; }
        public int defaultPhysicleDamage { get; set; }
        public int defaultMagicalDamage { get; set; }
        public int defaultPhysicalResistance { get; set; }
        public int defaultMagicalResistance { get; set; }
        public int defaultCriticalChance { get; set; }
        public int defaultDodgeChance { get; set; }
        public int defaultMissChance { get; set; }
        public int defaultReturnedDamage { get; set; }


        public int Gold { get; set; }
        public int GoldIncrease { get; set; }
        public int Health { get; set; }
        public int currenthealth { get; set; }
        public int HealthRegeneration { get; set; }
        public int PhysicalDamage { get; set; }
        public int MagicalDamage { get; set; }
        public int PhysicalResistance { get; set; }
        public int MagicalResistance { get; set; }
        public int CriticalChance { get; set; }
        public int DodgeChance { get; set; }
        public int MissChance { get; set; }
        public int returnedDamage { get; set; }
        public int damageDealt { get; set; }
        public int damageRecived { get; set; }
        public int healed { get; set; }


        public int isArtefactsFull()
        {
            return artefacts.Count();
        }
        public void returnedDamageManage()
        {
            int returnDMG = 0;
            foreach (Artefact a in artefacts)
            {
                if (a.returnedDamage > returnDMG) returnDMG = a.returnedDamage;
            }
            if (returnDMG > 0) this.returnedDamage = returnDMG + defaultReturnedDamage;
            else
            {
                this.returnedDamage = defaultReturnedDamage;
            }
        }
        public void removeArtefact(int index)
        {
            this.Health -= this.artefacts[index].health;
            this.currenthealth -= this.artefacts[index].health;
            this.HealthRegeneration -= this.artefacts[index].HealthRegeneration;
            this.PhysicalDamage -= this.artefacts[index].physicalDamage;
            this.MagicalDamage -= this.artefacts[index].magicalDamage;
            this.PhysicalResistance -= this.artefacts[index].PhysicalResistance;
            this.MagicalResistance -= this.artefacts[index].MagicalResistance;
            this.CriticalChance -= this.artefacts[index].CriticalChance;
            this.DodgeChance -= this.artefacts[index].DodgeChance;
            this.MissChance -= this.artefacts[index].MissChance;
            this.GoldIncrease -= this.artefacts[index].GoldIncrease;
            this.artefacts.RemoveAt(index);
            returnedDamageManage();
        }
        public void addArtefact(Artefact a)
        {

            if (a != null)
            {
                this.artefacts.Add(a);
                this.Health += a.health;
                this.currenthealth += a.health;
                this.HealthRegeneration += a.HealthRegeneration;
                this.PhysicalDamage += a.physicalDamage;
                this.MagicalDamage += a.magicalDamage;
                this.PhysicalResistance += a.PhysicalResistance;
                this.MagicalResistance += a.MagicalResistance;
                this.CriticalChance += a.CriticalChance;
                this.DodgeChance += a.DodgeChance;
                this.MissChance += a.MissChance;
                this.GoldIncrease += a.GoldIncrease;
                this.returnedDamage += a.returnedDamage;
                returnedDamageManage();

            }
        }
        abstract public void weatherFactors(Weather weather);
        public int returnedDMG(int DMG)
        {
            if (this.returnedDamage == 0) { return 0; }
            int d = (int)(DMG * (0.01 * this.returnedDamage));
            Console.Write(this.Name + " returned damage - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(d);
            Console.ResetColor();
            return d;
        }

        public void HealthCheking()
        {
            if (this.currenthealth < 0)
            {
                currenthealth = 0;
            }
            if (currenthealth > this.Health)
            {
                currenthealth = Health;
            }
        }
        abstract public int heroFeatureMagicalAttack();
        abstract public int heroFeaturePhysicalAttack();
        public int commonPhisicalAttack()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if (random.Next(1, 100) <= this.MissChance)
            {
                Console.Write("Miss ");
                return 0;
            }
            double dmg = this.PhysicalDamage;
            if (random.Next(1, 100) <= this.CriticalChance)
            {
                Console.Write("Critical  ");
                double critical = this.CriticalChance / 100;
                dmg *= (critical + 1);

            }
            this.damageDealt += (int)dmg;
            Console.ResetColor();
            return (int)dmg;
        }
        public int phisicalAttack()
        {
            return heroFeaturePhysicalAttack();
        }
        public int commonMagicalAttack()
        {
            this.damageDealt += this.MagicalDamage;
            return this.MagicalDamage;
        }
        public int magicalAttack()
        {
            return heroFeatureMagicalAttack();
        }
        public int Regeneration()
        {
            this.currenthealth += this.HealthRegeneration;
            HealthCheking();
            this.healed += this.HealthRegeneration;
            return this.HealthRegeneration;
        }
        private int getAttakedPhysicalDamage(int physicalDamage_)
        {

            if (physicalDamage_ == 0) return 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            double dmg = (double)physicalDamage_;
            if (random.Next(1, 100) <= this.DodgeChance)
            {
                Console.WriteLine("Dodged");
            }
            else
            {
                double kofOfPhysicleResistanse = (0.052 * this.PhysicalResistance) /
                    (0.9 + 0.048 * this.PhysicalResistance);
                dmg *= (1 - kofOfPhysicleResistanse);
                Console.WriteLine("Physical damage - " + (int)dmg);
            }
            Console.ResetColor();
            return (int)dmg;
        }

        private int getAttackeMagicalDamage(int magicalDamage_)
        {
            if (magicalDamage_ == 0) return 0;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            double dmg = (double)magicalDamage_;
            double kofOfMagResistanse = (0.052 * this.MagicalResistance) /
                       (0.9 + 0.048 * this.MagicalResistance);
            dmg *= (1 - kofOfMagResistanse);
            Console.Write("Magical damage ");
            Console.WriteLine((int)dmg);
            Console.ResetColor();
            return (int)dmg;
        }

        public int getAttacked(int physicalDamage_, int magicalDamage_)
        {
            int damageRecivedPerThisAttack = getAttakedPhysicalDamage(physicalDamage_) + getAttackeMagicalDamage(magicalDamage_);
            this.currenthealth -= damageRecivedPerThisAttack;
            HealthCheking();
            return damageRecivedPerThisAttack;
        }

        public void DamageCounter(int damage)
        {
            this.damageDealt += damage;
        }

        public void GoldEarn(Hero enemyHero)
        {
            if (enemyHero.Health == 0)
            {
                this.Gold += 2000;
            }
            this.Gold += 68 + GoldIncrease;
        }
        public bool isHeroAlive()
        {
            if (this.currenthealth <= 0)
            {
                return false;
            }
            return true;
        }
        public void other(Hero hero, int damage)
        {
            hero.DamageCounter(hero.returnedDMG(damage)); //counting returned damage
            this.Regeneration();
            this.GoldEarn(hero);

        }
    };
}


