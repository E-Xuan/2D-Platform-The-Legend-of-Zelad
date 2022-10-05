using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction
{
    public class MarioWalking: IMarioState
    {
        public MarioWalking(Mario nMario): base(nMario)
        {

        }

        public override void Enter()
        {
            currActionState = ActionState.WALKING;
            mario.IsVis = true;
            mario.Velocity = new Vector2(5, 0);
            mario.Acceleration = new Vector2(1, 0);
        }

        public override void ChangeActionState(int state)
        {
            switch ((ActionState)state)
            {
                case ActionState.IDLE:
                    Exit();
                    mario.StateAction = new MarioIdle(mario);
                    break;
                case ActionState.JUMPING:
                    Exit();
                    mario.StateAction = new MarioJumping(mario);
                    break;
                case ActionState.RUNNING:
                    Exit();
                    mario.StateAction = new MarioRunning(mario);
                    break;
            }
        }
    }
}
