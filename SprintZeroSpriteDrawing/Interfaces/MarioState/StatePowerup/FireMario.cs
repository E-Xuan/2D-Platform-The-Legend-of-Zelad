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
    public class FireMario : IMarioState
    {
        public FireMario(Mario nMario) : base(nMario)
        {

        }

        public override void Enter()
        {
            mario.CollideableType = CType.AVATAR_LARGE;
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.FIRE;
            mario.IsVis = true;
            mario.SheetSize = new Vector2(4, 2);
            mario.SetSprite(MarioSpriteFactory.getSpriteFactory().FireMarioSpriteSheet);
            mario.UpdateBBox();
        }

        public override void ChangePowerupState(int state)
        {
            switch ((PowerupState)state)
            {
                case PowerupState.SMALL:
                    Exit();
                    mario.StatePowerup = new SmallMario(mario);
                    break;
                case PowerupState.BIG:
                    Exit();
                    mario.StatePowerup = new BigMario(mario);
                    break;
                case PowerupState.STAR:
                    Exit();
                    mario.StatePowerup = new StarMario(mario);
                    break;
            }
        }
    }
}