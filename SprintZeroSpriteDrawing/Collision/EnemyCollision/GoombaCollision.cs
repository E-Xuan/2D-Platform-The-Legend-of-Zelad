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

namespace SprintZeroSpriteDrawing.Collision.EnemyCollision
{
    public class GoombaCollision : ICommand
    {
        Direction CollisionSide;
        public EnemyCollisionManager EnemyCollisionManager;
        public GoombaCollision(object nRef) : base(nRef)
        {
            CollisionSide = (Direction)nRef;
        }
        public override void Execute()
        {
            CollisionSide = CollisionDetector.getCD().DetectColDirection(EnemyCollisionManager.gommba, EnemyCollisionManager.mario);
            if(EnemyCollisionManager.mario.GetType() == typeof(SmallMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    //Goomba Die
                    EnemyCollisionManager.mario.Velocity = new Vector2(EnemyCollisionManager.mario.Velocity.X, 0);
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    //Mario Die
                    EnemyCollisionManager.mario.Velocity = new Vector2(0, 0);
                    EnemyCollisionManager.mario.TakeDamage(-1);

                }
                if (CollisionSide == Direction.LEFT)
                {
                    //Mario Die
                    EnemyCollisionManager.mario.Velocity = new Vector2(0, 0);
                    EnemyCollisionManager.mario.TakeDamage(-1);
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    //Mario Die
                    EnemyCollisionManager.mario.Velocity = new Vector2(0, 0);
                    EnemyCollisionManager.mario.TakeDamage(-1);
                }
            }

            //We don't need this Mario keeps track of his powerup already you just have to call take damage
           /* if (EnemyCollisionManager.mario.GetType() == typeof(BigMario) || EnemyCollisionManager.mario.GetType() == typeof(FireMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    //Goomba Die
                    EnemyCollisionManager.mario.Velocity = new Vector2(EnemyCollisionManager.mario.Velocity.X, 0);
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    //Mario damage to small mario
                }
                if (CollisionSide == Direction.LEFT)
                {                    
                    //Mario damage to small mario
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    //Mario damage to small mario
                }
            }*/

            
            if(EnemyCollisionManager.mario.GetType() == typeof(StarMario))
            {
                if (CollisionSide == Direction.TOP)
                {
                    //Goomba Die
                }
                if (CollisionSide == Direction.BOTTOM)
                {
                    //Goomba Die
                }
                if (CollisionSide == Direction.LEFT)
                {
                    //Goomba Die
                }
                if (CollisionSide == Direction.RIGHT)
                {
                    //Goomba Die
                }
            }

        }
    }
}
