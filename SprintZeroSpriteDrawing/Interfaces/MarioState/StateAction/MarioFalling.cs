﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;
using SprintZeroSpriteDrawing.Collision.CollisionManager;


namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction
{
    public class MarioFalling : IMarioState
    {
        public MarioFalling(Mario nMario): base(nMario)
        {

        }

        public override void Enter()
        {
            CollisionManager.getCM().RegMoving(mario);
            currActionState = ActionState.FALLING;
            mario.IsVis = true;
            mario.Velocity = new Vector2(mario.Velocity.X, 5);
            mario.Acceleration = new Vector2(0, (float)0.05);
            mario.Frame = 1;
            mario.AutoFrame = false;
        }

        public override void ChangeActionState(int state)
        {
            switch ((ActionState)state)
            {
                case ActionState.RUNNING:
                    Exit();
                    mario.StateAction = new MarioRunning(mario);
                    break;
                case ActionState.WALKING:
                    Exit();
                    mario.StateAction = new MarioWalking(mario);
                    break;
                case ActionState.IDLE:
                    Exit();
                    mario.StateAction = new MarioIdle(mario);
                    break;
            }
        }
    }
}