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
using SharpDX.MediaFoundation;

#endregion

namespace Hola
{
    public class Player
    {
        public int id;
        public Monokuma monokuma;
        public List<Unit> units = new List<Unit>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>(); 
        public List<AttackableObject> TODO = new List<AttackableObject>();
        public List<Building> buildings = new List<Building>();

        public Player(int ID, XElement DATA)

        {
            this.id = ID;
            LoadData(DATA);
        }


        public virtual void Update(Player ENEMY, Vector2 OFFSET)
        {
            if (monokuma != null)
            {
                monokuma.Update(OFFSET);
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Update(OFFSET, ENEMY);
                if (units[i].dead)
                {
                    ChangeScore(1);
                    units.RemoveAt(i);
                    i--;
                }

            }
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(OFFSET);
                if (spawnPoints[i].dead)
                {

                    spawnPoints.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < buildings.Count; i++)
            {
                buildings[i].Update(OFFSET, ENEMY);
                if (buildings[i].dead)
                {
                    buildings.RemoveAt(i);
                    i--;
                }
            }

        }
        public virtual void AddUnit(Object INFO)
        {
            Unit tempUnit = (Unit)INFO;
            tempUnit.ownerId = id;
            units.Add(tempUnit);
        }

        public virtual void AddBuilding(Object INFO)
        {
            Building tempBuilding = (Building)INFO;
            tempBuilding.ownerId = id;
            buildings.Add(tempBuilding);
        }

        public virtual void AddSpawnPoint(Object INFO)
        {
            SpawnPoint tempSpawnpoint = (SpawnPoint)INFO;
            tempSpawnpoint.ownerId = id;
            spawnPoints.Add(tempSpawnpoint);
        }

        public virtual void ChangeScore(int SCORE)
        {

        }

        public virtual List<AttackableObject> GetAllObjects()
        {

            List<AttackableObject> tempObjects = new List<AttackableObject>();
            tempObjects.AddRange(units.ToList<AttackableObject>());
            tempObjects.AddRange(spawnPoints.ToList<AttackableObject>());
            tempObjects.AddRange(buildings.ToList<AttackableObject>());
            return tempObjects;
        }

        public virtual void LoadData(XElement DATA)
        {
            List<XElement> spawnList = (from t in DATA.Descendants("SpawnPoint") 
                                        select t).ToList<XElement>();

            Type sType = null;
            for (int i = 0; i < spawnList.Count; i++)
            {
                sType = Type.GetType("Hola."+ spawnList[i].Element("type").Value, true);

                spawnPoints.Add((SpawnPoint)(Activator.CreateInstance(sType, new Vector2(Convert.ToInt32(spawnList[i].Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(spawnList[i].Element("Pos").Element("y").Value, Globals.culture)), id, spawnList[i])));
                
            }

            List<XElement> buildingList = (from t in DATA.Descendants("Building")
                                        select t).ToList<XElement>();

            for (int i = 0; i < buildingList.Count; i++)
            {
                sType = Type.GetType("Hola." + buildingList[i].Element("type").Value, true);
                buildings.Add((Building)(Activator.CreateInstance(sType, new Vector2(Convert.ToInt32(buildingList[i].Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(buildingList[i].Element("Pos").Element("y").Value, Globals.culture)), id)));
            }

            if (DATA.Element("Monokuma") != null)
            {
                monokuma = new Monokuma("2D\\Monokuma1", new Vector2(Convert.ToInt32(DATA.Element("Monokuma").Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(DATA.Element("Monokuma").Element("Pos").Element("y").Value, Globals.culture)), new Vector2(73, 87), id);
            }

        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if (monokuma != null)
            {
                monokuma.Draw(OFFSET);
            }
            for (int i = 0; i < units.Count; i++)
            {
                units[i].Draw(OFFSET);

            }
            for (int i = 0; i < spawnPoints.Count; i++)
            {

                spawnPoints[i].Draw(OFFSET);
            }
            for (int i = 0; i < buildings.Count; i++)
            {
                 buildings[i].Draw(OFFSET);

            }
        }
    }
}
