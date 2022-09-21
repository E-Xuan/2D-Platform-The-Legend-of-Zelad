using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites
{
    internal class SawyerB : SpriteMA
    {
        int Offset = 0;
        public SawyerB(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
        }
        public override void Update() {
            if (Offset - 50 >= 0)
            {
                base.MoveX(1);
            }
            else {
                base.MoveX(-1);
            }
            Offset = (Offset + 1) % 100;
        }
    }
}
