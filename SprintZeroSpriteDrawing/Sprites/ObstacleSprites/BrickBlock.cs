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
    internal class BrickBlock : Block
    {
        public BrickBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Rectangle nBBox) : base(nSprite, nSheetSize, nPos, nBBox)
        {
        }

        public override void Update()
        {
            base.Update();
            if (State.CurrState == Interfaces.BlockState.State.TAPPED)
            {
                this.ChangeState((int)Interfaces.BlockState.State.UNTAPPED);
            }
        }
    }
}
