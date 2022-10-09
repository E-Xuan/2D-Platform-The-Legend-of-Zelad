﻿using SprintZeroSpriteDrawing.Collision.BlockCollision;
using SprintZeroSpriteDrawing.Collision.MarioCollision;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
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
     
        /*public void ManageMarioCollision(Mario mario, List<ICollideable> Blocks)
        {
            MarioCollisionManager MarioManager = new MarioCollisionManager(mario);
            foreach(Block block in Blocks)
            {
                MarioManager.ManageBlockCollision(block);
            }
        }*/
        public void ManageBlockCollision(BlockCollisionManager blockCollisionManager, QuestionBlock QBlock, BrickBlock BBlock, UsedBlock UBlock, StairBlock SBlock, InvisibleBlock HBlock, GroundBlock GBlock)
        {
            blockCollisionManager.ManageQBlockCollision(QBlock);
            blockCollisionManager.ManageBBlockCollision(BBlock);
            blockCollisionManager.ManageHBlockCollision(HBlock);
            blockCollisionManager.ManageSBlockCollision(SBlock);
            blockCollisionManager.ManageGBlockCollision(GBlock);
            blockCollisionManager.ManageUBlockCollision(UBlock);
            /* Looks like I make it complicated. Idk */
        }
    }
} 