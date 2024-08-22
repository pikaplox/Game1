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

#endregion

namespace Hola.Source.Engine
{
    public class Personaje
    {
        public string Nombre;
        public DateTime FechaNacimiento;

        public Personaje(string NOMBRE, DateTime Fecha) 
        { 
            this.Nombre = NOMBRE;
            this.FechaNacimiento = Fecha;
        
        }
    }
}
