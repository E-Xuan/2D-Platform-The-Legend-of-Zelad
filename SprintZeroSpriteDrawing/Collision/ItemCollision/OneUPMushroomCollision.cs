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
    public class OneUPMushroomCollision : ICommand
    {
        Direction CollisionSide;
        public ItemCollisionManager ItemCollisionManager;
        public OneUPMushroomCollision(object nRef) : base(nRef)
        {
            CollisionSide = (Direction)nRef;
        }
        public override void Execute()
        {
            CollisionSide = CollisionDetector.getCD().DetectColDirection(ItemCollisionManager.oneUPMushroom, ItemCollisionManager.mario);
            //Not require in this sprint. IDK what gonna happen
        }
    }
}
