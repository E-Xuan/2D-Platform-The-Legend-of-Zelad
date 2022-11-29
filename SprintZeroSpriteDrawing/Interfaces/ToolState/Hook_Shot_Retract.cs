using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.EnemyState;
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
    public class Hook_Shot_Retract : IToolState
    {
        public Hook_Shot_Retract(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.HOOKSHOTRETRACT;
            tool.CollideableType = Entitiy.CType.SHOHOOKSHOT;
            tool.CollideMaybe = false;
            tool.AutoFrame = true;
            //tool.Velocity = new Microsoft.Xna.Framework.Vector2((float)-0.03 * (tool.Pos.X - Mario.GetMario().Pos.X), (float)-0.03 * (tool.Pos.Y - Mario.GetMario().Pos.Y));
        }
        public override void Update()
        {
            tool.Velocity = new Microsoft.Xna.Framework.Vector2((float)-0.05 * (tool.Pos.X - Mario.GetMario().Pos.X), (float)-0.05 * (tool.Pos.Y - Mario.GetMario().Pos.Y));

            base.Update();
        }
    }
}
