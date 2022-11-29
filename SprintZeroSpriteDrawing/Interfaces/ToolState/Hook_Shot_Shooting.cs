using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class Hook_Shot_Shooting : IToolState
    {
        public Hook_Shot_Shooting(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.HOOKSHOTSHOOTING;
            tool.CollideableType = Entitiy.CType.SHOHOOKSHOT;
            tool.CollideMaybe = false;
            tool.AutoFrame = true;
            if (Mario.GetMario().GetDirection() > 0)
            {
                tool.Velocity = new Vector2(10, 0);
                tool.Acceleration = new Vector2((float)-.15, 0);
            }
            else
            {
                tool.Velocity = new Vector2(-10, 0);
                tool.Acceleration = new Vector2((float).15, 0);

            }
            tool.IsVis = true;
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.SIDE, CType.AVATAR_SMALL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.SIDE, CType.AVATAR_LARGE));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.TOP, CType.AVATAR_SMALL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.TOP, CType.AVATAR_LARGE));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.BOTTOM, CType.AVATAR_SMALL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.BOTTOM, CType.AVATAR_LARGE));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Floored, 0)), Direction.BOTTOM, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Walled, 0)), Direction.SIDE, CType.NEUTRAL));
            CollisionManager.getCM().RegEntity(tool);
            CollisionManager.getCM().RegMoving(tool);


        }
        public override void Enter()
        {
            Game1.SpriteList.Add(tool);
        }
        public virtual void Collect(int collect)
        {
            tool.CollideableType = CType.UNCOLLIDEABLE;
            Game1.SpriteList.Remove(tool);
            Hook_Shot_Pool.GetHook_ShotPool().Collect();
        }
    }
}
