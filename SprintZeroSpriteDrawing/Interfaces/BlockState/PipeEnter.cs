using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.BlockState
{
    internal class PipeEnter : IBlockState
    {
        private Vector2 anchor;

        public PipeEnter(Block nBlock) : base(nBlock)
        {
        }

        public PipeEnter(Block nBlock, List<Item> nInventory) : base(nBlock, nInventory)
        {
        }
        public override void Enter()
        {
            CurrState = State.PIPEENTER;
            block.IsVis = true;
            anchor = block.Pos;

            if (Inventory.Count > 0)
            {
                Game1.SpriteList.Add(Inventory[0]);
                Inventory[0].ChangeState((int)ItemState.State.EMERGING);
                CollisionManager.getCM().RegEntity(Inventory[0]);
                Inventory.RemoveAt(0);
            }

        }
        public override void Exit()
        {
            block.Pos = anchor;
        }
    }
}
