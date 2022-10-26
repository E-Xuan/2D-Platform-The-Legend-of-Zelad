using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.EnemyState
{
    public class ShellIdle : IEnemyState
    {
        public ShellIdle(Enemy nEnemy) : base(nEnemy)
        {
            CurrState = State.SHELLIDLE;
        }
        public override void Enter()
        {
            base.Enter();
            CurrState = State.SHELLIDLE;
            enemy.Frame = 2;
            enemy.Velocity = new Vector2(0, 0);
            enemy.Acceleration = new Vector2(0, 0);
        }
    }
}
