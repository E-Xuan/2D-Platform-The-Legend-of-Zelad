using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return new BrickBlock(BrickBlockSpriteSheet, new Vector2(1,1), nPos);
        }
        public ISprite CreateBrickBlockShard(Vector2 nPos)
        {
            return new BrickBlock(BrickBlockSpriteSheet, new Vector2(2, 2), nPos);
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
        public ISprite CreateHiddenBlock(Vector2 nPos)
        {
            return new InvisibleBlock(BrickBlockSpriteSheet, new Vector2(1, 1), nPos); 
        }
        public ISprite CreateUsedBlock(Vector2 nPos)
        {
            return new UsedBlock(UsedBlockSpriteSheet, new Vector2(1, 1), nPos);
        }
    }
}
