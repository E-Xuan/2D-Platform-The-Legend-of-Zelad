using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.EnemyState
{
    public class ShellMoving : IEnemyState
    {
        public ShellMoving(Enemy nEnemy) : base(nEnemy)
        {
            CurrState = State.SHELLMOVING;
        }
        public override void Enter()
        {
            base.Enter();
        }
    }
}
