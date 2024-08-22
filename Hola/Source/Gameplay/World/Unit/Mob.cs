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
    public class Mob : Unit
    {

       

        public Mob(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID) : base(PATH, POS, DIMS, OWNERID)
        {
            this.speed = 3.0f;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            AI(ENEMY);
            
            base.Update(OFFSET);

        }
        public virtual void AI(Player ENEMY)
        {
            pos += Globals.RadialMovement(ENEMY.monokuma.pos, pos, speed);
            if (Globals.GetDistance(this.pos, ENEMY.monokuma.pos) <15)
            {
                ENEMY.monokuma.GetHit(this.damage);
                this.dead = true;
            }
            // rot = Globals.RotateTowards(pos, HERO.pos);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
