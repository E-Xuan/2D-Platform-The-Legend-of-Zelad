using Microsoft.Xna.Framework.Graphics;
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
    public class MarioIdle : IMarioState
    {
        public MarioIdle(Mario nMario): base(nMario)
        {

        }
        public override void Enter()
        {

            //CollisionManager.getCM().DeRegMoving(mario);
            currActionState = ActionState.IDLE;
            mario.IsVis = true;
            mario.Velocity = new Vector2(0, 0);
            mario.Acceleration = new Vector2(0, (float) .1);
            mario.StartFrame = 0;
            mario.Frame = 0;
            mario.LastFrame = 1;
            mario.AutoFrame = false;
        }

        public override void ChangeActionState(int state)
        {
            switch((ActionState)state)
            {
                case ActionState.JUMPING:
                    Exit();
                    mario.StateAction = new MarioJumping(mario);
                    break;
                case ActionState.WALKING:
                    Exit();
                    mario.StateAction = new MarioWalking(mario);
                    break;
                case ActionState.CROUCHING:
                    Exit();
                    mario.StateAction = new MarioCrouching(mario);
                    break;
            }
        }

    }
}
