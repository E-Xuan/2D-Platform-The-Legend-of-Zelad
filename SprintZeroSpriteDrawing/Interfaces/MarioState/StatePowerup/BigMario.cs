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
    public class BigMario : IMarioState
    {
        public BigMario(Mario nMario) : base(nMario)
        {

        }

        public override void Enter()
        {
            mario.CollideableType = CType.AVATAR_LARGE;
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.BIG;
            mario.IsVis = true;
            mario.SheetSize = new Vector2(4, 2);
            mario.SetSprite(Mario.BigMarioSpriteSheet);
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