using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.Entitiy
{
    public enum Direction
    {
        TOP,
        BOTTOM,
        LEFT,
        RIGHT
    }

    public enum CType
    {
        AVATAR_SMALL,
        AVATAR_LARGE,
        AVATAR_STAR,
        FRIENDLY,
        NEUTRAL,
        ENEMY
    }

    public class ICollideable : IRBody
    {
        //make this into a switch case later with method
        public List<Tuple<ICommand, Direction, CType>> CollisionResponse { get; set; }
        public Rectangle BBox { get; set; }
        public bool DrawBBox { get; set; }

        public ICollideable(Texture2D nSprite, Vector2 nPos, Rectangle nBBox) : base(nSprite, nPos)
        {
            BBox = nBBox;
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
            DrawBBox = true;
        }
        public ICollideable(Texture2D nSprite, Vector2 nPos) : base(nSprite, nPos)
        {
            BBox = new Rectangle((int)(nPos.X - nSprite.Width), (int)(nPos.Y - nSprite.Height), (int)(nSprite.Width), (int)(nSprite.Height));
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
            DrawBBox = true;
        }
        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            BBox = new Rectangle((int)(nPos.X - nSprite.Width / nSheetSize.X), (int)(nPos.Y - nSprite.Height / nSheetSize.Y), (int)(nSprite.Width / nSheetSize.X), (int)(nSprite.Height / nSheetSize.Y));
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
            DrawBBox = true;
        }

        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Rectangle nBBox) : base(nSprite, nSheetSize, nPos)
        {
            BBox = nBBox;
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
            DrawBBox = true;
        }

        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Vector2 acceleration, Rectangle nBBox) : base(nSprite, nSheetSize, nPos, acceleration)
        {
            BBox = nBBox;
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
            DrawBBox = true;
        }
        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Vector2 acceleration, Rectangle nBBox, List<Tuple<ICommand, Direction, CType>> nCollisionResponse) : base(nSprite, nSheetSize, nPos, acceleration)
        {
            BBox = nBBox;
            CollisionResponse = nCollisionResponse;
            DrawBBox = true;
        }
        public override void Draw(SpriteBatch batch)
        {
            Draw(batch, SpriteEffects.None);
        }
        public override void Draw(SpriteBatch batch, SpriteEffects effects)
        {
            base.Draw(batch, effects);
            if (DrawBBox)
            {
                Texture2D _texture;
                _texture = new Texture2D(Game1.Graphics.GraphicsDevice, 1, 1);
                _texture.SetData(new Color[] { Color.White });
                batch.Draw(_texture, new Rectangle(BBox.Left, BBox.Top, BBox.Width, 1), Color.White);
                batch.Draw(_texture, new Rectangle(BBox.Right, BBox.Top, 1, BBox.Height), Color.White);
                batch.Draw(_texture, new Rectangle(BBox.Left, BBox.Bottom, BBox.Width, 1), Color.White);
                batch.Draw(_texture, new Rectangle(BBox.Left, BBox.Top, 1, BBox.Height), Color.White);
            }
        }
    }
}
