using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
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
            enemy = nEnemy;
            enemy.CollideableType = Entitiy.CType.NEUTRAL;
            enemy.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Pew, 0)), Direction.TOP, CType.AVATAR_SMALL));
            enemy.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Pew, 0)), Direction.TOP, CType.AVATAR_LARGE));
            CurrState = State.SHELLIDLE;
            enemy.Frame = enemy.LastFrame;
            enemy.AutoFrame = false;
            enemy.Velocity = new Vector2(0, 0);
            enemy.Acceleration = new Vector2(0, 0);
        }

        public void Pew(int pew) 
        {
            enemy.State = new ShellMoving(enemy);
        }
    }
}
