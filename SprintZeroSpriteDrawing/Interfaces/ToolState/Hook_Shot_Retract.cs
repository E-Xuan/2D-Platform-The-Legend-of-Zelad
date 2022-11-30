using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.EnemyState;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using Microsoft.Xna.Framework.Input;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class Hook_Shot_Retract : IToolState
    {
        public Hook_Shot_Retract(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.HOOKSHOTRETRACT;
            tool.CollideableType = CType.SHOHOOKSHOT;
            tool.AutoFrame = true;
            //tool.Velocity = new Microsoft.Xna.Framework.Vector2((float)-0.03 * (tool.Pos.X - Mario.GetMario().Pos.X), (float)-0.03 * (tool.Pos.Y - Mario.GetMario().Pos.Y));
        }
        public override void Update()
        {
            if (Mouse.GetState().X + Game1._Camera2D.Position.X - Mario.GetMario().Pos.X > 0)
            {
                tool.Velocity = new Vector2(10, 0); 
            }
            else if (Mouse.GetState().X + Game1._Camera2D.Position.X - Mario.GetMario().Pos.X < 0)
            {
                tool.Velocity = new Vector2(-10, 0);
            }
            else
            {
                tool.Velocity = new Vector2(0, 10);
            }
            //           if (Vector2.Subtract(Mario.GetMario().Pos, tool.Pos).Length() > 120)
            //           {
            //               tool.Velocity = new Microsoft.Xna.Framework.Vector2(
            //                   (float)-0.075 * (tool.Pos.X - Mario.GetMario().Pos.X),
            //                   (float)-0.075 * (tool.Pos.Y - Mario.GetMario().Pos.Y));
            //               Mario.GetMario().Velocity = -tool.Velocity;
            //           }

            base.Update();
        }
    }
}
