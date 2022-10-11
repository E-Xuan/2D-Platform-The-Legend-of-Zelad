using SprintZeroSpriteDrawing.Collision.BlockCollision;
using SprintZeroSpriteDrawing.Collision.MarioCollision;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SprintZeroSpriteDrawing.Collision.CollisionManager
{
    public class CollisionManager
    {
        private static CollisionManager CM;
        public static CollisionManager getCM()
        {
            if (CM == null)
                CM = new CollisionManager();
            return CM;
        }
        private List<ICollideable>[,] entityList;
        private List<ICollideable> movingEntities;
        private Direction CollisionDirection;
        private CollisionDetector collisionDetector;
        private CollisionManager()
        {
            entityList = new List<ICollideable>[(int)(Game1.SCREENSIZE.X / 96) + 1, (int)(Game1.SCREENSIZE.Y / 96) + 1];
            CollisionDirection = new Direction();
            //collisionDetector = new CollisionDetector();
            movingEntities = new List<ICollideable>();
            for (int i = 0; i < entityList.Length; i++)
            {
                entityList[i/((int)(Game1.SCREENSIZE.Y / 96) + 1), i%((int)(Game1.SCREENSIZE.Y / 96) + 1)] = new List<ICollideable>();
            }
        }
        public void Init()
        {
            foreach (ISprite entity in Game1.SpriteList)
            {
                try {
                    entityList[(int)(entity.Pos.X/96), (int)(entity.Pos.Y/96)].Add((ICollideable)entity);
                } catch (InvalidCastException e) { }
            }
        }
        public void RegEntity(ICollideable entity)
        {
            entityList[(int)(entity.Pos.X / 96), (int)(entity.Pos.Y / 96)].Add(entity);
        }
        public void DeRegEntity(ICollideable entity)
        {
            if (entityList[(int)(entity.Pos.X / 96), (int)(entity.Pos.Y / 96)].Contains(entity))
                entityList[(int)(entity.Pos.X / 96), (int)(entity.Pos.Y / 96)].Remove(entity);
        }
        public void RegMoving(ICollideable entity)
        {
            if(!movingEntities.Contains(entity))
                movingEntities.Add(entity);
        }
        public void DeRegMoving(ICollideable entity)
        {
            if (movingEntities.Contains(entity))
                movingEntities.Remove(entity);

        }
        public void Update(CollisionDetector CD)
        {
            bool isLegal = true;
            foreach (ICollideable entity in movingEntities.ToImmutableList())
            {
                Vector2 dirVel = new Vector2(Math.Sign(entity.Velocity.X), Math.Sign(entity.Velocity.Y));

                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        isLegal = (int)(entity.Pos.X / 96) + x >= 0 && (int)(entity.Pos.X / 96) + x < (int)(Game1.SCREENSIZE.X / 96) + 1 && (int)(entity.Pos.Y / 96) + y >= 0 && (int)(entity.Pos.Y / 96) + y < (int)(Game1.SCREENSIZE.Y / 96) + 1;
                        if (isLegal)
                        {
                            foreach (ICollideable entity2 in entityList[(int)(entity.Pos.X / 96) + x,
                                         (int)(entity.Pos.Y / 96) + y].ToImmutableList())
                            {
                                CollisionDirection = CD.DetectColDirection(entity, entity2);
                                if (/*(entity != entity2) && entity.BBox.Intersects(entity2.BBox)*/ CollisionDirection == Direction.BOTTOM)
                                {
                                    entity2.CollisionResponse[0].Item1.Execute();
                                    entity.CollisionResponse[0].Item1.Execute();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
} 
