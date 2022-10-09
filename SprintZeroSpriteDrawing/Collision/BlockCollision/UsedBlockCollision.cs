using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using SprintZeroSpriteDrawing.Interfaces.MarioState;

namespace SprintZeroSpriteDrawing.Collision.BlockCollision
{
    public class UsedBlockCollision : ICommand
    {
        Direction CollisionSide;
        public BlockCollisionManager BlockCollisionManager;
        public UsedBlockCollision(object nRef) : base(nRef)
        {
            CollisionSide = new Direction();
        }
        public override void Execute()
        {
            CollisionSide = CollisionDetector.getCD().DetectColDirection(BlockCollisionManager.UBlock, BlockCollisionManager.mario);
            if (BlockCollisionManager.mario.GetType() == typeof(BigMario) || BlockCollisionManager.mario.GetType() == typeof(FireMario) || BlockCollisionManager.mario.GetType() == typeof(StarMario) || BlockCollisionManager.mario.GetType() == typeof(SmallMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    BlockCollisionManager.mario.Velocity = new Vector2(BlockCollisionManager.mario.Velocity.X, 0);
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    BlockCollisionManager.mario.Velocity = new Vector2(BlockCollisionManager.mario.Velocity.X, -BlockCollisionManager.mario.Velocity.Y);
                }
                if (CollisionSide == Direction.LEFT)
                {
                    BlockCollisionManager.mario.Velocity = new Vector2(0, BlockCollisionManager.mario.Velocity.Y);
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    BlockCollisionManager.mario.Velocity = new Vector2(0, BlockCollisionManager.mario.Velocity.Y);
                }
            }
            //Nothing happens for me. I AM STRONG
        }
    }
}
