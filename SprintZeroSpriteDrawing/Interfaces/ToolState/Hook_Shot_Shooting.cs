using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private int resetCount = 0; 
        public Hook_Shot_Shooting(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.HOOKSHOTSHOOTING;
            tool.CollideableType = Entitiy.CType.SHOHOOKSHOT;
            tool.CollideMaybe = false;
            tool.AutoFrame = true;

            tool.Velocity = new Vector2(10, 0);
            tool.Acceleration = new Vector2((float)-0.15, 0);

            tool.IsVis = true;
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Hooked, 0)), Direction.BOTTOM, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Hooked, 0)), Direction.SIDE, CType.NEUTRAL));
            CollisionManager.getCM().RegEntity(tool);
            CollisionManager.getCM().RegMoving(tool);


        }
        public override void Update()
        {
            if (Mouse.GetState().X + Game1._Camera2D.Position.X - Mario.GetMario().Pos.X > 0)
            {
                tool.Velocity = new Vector2(20, 0);
                tool.Acceleration = new Vector2((float)-0.05, 0);
            }
            else if (Mouse.GetState().X + Game1._Camera2D.Position.X - Mario.GetMario().Pos.X < 0)
            {
                tool.Velocity = new Vector2(-20, 0);
                tool.Acceleration = new Vector2((float)0.05, 0);
            }
            else
            {
                tool.Velocity = new Vector2(0, 10);
                tool.Acceleration = new Vector2(0, (float)0.15);
            }

            resetCount++;
            if (resetCount > 50)
            {
                tool.AutoFrame = true;
                tool.State = new Hook_Shot_Retract(tool);
            }

            base.Update();
        }
        public override void Enter()
        {
            Game1.SpriteList.Add(tool);
        }
        public virtual void Hooked(int hooked)
        {
            tool.State = new Hook_Shot_Collectible(tool);
        }
    }
}
