using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZeroSpriteDrawing.Interfaces
{
    /// <summary>
    /// The ISprite interface, which contains all the information
    /// to render 2D sprites on a canvas, and contains game logic for
    /// updating the sprites, such as frame information or collision detection
    /// </summary>
    public interface ISprite
    {
        /// <summary>
        /// This is the texture to be displayed at position pos
        /// </summary>
        Texture2D Sprite { get; set; }
        /// <summary>
        /// This is the position to display the sprite at
        /// </summary>
        Vector2 Pos { get; set; }
        /// <summary>
        /// This determines whether the sprite is drawn or if any of the code in the draw method is fired
        /// </summary>
        bool IsVis { get; set; }
        public int Draw(SpriteBatch batch);
        public void Update();
        public void SetVis(int nIsVis);
        public void TogVis(int nIsVis);
        public void MoveY(int x);
        public void MoveX(int x);

    }
}
