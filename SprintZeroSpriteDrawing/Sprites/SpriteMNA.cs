using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SprintZeroSpriteDrawing.Sprites
{
    /// <summary>
    /// This is a moving, non-animated, sprite class that is
    /// used to build common items like enemies and moving platforms
    /// </summary>
    internal class SpriteMNA : ISprite
    {
        public bool IsVis { get; set; }
        public Texture2D Sprite { get; set; }
        public Vector2 Pos { get; set; }

        public SpriteMNA(Texture2D nSprite, Vector2 nPos)
        {
            Sprite = nSprite;
            Pos = nPos;
        }

        public void MoveSprite(Vector2 displacement)
        {
            Pos = Vector2.Add(Pos, displacement);
        }
        public void MoveX(int pixels)
        {
            Pos = Vector2.Add(Pos, new Vector2(pixels, 0));
        }
        public void MoveY(int pixels)
        {
            Pos = Vector2.Add(Pos, new Vector2(0, pixels));
        }
        public int Draw(SpriteBatch batch)
        {
            if (IsVis) {
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
