#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Hola.Source.Engine;

#endregion
namespace Hola
{
    public class Projectile2D : Basic2D
    {
        public bool done;
        public float speed;
        public Vector2 direction;
        public AttackableObject owner;
        public Unit Target;
        public McTimer timer;
        public float damage;

        public Projectile2D(string PATH, Vector2 POS, Vector2 DIMS, AttackableObject OWNER, Vector2 TARGET) : base(PATH, POS, DIMS)
        {
            
            //timer = new McTimer(10000);
            
        }

        public Projectile2D(string PATH, Vector2 POS, Vector2 DIMS, Unit OWNER, Unit TARGET) : base(PATH, POS, DIMS)
        {
            done = false;
            this.speed = 7.0f;
            this.owner = OWNER;
            direction = TARGET.pos - owner.pos;
            direction.Normalize();
            
        }
        public Projectile2D(string PATH, Vector2 DIMS, Unit OWNER, Vector2 TARGET) : base(PATH, DIMS) 
        { 
        
        }


        public virtual void Update(Vector2 OFFSET, List<AttackableObject>UNITS, Monokuma HERO)
        {
            pos += (direction * speed);
            timer.UpdateTimer();
            if (timer.Test())
            {
                done = true;
            }
            if (HitSomething(UNITS, HERO))
            {
                done = true;
            }
        }
        public virtual bool HitSomething(List<AttackableObject> UNITS, Monokuma HERO)
        {
            for (int i = 0; i<UNITS.Count; i++)
            {
                // para heal se usa ==
                if (owner.ownerId != UNITS[i].ownerId && Globals.GetDistance(pos, UNITS[i].pos) < UNITS[i].hitDist)
                {
                    UNITS[i].GetHit(this.damage);
                    if (UNITS[i].dead)
                    {
                        CalcularHP(HERO);
                    }
                    return true;
                }else if (owner.ownerId != HERO.ownerId && Globals.GetDistance(pos, HERO.pos) < UNITS[i].hitDist)
                {
                    HERO.GetHit(this.damage);   
                    
                    return true;
                }
            }

            return false;
        }
        public void CalcularHP(Monokuma HERO)
        {
            HERO.health += 2;
            if (HERO.health > HERO.healthMax)
            {
                HERO.health = HERO.health - (HERO.health - HERO.healthMax);
            }
        }
        public override void Draw(Vector2 OFFSET)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["xDraw"].SetValue((float)(int)dims.X);
            Globals.normalEffect.Parameters["yDraw"].SetValue((float)(int)dims.Y);
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();



            base.Draw(OFFSET);
        }
    }
}
