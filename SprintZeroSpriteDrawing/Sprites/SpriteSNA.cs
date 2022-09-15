using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZeroSpriteDrawing.Sprites
{

    /// <summary>
    /// This is a stationary, non-animated, sprite class that is
    /// used to build common items like scenery and blocks that don't
    /// need to move.
    /// </summary>
    class SpriteSNA : ISprite
    {
        public bool IsVis { get; set; }
        public Texture2D Sprite { get; set; }
        public Vector2 Pos { get; set; }
        public SpriteSNA(Texture2D nSprite, Vector2 nPos) {
            Sprite = nSprite;
            Pos = nPos;
        }
        public int Draw(SpriteBatch batch)
        {
            if (IsVis)
            {
                batch.Draw(Sprite, Pos, Color.White);
                return -1;
            }
            return -2;
        }
        virtual public void Update()
        {
            //OVERRIDE ME
        }
        public void SetVis(int nIsVis)
        {
            IsVis = nIsVis > 0;
        }
        public void TogVis(int nIsVis)
        {
            IsVis = !IsVis;
        }

    }
}
