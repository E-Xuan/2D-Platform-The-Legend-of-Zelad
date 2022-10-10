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

namespace SprintZeroSpriteDrawing.Collision.ItemCollision
{
    public class CoinsCollision : ICommand
    {
        Direction CollisionSide;
        public ItemCollisionManager ItemCollisionManager;
        public CoinsCollision(object nRef) : base(nRef)
        {
            CollisionSide = (Direction)nRef;
        }
        public override void Execute()
        {
            CollisionSide = CollisionDetector.getCD().DetectColDirection(ItemCollisionManager.coins, ItemCollisionManager.mario);
            if (ItemCollisionManager.mario.GetType() == typeof(SmallMario) || ItemCollisionManager.mario.GetType() == typeof(BigMario) || ItemCollisionManager.mario.GetType() == typeof(FireMario) || ItemCollisionManager.mario.GetType() == typeof(StarMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    ItemCollisionManager.coins.IsVis = false;
                    //CoinsCounter++ 
                    //Future Commands, not require in this sprint.
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    ItemCollisionManager.coins.IsVis = false;
                    //CoinsCounter++ 
                    //Future Commands, not require in this sprint.
                }
                if (CollisionSide == Direction.LEFT)
                {
                    ItemCollisionManager.coins.IsVis = false;
                    //CoinsCounter++ 
                    //Future Commands, not require in this sprint.
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    ItemCollisionManager.coins.IsVis = false;
                    //CoinsCounter++ 
                    //Future Commands, not require in this sprint.
                }
            }
        }
    }
}
