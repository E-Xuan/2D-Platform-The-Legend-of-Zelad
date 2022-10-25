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
    public class MarioFalling : IMarioState
    {
        public MarioFalling(Mario nMario): base(nMario)
        {

        }
        public MarioFalling(Mario nMario, ActionState nState) : base(nMario, nState)
        {

        }
        public override void Enter()
        {
            CollisionManager.getCM().RegMoving(mario);
            currActionState = ActionState.FALLING;
            mario.IsVis = true;
            mario.Velocity = new Vector2(mario.Velocity.X, (float).1);
            mario.Acceleration = new Vector2(0, (float)0.07);
            mario.Frame = 1;
            mario.AutoFrame = false;
        }

        public override void Update()
        {
            if(mario.Velocity.Y <= .1)
                RevertAction();
        }

        public override void ChangeActionState(int state)
        {
            switch ((ActionState)state)
            {
                case ActionState.RUNNING:
                    Exit();
                    mario.StateAction = new MarioRunning(mario, currActionState);
                    break;
                case ActionState.WALKING:
                    Exit();
                    mario.StateAction = new MarioWalking(mario, currActionState);
                    break;
                case ActionState.IDLE:
                    Exit();
                    mario.StateAction = new MarioIdle(mario, currActionState);
                    break;
            }
        }

        public void RevertAction()
        {
            ChangeActionState((int)mario.StateAction.previousActionState);
        }
    }
}
