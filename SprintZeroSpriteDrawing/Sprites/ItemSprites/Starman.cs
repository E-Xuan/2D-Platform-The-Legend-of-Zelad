using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Collision.CollisionManager;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class Starman : Item
    { 
        public Starman(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            
        }
        public override void Update()
        {
            base.Update();

            if (State.CurrState == Interfaces.ItemState.State.EMERGING)
            {
                Velocity = new Vector2(4, 0);
                Acceleration = new Vector2(0, (float).065);
                CollisionManager.getCM().RegMoving(this);
            }
        }
    }
}
