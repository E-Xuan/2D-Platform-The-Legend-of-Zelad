using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.States.BlockState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.BlockState;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class Block : ICollideable
    {
        public IBlockState State { get; set; }
        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            State = new BlockUntapped(this);
        }
        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Rectangle nBBox) : base (nSprite, nSheetSize, nPos, nBBox)
        {
            State = new BlockUntapped(this);
        }
        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, List<ICollideable> Inventory) : base(nSprite, nSheetSize, nPos)
        {
            State = new BlockUntapped(this, Inventory);
        }
        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Rectangle nBBox, List<ICollideable> Inventory) : base(nSprite, nSheetSize, nPos, nBBox)
        {
            State = new BlockUntapped(this, Inventory);
        }
        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Vector2 acceleration, Rectangle nBBox) : base(nSprite, nSheetSize, nPos, acceleration, nBBox)
        {
            State = new BlockUntapped(this);
        }
        public void ChangeState(int state)
        {
            this.State.ChangeState(state);
        }
        public override void Update()
        {
            State.Update();
            base.Update();
        }
    }
}
