using Microsoft.Xna.Framework.Graphics;
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

    public class HiddenBlockState : IBlockState
    {
        public State state;

        public HiddenBlockState(Block block) : base (block)
        {
            state = State.UNTAPPED;
        }
        public HiddenBlockState(State nState, Block block) : base (block)
        {
            state = nState;
        }
    }
}
