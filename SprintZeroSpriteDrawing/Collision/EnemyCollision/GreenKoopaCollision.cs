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

namespace SprintZeroSpriteDrawing.Collision.EnemyCollision
{
    public class GreenKoopaCollision : ICommand
    {
        Direction CollisionSide;
        public EnemyCollisionManager EnemyCollisionManager;
        public GreenKoopaCollision(object nRef) : base(nRef)
        {
            CollisionSide = (Direction)nRef;
        }
        public override void Execute()
        {
            CollisionSide = CollisionDetector.getCD().DetectColDirection(EnemyCollisionManager.greenKoopa, EnemyCollisionManager.mario);
            if (EnemyCollisionManager.mario.GetType() == typeof(SmallMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    //GreenKoopa change to a strange state... probably will be in future sprints
                    EnemyCollisionManager.mario.Velocity = new Vector2(EnemyCollisionManager.mario.Velocity.X, 0);
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    //Mario Die
                }
                if (CollisionSide == Direction.LEFT)
                {
                    //Mario Die
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    //Mario Die
                }
            }
            if (EnemyCollisionManager.mario.GetType() == typeof(BigMario) || EnemyCollisionManager.mario.GetType() == typeof(FireMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    //GreenKoopa change to a strange state... probably will be in future sprints
                    EnemyCollisionManager.mario.Velocity = new Vector2(EnemyCollisionManager.mario.Velocity.X, 0);
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    //Mario damage to small mario
                }
                if (CollisionSide == Direction.LEFT)
                {
                    //Mario damage to small mario
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    //Mario damage to small mario
                }
            }

            if (EnemyCollisionManager.mario.GetType() == typeof(StarMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    //GreenKoopa Die
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    //GreenKoopa Die
                }
                if (CollisionSide == Direction.LEFT)
                {
                    //GreenKoopa Die
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    //GreenKoopa Die
                }
            }

        }
    }
}
