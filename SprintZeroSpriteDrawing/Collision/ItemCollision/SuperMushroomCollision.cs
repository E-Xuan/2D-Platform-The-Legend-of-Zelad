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

namespace SprintZeroSpriteDrawing.Collision.ItemCollision
{
    public class SuperMuchroomCollision : ICommand
    {
        Direction CollisionSide;
        public ItemCollisionManager ItemCollisionManager;
        public SuperMuchroomCollision(object nRef) : base(nRef)
        {
            CollisionSide = (Direction)nRef;
        }
        public override void Execute()
        {
            CollisionSide = CollisionDetector.getCD().DetectColDirection(ItemCollisionManager.superMushroom, ItemCollisionManager.mario);
            if (ItemCollisionManager.mario.GetType() == typeof(SmallMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    ItemCollisionManager.superMushroom.IsVis = false;
                    //Mario changes to big Mario
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    ItemCollisionManager.superMushroom.IsVis = false;
                    //Mario changes to big Mario
                }
                if (CollisionSide == Direction.LEFT)
                {
                    ItemCollisionManager.superMushroom.IsVis = false;
                    //Mario changes to big Mario
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    ItemCollisionManager.superMushroom.IsVis = false;
                    //Mario changes to big Mario
                }
            }
            if (ItemCollisionManager.mario.GetType() == typeof(BigMario) || ItemCollisionManager.mario.GetType() == typeof(FireMario) || ItemCollisionManager.mario.GetType() == typeof(StarMario))
            {
                //Nothing gonna happen I assume. Just IsVis of mushroom set to false
            }
        }
    }
}
