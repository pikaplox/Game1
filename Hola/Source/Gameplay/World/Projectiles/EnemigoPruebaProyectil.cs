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
using System.IO;

#endregion
namespace Hola
{
    public class EnemigoPruebaProyectil : Projectile2D
    {

        public EnemigoPruebaProyectil(Vector2 POS, AttackableObject OWNER, Vector2 TARGET) : base("2d\\Projectiles\\Bala", POS, new Vector2(35, 35), OWNER, TARGET)
        {
            timer = new McTimer(10000);
            done = false;
            this.speed = 10.0f;
            this.owner = OWNER;
            damage = 5;
            direction = TARGET - owner.pos;
            direction.Normalize();
            rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));

        }

        public override void Update(Vector2 OFFSET, List<AttackableObject>UNITS, Monokuma HERO)
        {
            base.Update(OFFSET, UNITS, HERO);
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
