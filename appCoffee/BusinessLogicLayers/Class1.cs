using System;
using System.Collections;
using System.Collections.Generic;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            //create players with heroes
            Player p1, p2;
            p1 = new Player();
            p2 = new Player();
            p1.SummonHero(1);
            p1.SummonHero(2);
            p1.SummonHero(3);
            p2.SummonHero(1);   //only has an archer
            //create an item and equip it to all heroes of p1
            Item i = new Item(0, 50, 50);
            foreach (Hero h in p1.heroes)
                h.Equip(i);
            //let player 1 attack player 2's only hero until dead
            Hero target = (Hero)p2.heroes[0];
            foreach (Hero h in p1.heroes)
            {
                h.Attack(target);
                if (target.health <= 0) break;
                h.PerformSkill(target);
                if (target.health <= 0) break;
            }
        }
    }
    #region Hero
    public abstract class Hero
    {
        protected string name;
        protected int level;
        public int health;
        public int atk, def;
        public HeroSkill aSkill;
        protected ArrayList items = new ArrayList();
        public abstract int Attack(Hero target);

        public void Equip(Item i)
        {
            this.items.Add(i);
            this.health += i.hbuf;
            this.atk += i.abuf;
            this.def += i.dbuf;
        }
        public virtual bool checkMana() { return true; }
        public bool checkDead(Hero t)
        {
            return (t.health <= 0);
        }
        public virtual int getSkillDamage(Hero t)
        {
            return Math.Max(aSkill.Action(t) - t.def, 0);
        }
        public int PerformSkill(Hero t)
        {
            if (!checkMana()) return 0;
            int dam = getSkillDamage(t);
            t.health -= dam;
            if (checkDead(t)) Console.WriteLine("Killed!");
            return dam;
        }
    }
    public class Archer : Hero
    {
        public override int Attack(Hero target)
        {
            Console.WriteLine("I'm attacking with an arrow!");
            int dam = Math.Max(this.atk - target.def, 0);
            target.health -= dam;
            if (target.health <= 0)
                Console.WriteLine("And kill!");
            return dam;
        }
    }
    public class Warrior : Hero
    {
        public override int Attack(Hero target)
        {
            Console.WriteLine("I'm attacking with a sword!");
            int dam = Math.Max(this.atk - target.def, 0);
            target.health -= dam;
            if (target.health <= 0)
                Console.WriteLine("And kill!");
            return dam;
        }
    }
    public class Mage : Hero
    {
        public override int Attack(Hero target)
        {
            Console.WriteLine("I'm attacking with magic!");
            int dam = Math.Max(this.atk - target.def, 0);
            target.health -= dam;
            if (target.health <= 0)
                Console.WriteLine("And kill!");
            return dam;
        }
    }
    #endregion  //Hero

    #region HeroSkill
    public abstract class HeroSkill
    {
        public int dmg;
        public abstract int Action(Hero target);
    }
    public class ArcherSkill : HeroSkill
    {
        public override int Action(Hero target)
        {
            Console.WriteLine("Performing Archer's skill!");
            return this.dmg;
        }
    }
    public class WarriorSkill : HeroSkill
    {
        public override int Action(Hero target)
        {
            Console.WriteLine("Performing Warrior's skill!");
            return this.dmg;
        }
    }
    public class MageSkill : HeroSkill
    {
        public override int Action(Hero target)
        {
            Console.WriteLine("Performing Mage's skill!");
            return this.dmg;
        }
    }
    #endregion //HeroSkill

    #region HeroBuilder
    public class HeroBuilder
    {
        protected static HeroBuilder builder;
        protected HeroBuilder() { }
        public static HeroBuilder getBuilder()
        {
            if (builder == null) builder = new HeroBuilder();
            return builder;
        }
        public Hero getHero(int type)
        {
            Hero h;
            switch (type)
            {
                case 1:
                    h = new Archer();
                    h.health = 500; h.atk = 150; h.def = 50;
                    break;
                case 2:
                    h = new Warrior();
                    h.health = 700; h.atk = 100; h.def = 80;
                    break;
                case 3:
                    h = new Mage();
                    h.health = 400; h.atk = 200; h.def = 40;
                    break;
                default: return null;
            }
            return h;
        }
        public HeroSkill getHeroSkill(int type)
        {
            HeroSkill h;
            switch (type)
            {
                case 1:
                    h = new ArcherSkill();
                    h.dmg = 300; break;
                case 2:
                    h = new WarriorSkill();
                    h.dmg = 150; break;
                case 3:
                    h = new MageSkill();
                    h.dmg = 450; break;
                default: return null;
            }
            return h;
        }
    }
    #endregion //HeroBuilder

    #region Item
    public class Item
    {
        public int hbuf, abuf, dbuf;
        public Item(int h, int a, int d)
        {
            hbuf = h; abuf = a; dbuf = d;
        }
    }
    #endregion //Item

    #region Player
    public class Player
    {
        protected string name;
        protected int server;
        public ArrayList items = new ArrayList();
        public ArrayList heroes = new ArrayList();
        public void SummonHero(int type)
        {
            Hero h;
            HeroSkill hs;
            h = HeroBuilder.getBuilder().getHero(type);
            hs = HeroBuilder.getBuilder().getHeroSkill(type);
            if (h != null)
            {
                h.aSkill = hs;
                heroes.Add(h);
            }
        }
    }
    #endregion //Player
}
