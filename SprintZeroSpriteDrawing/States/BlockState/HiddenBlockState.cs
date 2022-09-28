using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
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

        public HiddenBlockState()
        {
            state = State.UNTAPPED;
        }
        public HiddenBlockState(State nState)
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
