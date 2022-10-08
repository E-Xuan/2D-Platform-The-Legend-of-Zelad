using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Collision.CollisionManager
{
    public class CollisionManager
    {
        private static CollisionManager CM;
        private static CollisionManager getCM()
        {
            return CM;
        }
        List<ICollideable>[,] list = new List<ICollideable>[(int)(Game1.SCREENSIZE.X / 48), (int)(Game1.SCREENSIZE.Y / 48)];

        public void ManageMarioCollision(Mario mario, List<ICollideable> Blocks /*Needs to add lists of other types here*/)
        {
            MarioCollisionManager MarioManager = new MarioCollisionManager(mario);
            foreach(Block block in Blocks)
            {
                MarioManager.ManageBlockCollision(block);
            }
        }
    }
}
