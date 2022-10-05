using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;


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
        }

        public override void ChangePowerupState(int state)
        {
        }
    }
}