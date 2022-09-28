using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    internal class InvisibleBlock : Block
    {
        public InvisibleBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            IsVis = false;
        }
        public override void Bump(int marioState) {
            if (IsVis)
            {
                base.Bump(marioState);
            }
            IsVis = true;
        }
    }
}
