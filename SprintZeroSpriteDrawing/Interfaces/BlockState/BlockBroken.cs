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
        public BlockBroken(Block nBlock, List<ICollideable> nInventory) : base(nBlock, nInventory)
        {
        }

        public override void Enter()
        {
            
            CurrState = State.BROKEN;
            block.IsVis = false;
            
        }

        public override void Exit()
        {

            base.Exit();
        }
    }
}
