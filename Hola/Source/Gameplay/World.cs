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
using System.DirectoryServices;
using Hola.Source.Gameplay.World.Players;

#endregion
namespace Hola
{
    public class World
    {
        public Vector2 offset;
       
        public List<Projectile2D> projectiles = new List<Projectile2D>();
        public List<AttackableObject> allObjects = new List<AttackableObject>();
        public Basic2D Marca;
        public UI ui; 
   
        PassObject ResetWorld;

        public User user;
        public AIPlayer aiPlayer;
        
        public World(PassObject RESETWORLD)
        {
            ResetWorld = RESETWORLD;
            
            
            
            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMarca = AddMarca;
            GameGlobals.CheckScroll = CheckScroll;
            GameGlobals.PassBuilding = AddBuilding; ;
            GameGlobals.PassMob = AddMob;
            GameGlobals.PassSpawnPoint = AddSpawnPoint;
            GameGlobals.CheckScrollDash = CheckScrollDash;

            offset = new Vector2(0,0);

            LoadData(1);

            ui = new UI();

            user.monokuma.ResetearCD();
        }

        public virtual void Update(Vector2 OFFSET)
        {
            if (!user.monokuma.dead && user.buildings.Count > 0)
            {
                allObjects.Clear();
                allObjects.AddRange(user.GetAllObjects());
                allObjects.AddRange(aiPlayer.GetAllObjects());

                user.Update(aiPlayer, offset);
                aiPlayer.Update(user, offset);

                
                
                
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Update(offset, allObjects.ToList<AttackableObject>(), user.monokuma);
                    if (projectiles[i].done)
                    {

                        projectiles.RemoveAt(i);
                        i--;
                    }
                }
                
                ui.Update(this);
            }
            else
            {
                if (Globals.keyboard.GetPress("Enter") && (user.monokuma.dead = true) || (user.buildings.Count <= 0))
                {
                    ResetWorld(null);
                }
            }
        }

        public virtual void LoadData(int LEVEL)
        {
            XDocument xml = XDocument.Load("XML\\Levels\\Level" + LEVEL + ".xml");
            XElement tempElement = null;
            if (xml.Element("Root").Element("User") != null)
            {
                tempElement = xml.Element("Root").Element("User");
            }

            user = new User(1, tempElement);
            tempElement = null;
            if (xml.Element("Root").Element("AIPlayer") != null)
            {
                tempElement = xml.Element("Root").Element("AIPlayer");
            }
            aiPlayer = new AIPlayer(2, tempElement);
        }


        public virtual void AddMob(object INFO)
        {
            Unit tempUnit = (Unit)INFO;
            if (user.id == tempUnit.ownerId)
            {
                user.AddUnit(tempUnit);
            }
            else if (aiPlayer.id == tempUnit.ownerId) 
            {
                aiPlayer.AddUnit(tempUnit);
            }

        }
        public virtual void AddSpawnPoint(object INFO)
        {
            SpawnPoint tempSpawnPoint = (SpawnPoint)INFO;
            if (user.id == tempSpawnPoint.ownerId)
            {
                user.AddSpawnPoint(tempSpawnPoint);
            }
            else if (aiPlayer.id == tempSpawnPoint.ownerId)
            {
                aiPlayer.AddSpawnPoint(tempSpawnPoint);
            }

        }
        public virtual void AddBuilding(object INFO)
        {
            Building tempBuilding = (Building)INFO;
            if (user.id == tempBuilding.ownerId)
            {
                user.AddBuilding(tempBuilding);
            }
            else if (aiPlayer.id == tempBuilding.ownerId)
            {
                aiPlayer.AddBuilding(tempBuilding);
            }
        }


        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2D)INFO);
        }
        public virtual void AddMarca(object INFO)
        {
            Marca = (Basic2D)INFO;
        }
        public virtual void CheckScroll(object INFO)
        {
            Vector2 tempPos = (Vector2)INFO;
            if (tempPos.X < -offset.X + (Globals.screenWidth * .4f))
            {
                offset = new Vector2(offset.X + user.monokuma.speed, offset.Y);
            }
            if (tempPos.X > -offset.X + (Globals.screenWidth * .6f))
            {
                offset = new Vector2(offset.X - user.monokuma.speed , offset.Y);
            }
            if (tempPos.Y < -offset.Y + (Globals.screenHeight * .4f))
            {
                offset = new Vector2(offset.X, offset.Y + user.monokuma.speed );
            }
            if (tempPos.Y > -offset.Y + (Globals.screenHeight * .6f))
            {
                offset = new Vector2(offset.X, offset.Y - user.monokuma.speed );
            }

        }
        public virtual void CheckScrollDash(object INFO)
        {
            Vector2 tempPos = (Vector2)INFO;
            if (tempPos.X < -offset.X + (Globals.screenWidth * .4f))
            {
                offset = new Vector2(offset.X + user.monokuma.speed + 100, offset.Y);
            }
            if (tempPos.X > -offset.X + (Globals.screenWidth * .6f))
            {
                offset = new Vector2(offset.X - user.monokuma.speed - 100, offset.Y);
            }
            if (tempPos.Y < -offset.Y + (Globals.screenHeight * .4f))
            {
                offset = new Vector2(offset.X, offset.Y + user.monokuma.speed + 100);
            }
            if (tempPos.Y > -offset.Y + (Globals.screenHeight * .6f))
            {
                offset = new Vector2(offset.X, offset.Y - user.monokuma.speed - 100);
            }

        }

       

        public virtual void Draw(Vector2 OFFSET)
        {
           
            if (Marca!= null)
            {
                Marca.Draw(offset);
            }


            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

            user.Draw(offset);
            aiPlayer.Draw(offset);
            user.Draw(offset);
            ui.Draw(this);
            //punto.Draw(OFFSET);
        }
    } 
}
