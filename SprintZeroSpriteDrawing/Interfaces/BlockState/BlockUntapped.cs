using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Interfaces.BlockState
{
    public class BlockUntapped : IBlockState
    {
        public BlockUntapped(Block nBlock) : base(nBlock)
        {
        }

        public override void Enter()
        {
            CurrState = State.UNTAPPED;
            block.IsVis = true;
            block.Velocity = new Vector2(0,0);
            block.Acceleration = new Vector2(0, 0);
        }

        public override void ChangeState(int state)
        {
            switch ((State)state)
            {
                case State.BUMPING:
                    Exit();
                    block.State = new BlockBumping(block);
                    break;
                case State.BROKEN:
                    Exit();
                    block.State = new BlockBroken(block);
                    break;
            }
        }
    }
}
