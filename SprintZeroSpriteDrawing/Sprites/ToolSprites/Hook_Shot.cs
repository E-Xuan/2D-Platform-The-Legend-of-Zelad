using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ToolSprites
{
    public class Hook_Shot : Tool
    {
        public Hook_Shot(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Draw(SpriteBatch batch)
        {
            SpriteEffects effects = Mario.GetMario().GetDirection() < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;



            base.Draw(batch, effects);
        }
    }
}