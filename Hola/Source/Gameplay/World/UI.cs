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
    public class UI
    {
        public Basic2D pauseOverlay;

        public SpriteFont font;
        public QuantityDisplayBar quantityDisplayBar;
        public UI()
        {
            pauseOverlay = new Basic2D("2D\\Misc\\PauseOverlay", new Vector2(Globals.screenWidth/2, Globals.screenHeight/2), new Vector2(300,300));
            font = Globals.content.Load<SpriteFont>("2D\\ola");
            quantityDisplayBar = new QuantityDisplayBar(new Vector2(104, 16), 2, Color.Red);
        }
        public void Update(World WORLD)
        {
            quantityDisplayBar.Update(WORLD.user.monokuma.health, WORLD.user.monokuma.healthMax);
        }
        public void Draw(World WORLD)
        {
            


            string tempStr = "Kills: " + GameGlobals.score;
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2 (Globals.screenWidth/2 - strDims.X/2, Globals.screenHeight - 40), Color.Black);

            string tempVida = "VIDA: " + WORLD.user.monokuma.health;
            Vector2 strDims3 = font.MeasureString(tempVida);
            Globals.spriteBatch.DrawString(font, tempVida, new Vector2(Globals.screenWidth / 2 - strDims3.X / 2, Globals.screenHeight - 60), Color.Black);

            string tempOffset = "OFFSET X: " + WORLD.offset.X.ToString() + " -- OFFSET Y: " + WORLD.offset.Y.ToString();
            Vector2 strDims2 = font.MeasureString(tempOffset);
            Globals.spriteBatch.DrawString(font, tempOffset, new Vector2(Globals.screenWidth / 2 - strDims2.X / 2, Globals.screenHeight - 20), Color.Black);

            if (WORLD.user.monokuma.dead || WORLD.user.buildings.Count <= 0)
            {
                tempStr = "Press Enter to restart";
                strDims = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight / 2), Color.Black);
            }
            quantityDisplayBar.Draw(new Vector2(20, Globals.screenHeight - 40));

            if (GameGlobals.paused)
            {
                pauseOverlay.Draw(Vector2.Zero);
            }

        }
    }
}
