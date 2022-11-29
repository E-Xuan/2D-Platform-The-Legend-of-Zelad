using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class HookShotShooting : IToolState
    {
        public HookShotShooting(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.HOOKSHOTSHOOTING;
            tool.CollideableType = Entitiy.CType.SHOARROW;
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
        }
        public override void Enter()
        {
            Game1.SpriteList.Add(tool);

        }
    }
}
