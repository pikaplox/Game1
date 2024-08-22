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
    public class Enemigo2 : Mob
    {

        public McTimer spawnTimer;

        public Enemigo2(Vector2 POS, int OWNERID) : base("2d\\Byakuya", POS, new Vector2(40, 40), OWNERID)
        {
            this.speed = 1.8f;
            this.color = Color.White;
            this.health = 10;
            this.healthMax = health;
            damage = 4;
            spawnTimer = new McTimer(8000);
            spawnTimer.AddToTimer(4000);
        }


        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                SpawnEgg();
                spawnTimer.ResetToZero();
            }
            base.Update(OFFSET, ENEMY);
        }
        public virtual void SpawnEgg()
        {
            GameGlobals.PassSpawnPoint(new SpiderEgg(new Vector2(pos.X, pos.Y),ownerId, null));
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
