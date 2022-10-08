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

namespace SprintZeroSpriteDrawing.Collision.MarioCollision
{
    public class Mario_Block : ICommand
    {
        Direction CollisionSide;
        public MarioCollisionManager MarioCollisionManager;
        public Mario_Block(object nRef) : base(nRef)
        {
            CollisionSide = new Direction();
        }
        public override void Execute()
        {
            CollisionSide = CollisionDetector.getCD().DetectColDirection(MarioCollisionManager.mario, MarioCollisionManager.block);

            if (MarioCollisionManager.block.GetType() == typeof(GroundBlock))
            {
                if (CollisionSide == Direction.TOP)
                {
                    MarioCollisionManager.mario.Velocity = new Vector2(MarioCollisionManager.mario.Velocity.X, 0);
                }
                if(CollisionSide == Direction.BOTTOM)
                {
                    MarioCollisionManager.mario.Velocity = new Vector2(MarioCollisionManager.mario.Velocity.X, -MarioCollisionManager.mario.Velocity.Y);
                }
                if(CollisionSide != Direction.LEFT)
                {
                    MarioCollisionManager.mario.Velocity = new Vector2(0, MarioCollisionManager.mario.Velocity.Y);
                }
                if (CollisionSide != Direction.RIGHT)
                {
                    MarioCollisionManager.mario.Velocity = new Vector2(0, MarioCollisionManager.mario.Velocity.Y);
                }
            }
        }

    }
}
