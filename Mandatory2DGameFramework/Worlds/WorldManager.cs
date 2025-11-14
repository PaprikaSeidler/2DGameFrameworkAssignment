using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.Models.Creatures;
using Mandatory2DGameFramework.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Worlds
{
    public class WorldManager
    {   
        private readonly World _world;
        
        public WorldManager(World world)
        {
            _world = world;
        }

        public void AddCreature(Creature creature, int x, int y)
        {
            if (x >= 0 && x <= _world.MaxX && y >= 0 && y <= _world.MaxY)
            {
                creature.X = x;
                creature.Y = y;
                _world.Creatures.Add(creature);
                MyLogger.Instance.LogInfo($"Creature {creature.Name} added at position ({x}, {y}).");
            }
            else
            {
                MyLogger.Instance.LogError($"Failed to add creature {creature.Name}: position ({x}, {y}) is out of bounds.");
            }
        }

        public bool MoveCreature(Creature creature, int newX, int newY)
        {
            if (newX >= 0 && newX <= _world.MaxX && newY >= 0 && newY <= _world.MaxY)
            {
                creature.X = newX;
                creature.Y = newY;
                MyLogger.Instance.LogInfo($"Creature {creature.Name} moved to position ({newX}, {newY}).");
                return true;
            }
            else
            {
                MyLogger.Instance.LogError($"Failed to move creature {creature.Name}: position ({newX}, {newY}) is out of bounds.");
                return false;
            }
        }

        public void AddWorldObject(WorldObject obj, int x, int y)
        {
            if (x >= 0 && x <= _world.MaxX && y >= 0 && y <= _world.MaxY)
            {
                obj.X = x;
                obj.Y = y;
                _world.WorldObjects.Add(obj);
                MyLogger.Instance.LogInfo($"Object {obj.Name} added at position ({x}, {y}).");
            }
            else
            {
                MyLogger.Instance.LogError($"Failed to add object {obj.Name}: position ({x}, {y}) is out of bounds.");
            }
        }

        public List<WorldObject> GetWorldObjectsAt(int x, int y)
        {
            var objects = _world.WorldObjects.Where(obj => obj.X == x && obj.Y == y).ToList();
            var creatures = _world.Creatures.Where(c => c.X == x && c.Y == y).Cast<WorldObject>().ToList();
            objects.AddRange(creatures);
            return objects;
        }
    }
}
