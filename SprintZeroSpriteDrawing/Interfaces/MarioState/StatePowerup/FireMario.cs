﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;


namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup
{
    public class FireMario : IMarioState
    {
        public FireMario(Mario nMario) : base(nMario)
        {

        }

        public override void Enter()
        {
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.FIRE;
            mario.IsVis = true;
        }

        public override void ChangePowerupState(int state)
        {
            switch ((PowerupState)state)
            {
                case PowerupState.SMALL:
                    Exit();
                    mario.StatePowerup = new SmallMario(mario);
                    break;
                case PowerupState.STAR:
                    Exit();
                    mario.StatePowerup = new StarMario(mario);
                    break;
            }
        }
    }
}