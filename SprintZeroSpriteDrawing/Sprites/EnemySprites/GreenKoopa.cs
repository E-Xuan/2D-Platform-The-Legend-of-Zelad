using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;

namespace SprintZeroSpriteDrawing.Sprites.EnemySprites
{
    internal class GreenKoopa : SpriteMA
    {
        public GreenKoopa(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            IsVis = true;
            LastFrame = 2;
        }
    }
}
