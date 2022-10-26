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
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using SprintZeroSpriteDrawing.Interfaces.BlockState;

namespace SprintZeroSpriteDrawing.Collision.CollisionManager
{
    public class CollisionManager
    {
        private static CollisionManager CM;
        public static bool IsCM()
        {
            return CM == null;
        }
        public static CollisionManager getCM()
        {
            if (CM == null)
                CM = new CollisionManager();
            return CM;
        }
        private List<ICollideable>[,] entityList;
        private List<ICollideable> movingEntities;

        private CollisionManager()
        {
            entityList = new List<ICollideable>[(int)(Game1.LEVELSIZE.X / 96) + 1, (int)(Game1.LEVELSIZE.Y / 96) + 2];
            movingEntities = new List<ICollideable>();
            for (int i = 0; i < entityList.Length; i++)
            {
                entityList[i / ((int)(Game1.LEVELSIZE.Y / 96) + 2), i % ((int)(Game1.LEVELSIZE.Y / 96) + 2)] =
                    new List<ICollideable>();
            }
            //Make the screen boundries
            for (int i = 0; i < (int)Game1.LEVELSIZE.X; i += 48)
            {
                var screenEdgeTop = BlockSpriteFactory.getFactory().CreateBoundryBlock(new Vector2(i, 0));
                screenEdgeTop.IsVis = false;
                RegEntity((ICollideable)screenEdgeTop);
                Game1.SpriteList.Add(screenEdgeTop);
                var screenEdgeBottom = BlockSpriteFactory.getFactory().CreateBoundryBlock(new Vector2(i, Game1.LEVELSIZE.Y));
                screenEdgeBottom.IsVis = false;
                RegEntity((ICollideable)screenEdgeBottom);
                Game1.SpriteList.Add(screenEdgeBottom);
            }
            for (int i = 0; i < (int)Game1.LEVELSIZE.Y; i += 48)
            {
                var screenEdgeTop = BlockSpriteFactory.getFactory().CreateBoundryBlock(new Vector2(0, i));
                screenEdgeTop.IsVis = false;
                RegEntity((ICollideable)screenEdgeTop);
                Game1.SpriteList.Add(screenEdgeTop);
                var screenEdgeBottom = BlockSpriteFactory.getFactory().CreateBoundryBlock(new Vector2(Game1.LEVELSIZE.X, i));
                screenEdgeBottom.IsVis = false;
                RegEntity((ICollideable)screenEdgeBottom);
                Game1.SpriteList.Add(screenEdgeBottom);
            }

        }

        public void Init()
        {
            foreach (ISprite entity in Game1.SpriteList)
            {
                try 
                {
                    entityList[(int)(entity.Pos.X/96), (int)(entity.Pos.Y/96)].Add((ICollideable)entity);
                } catch (InvalidCastException) { }
            }

        }
        public void RegEntity(ICollideable entity)
        {
           entityList[(int)(entity.Pos.X / 96), (int)(entity.Pos.Y / 96)].Add(entity);
        }
        public bool DeRegEntity(ICollideable entity)
        {
            return entityList[(int)(entity.Pos.X / 96), (int)(entity.Pos.Y / 96)].Remove(entity);
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
        public void Update()
        {
            foreach (ICollideable entity in movingEntities.ToImmutableList())
            {
                Vector2 walkBack = new Vector2(0, 0);
                List<ICommand> exeList = new List<ICommand>();
                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        bool isLegal = (int)(entity.Pos.X / 96) + x >= 0 && (int)(entity.Pos.X / 96) + x < (int)(Game1.LEVELSIZE.X / 96) + 1 && (int)(entity.Pos.Y / 96) + y >= 0 && (int)(entity.Pos.Y / 96) + y < (int)(Game1.LEVELSIZE.Y / 96) + 1;
                        if (isLegal)
                        {
                            foreach (ICollideable entity2 in entityList[(int)(entity.Pos.X / 96) + x,
                                         (int)(entity.Pos.Y / 96) + y].ToImmutableList())
                            {
                                entity.CollideMaybe = true;
                                entity2.CollideMaybe = true;
                                if (entity.BBox.Intersects(entity2.BBox) && entity != entity2)
                                {
                                    Direction CollisionDirection;
                                    CollisionDirection = CollisionDetector.getCD().DetectColDirection(entity, entity2);
                                    foreach (var response in entity.CollisionResponse)
                                    {
                                        if (response.Item3 == entity2.CollideableType &&
                                            response.Item2 == CollisionDirection)
                                        {
                                            if(!exeList.Contains(response.Item1))
                                                exeList.Add(response.Item1);
                                        }
                                    }

                                    if (CollisionDirection == Direction.BOTTOM)
                                    {
                                        CollisionDirection = Direction.TOP;
                                    } 
                                    else if (CollisionDirection == Direction.TOP)
                                    {
                                        CollisionDirection = Direction.BOTTOM;
                                    }

                                    foreach (var response in entity2.CollisionResponse)
                                    {
                                        if (response.Item3 == entity.CollideableType &&
                                            response.Item2 == CollisionDirection)
                                        {
                                                exeList.Add(response.Item1);
                                        }

                                    }
                                    if (entity2.CollideableType != CType.INVISIBLE)
                                    {
                                        Vector2 tempWB = CollisionDetector.getCD().BuildWalkback(entity, entity2);
                                        if (Math.Abs(tempWB.X) > Math.Abs(walkBack.X))
                                            walkBack.X = tempWB.X;
                                        if (Math.Abs(tempWB.Y) > Math.Abs(walkBack.Y))
                                            walkBack.Y = tempWB.Y;
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (ICommand command in exeList)
                {
                    command.Execute();
                }

                DeRegEntity(entity); 
                entity.Pos = Vector2.Add(entity.Pos, walkBack);
                entity.UpdateBBox();
                RegEntity(entity);
            }
        }
    }
} 
