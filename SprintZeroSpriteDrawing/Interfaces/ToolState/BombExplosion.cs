using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class BombExplosion : IToolState
    {
        public BombExplosion(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.BOMBEXPLOSION;
            tool.CollideableType = Entitiy.CType.NEUTRAL;
            tool.Velocity = new Vector2(0, 0);
            tool.Acceleration = new Vector2(0, 0);
        }
    }
}