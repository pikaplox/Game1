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
    public class Monokuma : Unit
    {

        McTimer cooldownBasico = new McTimer(150);

        //ulti
        McTimer cooldownUlti = new McTimer(1000);
        McTimer LANZA = new McTimer(240);
        bool flag = false;
        int contadorUlti = 0;
        Vector2 targetMouse;
        float rotUlti;
        Basic2D Marca;
        McTimer timerMarca = new McTimer(3000);

        //dash 
        McTimer timerDash = new McTimer(200);
        McTimer cooldownDash = new McTimer(2000);
        bool flagDashD, flagDashA, flagDashS, flagDashW = false;

        public Monokuma(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID) : base(PATH, POS, DIMS, OWNERID)
        {
            speed = 3.0f;

            healthMax = 20;
            health = healthMax;
        }

        public override void Update(Vector2 OFFSET)
        {
            
            cooldownBasico.UpdateTimer();
            cooldownUlti.UpdateTimer();
            LANZA.UpdateTimer();
            timerMarca.UpdateTimer();
            timerDash.UpdateTimer();
            cooldownDash.UpdateTimer();
            flagDashA = false;
            flagDashD = false;
            flagDashW = false;
            flagDashS = false;
            bool checkScroll = false;   
            bool checkScrollDash = false;   
            //movimiento
            if (Globals.keyboard.GetPress("A"))
            {
                this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma3");
                pos = new Vector2(pos.X - speed, pos.Y);
                flagDashA = true;
                checkScroll = true;
            }
            if (cooldownDash.Test() && flagDashA)
            {
                if (Globals.keyboard.GetPress("Space"))
                {
                    pos = new Vector2(pos.X - speed - 100, pos.Y);
                    cooldownDash.ResetToZero();
                    flagDashA = false;
                    checkScrollDash = true;
                }
            }
            if (Globals.keyboard.GetPress("D"))
            {
                this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma2");
                pos = new Vector2(pos.X + speed, pos.Y);
                timerDash.ResetToZero();
                flagDashD = true;
                checkScroll = true;
            }
            if (cooldownDash.Test() && flagDashD)
            {
                if (Globals.keyboard.GetPress("Space"))
                {
                    pos = new Vector2(pos.X + speed + 100, pos.Y);
                    cooldownDash.ResetToZero();
                    flagDashD = false;
                    checkScrollDash = true;
                }
            }
            
            if (Globals.keyboard.GetPress("W"))
            {
                this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma4");
                pos = new Vector2(pos.X, pos.Y - speed);
                flagDashW = true;
                checkScroll = true;
            }
            if (cooldownDash.Test() && flagDashW)
            {
                if (Globals.keyboard.GetPress("Space"))
                {
                    pos = new Vector2(pos.X, pos.Y - speed - 100);
                    cooldownDash.ResetToZero();
                    flagDashW = false;
                    checkScrollDash = true;
                }
            }
            
            if (Globals.keyboard.GetPress("S"))
            {
                this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma1");
                pos = new Vector2(pos.X, pos.Y + speed);
                flagDashS = true;
                checkScroll = true;
            }

            if (cooldownDash.Test() && flagDashS)
            {
                if (Globals.keyboard.GetPress("Space"))
                {
                    pos = new Vector2(pos.X, pos.Y + speed + 100);
                    cooldownDash.ResetToZero();
                    flagDashS = false;
                    checkScrollDash = true;
                }
            }

            if (Globals.keyboard.GetSinglePress("D1"))
            {
                GameGlobals.PassBuilding(new ArrowTower(new Vector2(pos.X, pos.Y - 30), ownerId));
            }

            if (checkScroll)
            {
                GameGlobals.CheckScroll(pos);
            }
            if (checkScrollDash)
            {
                GameGlobals.CheckScrollDash(pos);
            }




            //triangulo
            Point mousePoint = new Point((int)Globals.mouse.newMousePos.X, (int)Globals.mouse.newMousePos.Y);

            Point[] triangleVertices = new Point[]
            {
            new Point((int)this.pos.X, (int)this.pos.Y), // Vértice 1
            new Point((int)this.pos.X - (Globals.screenHeight - (int)this.pos.Y), Globals.screenHeight), // Vértice 2
            new Point((int)this.pos.X + (Globals.screenHeight - (int)this.pos.Y), Globals.screenHeight)  // Vértice 3
             };
            Point[] triangleVerticesY = new Point[]
            {
            new Point((int)this.pos.X, (int)this.pos.Y), // Vértice 1
            new Point((int)this.pos.X - (int)this.pos.Y, 0), // Vértice 2
            new Point((int)this.pos.X + (int)this.pos.Y, 0)  // Vértice 3
            };

            bool IsPointInTriangle(Point[] triangle, Point point)
            {
                // Se asume que los vértices del triángulo están en sentido horario o antihorario
                Point A = triangle[0];
                Point B = triangle[1];
                Point C = triangle[2];

                float areaABC = Math.Abs((A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y)) / 2f);
                float areaPAB = Math.Abs((point.X * (A.Y - B.Y) + A.X * (B.Y - point.Y) + B.X * (point.Y - A.Y)) / 2f);
                float areaPBC = Math.Abs((point.X * (B.Y - C.Y) + B.X * (C.Y - point.Y) + C.X * (point.Y - B.Y)) / 2f);
                float areaPCA = Math.Abs((point.X * (C.Y - A.Y) + C.X * (A.Y - point.Y) + A.X * (point.Y - C.Y)) / 2f);

                float triangleArea = areaABC;
                float sumAreas = areaPAB + areaPBC + areaPCA;

                return triangleArea == sumAreas; // Si son iguales, el punto está dentro del triángulo
            }


            // VISTA DE ABAJO
            if ((Globals.mouse.newMousePos.X < this.pos.X) && (mousePoint.Y > this.pos.Y))
            {
                this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma3");
                if (IsPointInTriangle(triangleVertices, mousePoint))
                {
                    this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma1");
                }
            }
            if ((Globals.mouse.newMousePos.X > this.pos.X) && (mousePoint.Y > this.pos.Y))
            {
                this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma2");
                if (IsPointInTriangle(triangleVertices, mousePoint))
                {
                    this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma1");
                }
            }

            // VISTA DE ARRIBA
            if ((Globals.mouse.newMousePos.X < this.pos.X) && (mousePoint.Y < this.pos.Y))
            {
                this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma3");
                if (IsPointInTriangle(triangleVerticesY, mousePoint))
                {
                    this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma4");
                }
            }
            if ((Globals.mouse.newMousePos.X > this.pos.X) && ((mousePoint.Y < this.pos.Y)))
            {
                this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma2");
                if (IsPointInTriangle(triangleVerticesY, mousePoint))
                {
                    this.myModel = Globals.content.Load<Texture2D>("2D\\Monokuma4");
                }
            }
            //ataque
            if (Globals.mouse.LeftClick())
            {


                if (cooldownBasico.Test())
                {
                    GameGlobals.PassProjectile(new Dangan(new Vector2(pos.X, pos.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET));
                    cooldownBasico.ResetToZero();
                }


            }

            //ulti

            if (Globals.keyboard.GetPress("R"))
            {
                if (cooldownUlti.Test())
                {

                    cooldownUlti.ResetToZero();
                    LANZA.ResetToZero();
                    flag = true;
                    Lanza OG = new Lanza(this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET);
                    targetMouse = OG.tarjet;
                    timerMarca.ResetToZero();
                    GameGlobals.PassMarca(new Basic2D("2D\\Misc\\Marca", new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET, new Vector2(48, 48)));
                    GameGlobals.PassProjectile(OG);


                }
            }

            if (flag)
            {
                if (contadorUlti < 10 && LANZA.Test())
                {
                    Lanza OG2 = new Lanza(this, targetMouse);
                    OG2.rot = (Globals.RotateTowards(OG2.pos, OG2.tarjet));
                    GameGlobals.PassProjectile(OG2);
                    contadorUlti++;
                    LANZA.ResetToZero();

                    if (contadorUlti >= 10)
                    {

                        flag = false;
                        contadorUlti = 0;
                        cooldownUlti.ResetToZero();

                    }
                }
            }
            Basic2D MarcaNull;
            if (timerMarca.Test())
            {
                MarcaNull = null;
                GameGlobals.PassMarca(MarcaNull);
            }

            //rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y));

            base.Update(OFFSET);


        }
        public void ResetearCD()
        {
            cooldownBasico.AddToTimer(5000);
            cooldownUlti.AddToTimer(5000);
            LANZA.AddToTimer(5000);
            cooldownDash.AddToTimer(5000);
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
