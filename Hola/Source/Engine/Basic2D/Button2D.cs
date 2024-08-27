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
    public class Button2D : Basic2D
    {

        public bool isPressed, isHovered;
        public string text;

        public Color hoverColor;

        public SpriteFont font;

        public object info;

        PassObject buttonClicked;
        
        public Button2D(string PATH, Vector2 POS, Vector2 DIMS, String FONTPATH, String TEXT, PassObject BUTTONCLICKED, object INFO) : base(PATH, POS, DIMS)
        {
            info = INFO;
            text=TEXT;
            buttonClicked = BUTTONCLICKED;
            if (FONTPATH != "")
            {
                font = Globals.content.Load<SpriteFont>(FONTPATH);
            }

            isPressed = false;
            hoverColor = new Color(200, 230, 255);

        }

        public override void Update(Vector2 OFFSET)
        {

            if (Hover(OFFSET))
            {
                isHovered = true;

                if (Globals.mouse.LeftClick())
                {
                    isHovered = false;
                    isPressed = true;
                }
                else if (Globals.mouse.LeftClickRelease())
                {
                    RunBtnClick();
                }
            }
            else
            {
                isHovered = false;
            }

            if (!Globals.mouse.LeftClick() && !Globals.mouse.LeftClickHold())
            {
                isPressed = false;
            }


            base.Update(OFFSET);

        }

        public virtual void Reset()
        {
            isPressed = false;
            isHovered = false;
        }

        public virtual void RunBtnClick()
        {
            if (buttonClicked != null)
            {
                buttonClicked(info);
            }

            Reset();
        }


        public override void Draw(Vector2 OFFSET)
        {

            Color tempColor = Color.White;
            if (isPressed)
            {
                tempColor = Color.Gray;
            }
            else if (isHovered)
            {
                tempColor = hoverColor;
            }

            

            base.Draw(OFFSET);


            Vector2 strDims = font.MeasureString(text);
            Globals.spriteBatch.DrawString(font, text, pos + OFFSET + new Vector2(-strDims.X/2, -strDims.Y/2), Color.Black);
        }
        

    }
}
