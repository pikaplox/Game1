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
    public class SpiderEgg : SpawnPoint
    {
        int maxSpawns, totalSpawns;
        
        public SpiderEgg(Vector2 POS, int OWNERID, XElement DATA) : base("2D\\Punga", POS, new Vector2(45,45), OWNERID, DATA)
        {
            totalSpawns = 0;
            maxSpawns = 3;

            health = 15;
            healthMax = health;
            spawnTimer = new McTimer(3000);
        }

        public override void Update(Vector2 OFFSET)
        {
            base.Update(OFFSET);
            if (totalSpawns >= maxSpawns)
            {
                dead = true;
            }
        }
        public override void SpawnMob()
        {
            Mob tempMob = new Enemigo2Little(new Vector2(pos.X, pos.Y), ownerId);
            if (tempMob != null)
            {
                GameGlobals.PassMob(tempMob);
                totalSpawns++;
            }
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
