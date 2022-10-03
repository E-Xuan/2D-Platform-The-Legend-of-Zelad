using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Interfaces.BlockState
{
    public class BlockBroken : IBlockState
    {
        public BlockBroken(Block nBlock) : base(nBlock)
        {
        }

        public override void Enter()
        {
            CurrState = State.BROKEN;
            block.IsVis = true;
            block.Velocity = new Vector2(0,0);
            block.Acceleration = new Vector2(0, 2);
        }
    }
}
