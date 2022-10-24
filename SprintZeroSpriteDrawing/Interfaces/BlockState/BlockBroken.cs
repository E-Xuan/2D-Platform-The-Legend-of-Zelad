using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Interfaces.BlockState
{
    public class BlockBroken : IBlockState
    {
        public BlockBroken(Block nBlock) : base(nBlock)
        {
        }
        public BlockBroken(Block nBlock, List<Item> nInventory) : base(nBlock, nInventory)
        {
        }

        public override void Enter()
        {
            
            CurrState = State.BROKEN;
            Game1.SpriteList.Remove(block);
            CollisionManager.getCM().DeRegEntity(block);
            Game1.SpriteList.Add((Block)(BlockSpriteFactory.getFactory().CreateBrokenBlock(block.Pos)));
        }


        public override void Exit()
        {
            base.Exit();
        }
    }
}
