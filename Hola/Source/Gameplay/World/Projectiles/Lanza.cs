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
using System.Windows.Forms.Design;
#endregion

namespace Hola
{
    public class Lanza : Projectile2D
    {
        Random rnd = new Random();
        public Vector2 tarjet;
        
        
        public Lanza(Unit OWNER, Vector2 TARGET) : base("2d\\Projectiles\\Lanza", new Vector2(8, 75), OWNER, TARGET)
        {
            this.timer = new McTimer(10000);
            this.done = false;
            this.speed = 20.0f;
            this.owner = OWNER;
            this.damage = 5;
            this.pos = calcularOrigen(TARGET);
            this.direction = TARGET - pos;
            this.direction.Normalize();
            this.tarjet = TARGET;
            this.rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));

        }



        public override void Update(Vector2 OFFSET, List<AttackableObject> UNITS, Monokuma HERO)
        {
            base.Update(OFFSET, UNITS, HERO);
            if (Globals.GetDistance(pos,tarjet) < 10)
            {
                done = true;
            }
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
        public Vector2 calcularOrigen(Vector2 TARGET)
        {
            int random;
            random = rnd.Next(1,4);
            Vector2 paredA = new Vector2(rnd.Next(800, 1601), 0);
            Vector2 paredB = new Vector2(1600, rnd.Next(0,901));
            Vector2 paredC = new Vector2(rnd.Next(800, 1601), 900);

            Vector2 paredA1 = new Vector2(rnd.Next(0, 801), 0);
            Vector2 paredB2 = new Vector2(0, rnd.Next(0, 901));
            Vector2 paredC3 = new Vector2(rnd.Next(0, 800), 901);
            if (TARGET.X >= 800)
            {
                if (random == 1) 
                {
                    return paredA;
                }
                if (random == 2)
                {
                    return paredB;
                }
                if (random == 3)
                {
                    return paredC;
                }
                
            }
            if (TARGET.X < 800)
            {
                if (random == 1)
                {
                    return paredA1;
                }
                if (random == 2)
                {
                    return paredB2;
                }
                if (random == 3)
                {
                    return paredC3;
                }
                
            }
            return Vector2.Zero;

        }
       
    }
}
