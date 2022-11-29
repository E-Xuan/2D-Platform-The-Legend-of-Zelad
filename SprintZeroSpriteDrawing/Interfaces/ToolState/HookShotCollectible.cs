using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class HookShotCollectible : IToolState
    {
        public HookShotCollectible(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.HOOKSHOTCOL;
            tool.CollideableType = Entitiy.CType.COLARROW;
            tool.AutoFrame = false;
            tool.Velocity = new Vector2(0, 0);
            tool.Acceleration = new Vector2(0, 0);
            tool.IsVis = true;
        }
    }
}
