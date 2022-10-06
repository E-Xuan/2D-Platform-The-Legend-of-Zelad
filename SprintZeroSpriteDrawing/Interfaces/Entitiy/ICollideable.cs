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
        public List<Tuple<ICommand, Direction, CType>> CollisionResponse { get; set; }
        public Rectangle BBox { get; set; }

        public ICollideable(Texture2D nSprite, Vector2 nPos, Rectangle nBBox) : base(nSprite, nPos)
        {
            BBox = nBBox;
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
        }
        public ICollideable(Texture2D nSprite, Vector2 nPos) : base(nSprite, nPos)
        {
            BBox = new Rectangle((int)nPos.X, (int)nPos.Y, (int)(nSprite.Width), (int)(nSprite.Height));
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
        }
        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            BBox = new Rectangle((int)nPos.X, (int)nPos.Y, (int)(nSprite.Width / nSheetSize.X), (int)(nSprite.Height / nSheetSize.Y));
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
        }

        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Rectangle nBBox) : base(nSprite, nSheetSize, nPos)
        {
            BBox = nBBox;
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
        }

        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Vector2 acceleration, Rectangle nBBox) : base(nSprite, nSheetSize, nPos, acceleration)
        {
            BBox = nBBox;
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
        }
        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Vector2 acceleration, Rectangle nBBox, List<Tuple<ICommand, Direction, CType>> nCollisionResponse) : base(nSprite, nSheetSize, nPos, acceleration)
        {
            BBox = nBBox;
            CollisionResponse = nCollisionResponse;
        }

    }
}
