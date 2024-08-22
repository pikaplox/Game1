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
    public class Enemigo : Mob
    {



        public Enemigo(Vector2 POS, int OWNERID) : base("2d\\Mob", POS, new Vector2(40, 40), OWNERID)
        {
            this.speed = 2.0f;
            this.color = Color.White;
            this.health = 5;
            this.healthMax = health;
            damage = 4;
        }


        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            
            base.Update(OFFSET, ENEMY);
        }



        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
