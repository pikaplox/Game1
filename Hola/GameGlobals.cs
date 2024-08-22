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
    public class GameGlobals
    {
        public static int score = 0;

        public static PassObject PassProjectile, PassBuilding, PassMob, PassSpawnPoint, PassMarca, CheckScroll, CheckScrollDash;

       
    }
}
