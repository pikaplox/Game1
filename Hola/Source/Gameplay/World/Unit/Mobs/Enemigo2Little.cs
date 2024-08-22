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
    public class Enemigo2Little : Mob
    {


        public Enemigo2Little(Vector2 POS, int OWNERID) : base("2d\\Byakuya", POS, new Vector2(20, 20), OWNERID)
        {
            this.speed = 3f;
            damage = 2;

        }


        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            AI(ENEMY);
            base.Update(OFFSET, ENEMY);
        }

        public override void AI(Player ENEMY)
        {
            Building temp = null;
            for (int i = 0; i < ENEMY.buildings.Count; i++) 
            {
                if(ENEMY.buildings[i].GetType().ToString() == "Hola.Tower")
                {
                    temp = ENEMY.buildings[i];
                }
            
            }
            if (temp != null) 
            {
                pos += Globals.RadialMovement(temp.pos, pos, speed);

                if (Globals.GetDistance(this.pos, temp.pos) < 15)
                {
                    temp.GetHit(this.damage);
                    this.dead = true;
                }
            }



           
            
            // rot = Globals.RotateTowards(pos, HERO.pos);
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
