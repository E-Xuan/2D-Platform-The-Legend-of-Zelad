using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Interfaces.BlockState
{
    public class BlockBumping : IBlockState
    {
        private Vector2 anchor;

        public BlockBumping(Block nBlock) : base(nBlock)
        {
        }

        public override void Enter()
        {
            CurrState = State.BUMPING;
            block.IsVis = true;
            anchor = block.Pos;
            block.Velocity = new Vector2(0,-2);
            block.Acceleration = new Vector2(0, (float)0.065);
        }

        public override void Exit()
        {
            block.Pos = anchor;
            if (Inventory.Count > 0)
            {
                //Spawn the inventory item here
                Inventory.RemoveAt(0);
            }
        }

        public override void ChangeState(int state)
        {
            switch ((State)state)
            {
                case State.TAPPED:
                    Exit();
                    block.State = new BlockTapped(block);
                    break;
                case State.UNTAPPED:
                    Exit();
                    block.State = new BlockUntapped(block);
                    break;
            }
        }

        public override void Update()
        {
            //reminder that (0,0) is top right
            if(Inventory.Count == 0 && block.Pos.Y > anchor.Y)
                ChangeState((int)State.TAPPED);
            else if(block.Pos.Y > anchor.Y)
                ChangeState((int)State.UNTAPPED);
            //we need to add logic to release an item
        }
    }
}
