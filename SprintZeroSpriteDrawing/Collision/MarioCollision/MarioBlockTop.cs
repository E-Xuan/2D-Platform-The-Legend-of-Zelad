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
using SprintZeroSpriteDrawing.Interfaces.MarioState;

namespace SprintZeroSpriteDrawing.Collision.MarioCollision
{
    public class MarioBlockTop : ICommand
    {
        public Mario mario;
        public MarioBlockTop(object nRef) : base(nRef)
        {
            mario = (Mario)nRef;
        }
        public override void Execute()
        {
            mario.Velocity = new Vector2(mario.Velocity.X, 0);
            mario.Pos = new Vector2(mario.Pos.X, mario.Pos.Y - (int)0.1);
            mario.ChangeAction((int)ActionState.IDLE);
        }
    }
}