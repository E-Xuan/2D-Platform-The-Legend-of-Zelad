using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Interfaces.BlockState
{
    public class BlockHidden : IBlockState
    {
        public BlockHidden(Block nBlock) : base(nBlock)
        {
        }

        public override void Enter()
        {
            CurrState = State.HIDDEN;
            block.IsVis = false;
            block.Velocity = new Vector2(0,0);
            block.Acceleration = new Vector2(0, 0);
        }

        public override void ChangeState(int state)
        {
            switch ((State)state)
            {
                case State.BUMPING:
                    Exit();
                    block.State = new BlockBumping(this.block);
                    break;
                case State.BROKEN:
                    Exit();
                    block.State = new BlockBroken(this.block);
                    break;
            }
        }
    }
}
