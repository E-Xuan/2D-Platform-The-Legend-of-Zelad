using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces.ItemState;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.EnemyState
{
    public class EnemyMoving : IEnemyState
    {
        public EnemyMoving(Enemy nEnemy) : base(nEnemy)
        {
            CurrState = State.MOVING;
            //enemy.Velocity = new Vector2(-1, 0);
            //enemy.Acceleration = new Vector2(0, (float).065);
            //CollisionManager.getCM().RegEntity(enemy);

        }
        public override void Enter()
        {
            base.Enter();
            CurrState = State.MOVING;
            enemy.Velocity = new Vector2(-1, -1);
            enemy.Acceleration = new Vector2(0, (float).065);
            //CollisionManager.getCM().RegEntity();


        }
    }
}
