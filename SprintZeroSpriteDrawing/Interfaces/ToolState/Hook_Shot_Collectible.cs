using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class Hook_Shot_Collectible : IToolState
    {
        public Hook_Shot_Collectible(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.HOOKSHOTCOL;
            tool.CollideableType = Entitiy.CType.COLHOOKSHOT;
            tool.CollideMaybe = false;
            tool.AutoFrame = false;
            tool.Velocity = new Microsoft.Xna.Framework.Vector2(0, 0);
            tool.Acceleration = new Microsoft.Xna.Framework.Vector2(0, 0);
        }
    }
}
