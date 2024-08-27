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
using Hola.Source.Gameplay;
using SharpDX.MediaFoundation;

#endregion

namespace Hola
{
    public class MainMenu
    {
        public Basic2D bg;

        public PassObject PlayClickDel, ExitClickDel;

        public List<Button2D> buttons = new List<Button2D>();

        public MainMenu(PassObject PLAYCLICKDEL, PassObject EXITCLICKDEL)
        {
            PlayClickDel = PLAYCLICKDEL;
            ExitClickDel = EXITCLICKDEL;

            bg = new Basic2D("2D\\UI\\MainMenuBkg", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(Globals.screenWidth, Globals.screenHeight));

            buttons.Add(new Button2D(("2D\\Misc\\SimpleBtn"), new Vector2(0, 0), new Vector2(96, 32), "2D\\Ola", "PLAY", PlayClickDel, 1));
            buttons.Add(new Button2D(("2D\\Misc\\SimpleBtn"), new Vector2(0, 0), new Vector2(96, 32), "2D\\Ola", "EXIT", ExitClickDel, null));

        }


        public virtual void Update()
        {
            for (int i = 0; i<buttons.Count(); i++)
            {
                buttons[i].Update(new Vector2(340, 600 + 45 * i));
            }
        }

        public virtual void Draw() 
        {
            bg.Draw(Vector2.Zero);

            for (int i = 0; i < buttons.Count(); i++)
            {
                buttons[i].Draw(new Vector2(340, 600 + 45 * i));
            }

        }

    }
}
