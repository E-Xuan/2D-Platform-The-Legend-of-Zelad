using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Interfaces.BlockState
{
    public class BlockTapped : IBlockState
    {
        public BlockTapped(Block nBlock) : base(nBlock)
        {
        }

        public override void Enter()
        {
            CurrState = State.TAPPED;
            block.LastFrame = (int)block.SheetSize.X * (int)block.SheetSize.Y;
            block.Frame = block.LastFrame - 1;
            block.AutoFrame = false;
            block.IsVis = true;
            block.Velocity = new Vector2(0,0);
            block.Acceleration = new Vector2(0, 0);
        }

        public override void ChangeState(int state)
        {
            switch ((State)state)
            {
                case State.UNTAPPED:
                    Exit();
                    block.State = new BlockUntapped(block);
                    break;
            }
        }
    }
}
