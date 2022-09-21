using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites
{
    internal class Sawyer : SpriteMNA
    {
        int Offset = 0;
        public Sawyer(Texture2D nSprite, Vector2 nPos) : base(nSprite, nPos)
        {
        }
        public override void Update() {
            if (Offset - 50 >= 0)
            {
                base.MoveY(1);
            }
            else {
                base.MoveY(-1);
            }
            Offset = (Offset + 1) % 100;
        }
    }
}
