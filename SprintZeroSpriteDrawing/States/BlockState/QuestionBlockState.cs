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

    public class QuestionBlockState : IBlockState
    {
        public State state;

        public QuestionBlockState(Block block) : base(block)
        {
            state = State.UNTAPPED;
        }
        public QuestionBlockState(State nState, Block block) : base(block)
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
