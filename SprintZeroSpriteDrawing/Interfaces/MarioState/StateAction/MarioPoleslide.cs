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
    public class MarioPoleslide : IMarioState
    {
        public MarioPoleslide(Mario nMario): base(nMario)
        {

        }
        public MarioPoleslide(Mario nMario, ActionState nState) : base(nMario, nState)
        {

        }
        public override void Enter()
        {
            //SOMEHOW DISABLE THE POLESLIDE COLLISION RESPONSE?


            CollisionManager.getCM().RegMoving(mario);
            mario.Score += 2000 - (int)mario.Pos.Y;
            mario.Score += mario.Time * 5;
            currActionState = ActionState.POLESLIDE;
            mario.IsVis = true;
            mario.Velocity = new Vector2(0, (float)2);
            mario.Acceleration = new Vector2(0, 0);
            mario.Frame = 1;
            mario.AutoFrame = false;
        }

        public override void Update()
        {
            if (mario.Velocity.Y <= .1)
                RevertAction(ActionState.WALKING);
        }

        public override void ChangeActionState(int state)
        {
        }

        public void RevertAction(ActionState state)
        {
            switch (state)
            {
                case ActionState.WALKING:
                    mario.StateAction = new MarioWalking(mario, currActionState);
                    break;
            }
        }
    }
}
