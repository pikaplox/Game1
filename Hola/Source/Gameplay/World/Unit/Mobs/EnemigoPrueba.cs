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
using Hola.Source.Gameplay.World;
using System.Runtime.CompilerServices;
using SharpDX.MediaFoundation;

using System.Security.Cryptography.X509Certificates;

#endregion

namespace Hola
{
    public class EnemigoPrueba : Mob
    {
        public McTimer stop, walk;
        
        


        public EnemigoPrueba(Vector2 POS, int OWNERID) : base("2d\\EnemigoPrueba", POS, new Vector2(40, 40), OWNERID)
        {
            this.speed = 2.0f;
            this.color = Color.Green;
            this.health = 3;
            this.healthMax = health;
            this.damage = 4;
            stop = new McTimer(2000);
            walk = new McTimer(4000);


        }


        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            stop.UpdateTimer();          
            walk.UpdateTimer();
            AI(ENEMY.monokuma, OFFSET);


            base.Update(OFFSET, ENEMY);
        }

        public virtual void AI(Monokuma HERO, Vector2 OFFSET)
        {
            

            // daño por la distancia entre monokuma y enemigoPrueba
            if (Globals.GetDistance(this.pos, HERO.pos) < 15)
            {
                HERO.GetHit(this.damage);
                this.dead = true;
            }

            // camina 2s, para 1s, dispara, repite.

            if (stop.Test())
            {


                GameGlobals.PassProjectile(new EnemigoPruebaProyectil(new Vector2(pos.X, pos.Y), this, HERO.pos - OFFSET));

                stop.ResetToZero();
            }
            
            
           
        }

        
        

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
