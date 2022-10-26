using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class Coins : Item
    {
        public Coins(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {

        }
        public override void Update()
        {
            base.Update();
            Acceleration = new Vector2(0, (float)(.065));
            if (State.CurrState == Interfaces.ItemState.State.EMERGING && Velocity.Y >= 0)
            {
                State.CurrState = Interfaces.ItemState.State.COLLECTING;
            }
        }
    }
}
