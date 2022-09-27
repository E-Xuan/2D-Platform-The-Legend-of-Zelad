using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    internal class FireFlower : SpriteMA
    {
        public FireFlower(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            IsVis = true;
        }
    }
}
