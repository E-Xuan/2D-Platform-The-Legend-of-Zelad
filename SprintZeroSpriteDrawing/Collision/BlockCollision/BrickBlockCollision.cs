﻿using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using SprintZeroSpriteDrawing.Interfaces.MarioState;

namespace SprintZeroSpriteDrawing.Collision.BlockCollision
{
    public class BrickBlockCollision : ICommand
    {
        Direction CollisionSide;
        public BlockCollisionManager BlockCollisionManager;
        public BrickBlockCollision(object nRef) : base(nRef) 
        { 
            CollisionSide = new Direction(); 
        }
        public override void Execute()
        {
            CollisionSide = CollisionDetector.getCD().DetectColDirection(BlockCollisionManager.BBlock, BlockCollisionManager.mario);
            if(BlockCollisionManager.mario.GetType() == typeof(BigMario) || BlockCollisionManager.mario.GetType() == typeof(FireMario) || BlockCollisionManager.mario.GetType() == typeof(StarMario))
            {
                if(CollisionSide == Direction.TOP)
                {
                    BlockCollisionManager.mario.Velocity = new Vector2(BlockCollisionManager.mario.Velocity.X, 0);
                }
                if(CollisionSide == Direction.BOTTOM)
                {
                    BlockCollisionManager.BBlock.State.ChangeState((int) State.BROKEN); // Not sure whether it's the right thing should happen
                    BlockCollisionManager.mario.Velocity = new Vector2(BlockCollisionManager.mario.Velocity.X, -BlockCollisionManager.mario.Velocity.Y);
                }
                if(CollisionSide == Direction.LEFT)
                {
                    BlockCollisionManager.mario.Velocity = new Vector2(0, BlockCollisionManager.mario.Velocity.Y);
                }
                if(CollisionSide == Direction.RIGHT)
                {
                    BlockCollisionManager.mario.Velocity = new Vector2(0, BlockCollisionManager.mario.Velocity.Y);
                }
            }

            if(BlockCollisionManager.mario.GetType() == typeof(SmallMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    BlockCollisionManager.mario.Velocity = new Vector2(BlockCollisionManager.mario.Velocity.X, 0);
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    BlockCollisionManager.BBlock.State.ChangeState((int)State.BUMPING); // Not sure whether it's the right thing should happen
                    BlockCollisionManager.mario.Velocity = new Vector2(BlockCollisionManager.mario.Velocity.X, -BlockCollisionManager.mario.Velocity.Y);
                }
                if (CollisionSide == Direction.LEFT)
                {
                    BlockCollisionManager.mario.Velocity = new Vector2(0, BlockCollisionManager.mario.Velocity.Y);
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    BlockCollisionManager.mario.Velocity = new Vector2(0, BlockCollisionManager.mario.Velocity.Y);
                }
            }   
        }
    }
}