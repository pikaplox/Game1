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
using SharpDX.DXGI;
using SharpDX.MediaFoundation;
using Hola.Source.Engine;
using Hola.Source.Gameplay.World;

#endregion

namespace Hola
{
    public class Basic2D
    {
        public Color color = Color.White;
        public float rot;
        public Vector2 pos, dims;
        public Texture2D myModel;
        public Vector2 offset = Vector2.Zero;   

        public Basic2D(string PATH, Vector2 POS, Vector2 DIMS) 
        {
            this.pos = POS;
            this.dims = DIMS;
            myModel = Globals.content.Load<Texture2D>(PATH);

        }
        public Basic2D(string PATH, Vector2 DIMS)
        {
            myModel = Globals.content.Load<Texture2D>(PATH);
            this.dims = DIMS;
        }
        public virtual void Update(Vector2 OFFSET)
        {
            
        }

        public virtual bool Hover(Vector2 OFFSET)
        {
            return HoverImg(OFFSET);
        }

        public virtual bool HoverImg(Vector2 OFFSET)
        {
            Vector2 mousePos = new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y);

            if (mousePos.X >= (pos.X + OFFSET.X) - dims.X/2 && mousePos.X <= (pos.X + OFFSET.X) + dims.X / 2 && mousePos.Y >= (pos.Y + OFFSET.Y) - dims.Y / 2 && mousePos.Y <= (pos.Y + OFFSET.Y) + dims.Y / 2)
            {
                return true;
            }

            return false;
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if(myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y),null, color, rot, new Vector2(myModel.Bounds.Width/2, myModel.Bounds.Height/2), new SpriteEffects(), 0);
            }

        } 
        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN, Color COLOR)
        {
            if(myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, COLOR, rot, new Vector2(ORIGIN.X, ORIGIN.Y), new SpriteEffects(), 0);
            }

        }


    }
}
