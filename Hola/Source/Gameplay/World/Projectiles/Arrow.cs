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
    public class Arrow : Projectile2D
    {

        public Arrow(Vector2 POS, AttackableObject OWNER, Vector2 TARGET) : base("2d\\Projectiles\\Bala", POS, new Vector2(18, 35), OWNER, TARGET)
        {
            damage = 5;
            speed = 10;
            timer = new McTimer(800);
            this.owner = OWNER;
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
