﻿#region
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
    public class ArrowTower : Building
    {
        int range;
        McTimer shotTimer = new McTimer(800);
        
        public ArrowTower(Vector2 POS, int OWNERID) : base("2d\\Buildings\\Tower", POS, new Vector2(45, 45), OWNERID)
        {
            range = 500;
            
            health = 10;
            healthMax = health;

            hitDist = 35.0f;


        }

        public override void Update(Vector2 OFFSET, Player ENEMY)
        {

            shotTimer.UpdateTimer();
            if (shotTimer.Test()) 
            {
                FireArrow(ENEMY);
                shotTimer.ResetToZero();
            }


            base.Update(OFFSET);

        }

        public virtual void FireArrow(Player ENEMY)
        {
            float closestDist = range, currentDist = 0;
            Unit closest = null;

            for(int i = 0; i<ENEMY.units.Count; i++)
            {
                currentDist = Globals.GetDistance(pos, ENEMY.units[i].pos);

                if (closestDist > currentDist) 
                {
                    closestDist = currentDist;
                    closest = ENEMY.units[i];
                }

            }

            if (closest != null)
            {

                GameGlobals.PassProjectile(new Arrow(new Vector2(pos.X, pos.Y), this, new Vector2(closest.pos.X, closest.pos.Y)));
            }


        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
