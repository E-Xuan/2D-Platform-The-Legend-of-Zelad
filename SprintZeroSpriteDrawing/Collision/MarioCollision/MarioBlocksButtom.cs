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
    public class MarioBlocksButtom : ICommand
    {
        public Mario mario;
        public MarioBlocksButtom(object nRef) : base(nRef)
        {
            mario = (Mario)nRef;
        }
        public override void Execute()
        {
            mario.Velocity = new Vector2(mario.Velocity.X, -mario.Velocity.Y);
            
        }
    }
}
