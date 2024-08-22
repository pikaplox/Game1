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
    public class Tower : Building
    {

        
        public Tower(Vector2 POS, int OWNERID) : base("2d\\Buildings\\Tower", POS, new Vector2(45, 45), OWNERID)
        {
            health = 50;
            healthMax = health;

            hitDist = 35.0f;


        }

        public override void Update(Vector2 OFFSET, Player ENEMY)
        {

            base.Update(OFFSET);

        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
