using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;


namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup
{
    public class DeadMario : IMarioState
    {
        public DeadMario(Mario nMario) : base(nMario)
        {

        }

        public override void Enter()
        {
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.DEAD;
            mario.IsVis = true;
            mario.Velocity = new Vector2(0, 0);
            mario.Acceleration = new Vector2(0, 0);
            mario.SheetSize = new Vector2(1, 1);
            mario.SetSprite(MarioSpriteFactory.getSpriteFactory().DeadMarioSpriteSheet);
            mario.UpdateBBox();
        }

        public override void Update()
        {
            mario.ChangeAction((int)MarioState.ActionState.IDLE);
        }

        public override void ChangePowerupState(int state)
        {
            switch ((PowerupState)state)
            {
                case PowerupState.BIG:
                    Exit();
                    mario.StatePowerup = new BigMario(mario);
                    break;
                case PowerupState.FIRE:
                    Exit();
                    mario.StatePowerup = new FireMario(mario);
                    break;
                case PowerupState.DEAD:
                    Exit();
                    mario.StatePowerup = new DeadMario(mario);
                    break;
                case PowerupState.STAR:
                    Exit();
                    mario.StatePowerup = new StarMario(mario);
                    break;
            }
        }
    }
}