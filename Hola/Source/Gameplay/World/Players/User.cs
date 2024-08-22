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
using System.Security.Cryptography;
using Microsoft.VisualBasic.ApplicationServices;


#endregion

namespace Hola
{


    public class User : Player
    {
  
        public User(int ID, XElement DATA) : base(ID, DATA)
        {
           // monokuma = new Monokuma("2D\\Monokuma1", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(73, 87), id);

           // buildings.Add(new Tower(new Vector2(Globals.screenWidth / 2, Globals.screenHeight - 40), id));
        }
        public override void Update(Player ENEMY, Vector2 OFFSET)
        {
            base.Update(ENEMY, OFFSET);
        }

       
        
    }
}
