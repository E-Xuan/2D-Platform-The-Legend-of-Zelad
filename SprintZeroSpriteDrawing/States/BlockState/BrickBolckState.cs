﻿using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.States.BlockState
{

    public class BrickBlockState : IBlockState
    {
        public State state;

        public BrickBlockState(Block block) : base (block)
        {
            state = State.UNTAPPED;
        }
        public BrickBlockState(State nState, Block block) : base (block)
        {
            state = nState;
        }

        public void Collide()
        {
            state = State.TAPPED;
        }

        public void Update()
        {
        }

        public State GetState()
        {
            return state;
        }
    }
}
