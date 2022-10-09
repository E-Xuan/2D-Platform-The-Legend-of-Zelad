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
    public class HiddenBlockCollision : ICommand
    {
        Direction CollisionSide;
        public BlockCollisionManager BlockCollisionManager;
        public HiddenBlockCollision(object nRef) : base(nRef)
        {
            CollisionSide = new Direction();
        }
        public override void Execute()
        {
            CollisionSide = CollisionDetector.getCD().DetectColDirection(BlockCollisionManager.HBlock, BlockCollisionManager.mario);
            if (BlockCollisionManager.mario.GetType() == typeof(BigMario) || BlockCollisionManager.mario.GetType() == typeof(FireMario) || BlockCollisionManager.mario.GetType() == typeof(StarMario) || BlockCollisionManager.mario.GetType() == typeof(SmallMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    //Mario Fallllllll
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    BlockCollisionManager.HBlock.IsVis = true; // Not sure whether it's the right thing should happen
                    BlockCollisionManager.mario.Velocity = new Vector2(BlockCollisionManager.mario.Velocity.X, -BlockCollisionManager.mario.Velocity.Y);
                }
                if (CollisionSide == Direction.LEFT)
                {
                    //Mario Fallllllll
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    //Mario Fallllllll
                }
            }
        }
    }
}
