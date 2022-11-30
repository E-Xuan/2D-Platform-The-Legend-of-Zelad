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
        float relativeMouseX;
        float relativeMouseY;
        public Hook_Shot_Shooting(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.HOOKSHOTSHOOTING;
            tool.CollideableType = Entitiy.CType.SHOHOOKSHOT;
            tool.CollideMaybe = false;
            tool.AutoFrame = true;
            //tool.Velocity = new Vector2((float)(-0.05 * (Mouse.GetState().X - Mario.GetMario().Pos.X)), (float)(0.05 * Mouse.GetState().Y - Mario.GetMario().Pos.Y));
            //tool.Velocity = new Vector2(10, 0);
            //tool.Velocity = new Vector2(relativeMouseX, relativeMouseY);
            //tool.Acceleration = new Vector2((float)-0.15, 0);

            tool.Velocity = new Vector2((Mouse.GetState().X + Game1._Camera2D.Position.X - Mario.GetMario().Pos.X) / 100, (Mouse.GetState().Y + Game1._Camera2D.Position.Y - Mario.GetMario().Pos.Y) / 100);
            tool.Acceleration = new Vector2(0, (float)0.1);

            tool.IsVis = true;
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Hooked, 0)), Direction.BOTTOM, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Hooked, 0)), Direction.SIDE, CType.NEUTRAL));
            CollisionManager.getCM().RegEntity(tool);
            CollisionManager.getCM().RegMoving(tool);


        }
        public override void Update()
        {
            resetCount++;
            if (resetCount > 75)
            {
                tool.AutoFrame = true;
                tool.State = new Hook_Shot_Retract(tool);
            }
            float relativeMouseX = Mouse.GetState().X + Game1._Camera2D.Position.X;
            float relativeMouseY = Mouse.GetState().Y + Game1._Camera2D.Position.Y;  

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
