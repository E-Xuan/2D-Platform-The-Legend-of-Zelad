using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class BlockSpriteFactory
    {
        public Vector2 nPos { get; set; }
        public Vector2 SheetSize;

        public Texture2D BrickBlockSpriteSheet;
        public Texture2D QuestionBlockSpriteSheet;
        public Texture2D UsedBlockSpriteSheet;
        public Texture2D HiddenBlockSpriteSheet;
        public Texture2D GroundBlockSpriteSheet;
        public Texture2D StairBlockSpriteSheet;

        private static BlockSpriteFactory sprite;

        public static BlockSpriteFactory getFactory() 
        {
            if (sprite == null)
            {
                sprite = new BlockSpriteFactory();
            }
            return sprite;
        }

        public void LoadContent(ContentManager content)
        {
            HiddenBlockSpriteSheet = content.Load<Texture2D>("Obstacles/InvisibleBlock");
            UsedBlockSpriteSheet = content.Load<Texture2D>("Obstacles/HitQuestionBlock(Overworld)");
            BrickBlockSpriteSheet = content.Load<Texture2D>("Obstacles/BrickBlock(Overworld)");
            QuestionBlockSpriteSheet = content.Load<Texture2D>("Obstacles/QuestionBlock(Overworld)");
            GroundBlockSpriteSheet = content.Load<Texture2D>("Obstacles/GroundBlock(Overworld)");
            StairBlockSpriteSheet = content.Load<Texture2D>("Obstacles/StairBlock");
        }
        
        public ISprite CreateBrickBlock(Vector2 nPos)
        {
            var block = new BrickBlock(BrickBlockSpriteSheet, new Vector2(1, 1), nPos, new Rectangle((int)nPos.X, (int)nPos.Y, 32, 32));
            block.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(null, Direction.BOTTOM, CType.AVATAR_LARGE));
            return block;
        }
        public ISprite CreateGroundBlock(Vector2 nPos)
        {
            return new GroundBlock(GroundBlockSpriteSheet, new Vector2(1, 1), nPos);
        }
        public ISprite CreateStairBlock(Vector2 nPos)
        {
            return new StairBlock(StairBlockSpriteSheet, new Vector2(1, 1), nPos);
        }
        public ISprite CreateQuestionBlock(Vector2 nPos)
        {
            return new QuestionBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos);
        }
        public ISprite CreateMQuestionBlock(Vector2 nPos)
        {
            return new QuestionBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new Rectangle((int)nPos.X, (int)nPos.Y, 32, 32), new List<ICollideable>{(ICollideable)ItemSpriteFactory.getFactory().createFlower(Vector2.Add(nPos, new Vector2(0, -48)))});
        }
        public ISprite CreateHiddenBlock(Vector2 nPos)
        {
            return new InvisibleBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos); 
        }
        public ISprite CreateUsedBlock(Vector2 nPos)
        {
            return new UsedBlock(UsedBlockSpriteSheet, new Vector2(1, 1), nPos);
        }
    }
}
