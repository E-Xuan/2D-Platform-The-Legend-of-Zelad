using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class BombMoving : IToolState
    {
        public BombMoving(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.BOMBMOVING;
            tool.CollideableType = Entitiy.CType.NEUTRAL;
            if (Mario.GetMario().GetDirection() > 0)
            {
                tool.Velocity = new Vector2(10, 0);
            }
            else
            {
                tool.Velocity = new Vector2(-10, 0);
            }
            
            tool.Acceleration = new Vector2(0, (float).10);
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Walled, 0)), Direction.SIDE, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Floored, 0)), Direction.BOTTOM, CType.NEUTRAL));

        }
    }
}
