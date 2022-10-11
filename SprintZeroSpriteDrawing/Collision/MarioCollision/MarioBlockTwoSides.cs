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
using System.Runtime.CompilerServices;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;

namespace SprintZeroSpriteDrawing.Collision.MarioCollision
{
    public class MarioBlockTwoSides : ICommand
    {
        public Mario mario;
        public MarioBlockTwoSides(object nRef) : base(nRef)
        {
            mario = (Mario)nRef;
        }
        public override void Execute()
        {
            mario.Velocity = new Vector2(0, mario.Velocity.Y);

        }
    }
}
