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
using SharpDX.Direct3D11;

#endregion

namespace Hola
{
    public class QuantityDisplayBar
    {
        public int boarder;
        public Basic2D bar, barBG;
        public Color color;
        public QuantityDisplayBar(Vector2 DIMS, int BOARDER, Color COLOR)
        {
            boarder = BOARDER;
            color = COLOR;
            bar = new Basic2D("2d\\Misc\\Barra1", new Vector2(0,0), new Vector2(DIMS.X - boarder * 2, DIMS.Y - boarder * 2));
            barBG = new Basic2D("2d\\Misc\\Barra2", new Vector2(0,0), new Vector2(DIMS.X , DIMS.Y));
        }
        public virtual void Update(float CURRENT, float MAX)
        {
            bar.dims = new Vector2(CURRENT/MAX *(barBG.dims.X - boarder *2),bar.dims.Y);
        }
        public virtual void Draw(Vector2 OFFSET)
        {
           

            barBG.Draw(OFFSET, new Vector2(0, 0), Color.Black);


            bar.Draw(OFFSET + new Vector2(boarder, boarder), new Vector2(0,0), color);
        }

    }
}
