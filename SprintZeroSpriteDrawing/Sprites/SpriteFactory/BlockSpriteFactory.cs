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

        private static BlockSpriteFactory sprite = new BlockSpriteFactory();
        public static BlockSpriteFactory Sprite
        {
            get { return sprite; }
        }

        public void LoadContent(ContentManager content)
        {
            HiddenBlockSpriteSheet = content.Load<Texture2D>("Obstacles/InvisibleBlock");
            UsedBlockSpriteSheet = content.Load<Texture2D>("Obstacles/HitQuestionBlock(Overworld)");
            BrickBlockSpriteSheet = content.Load<Texture2D>("Obstacles/BrickBlock(Overworld)");
            QuestionBlockSpriteSheet = content.Load<Texture2D>("Obstacles/QuestionBlock(Overworld)");
        }

        public ISprite CreateBrickBlock()
        {
            return new BrickBlock(BrickBlockSpriteSheet, SheetSize, nPos);
        }
        public ISprite CreateQuestionBlock()
        {
            return new QuestionBlock(QuestionBlockSpriteSheet, SheetSize, nPos);
        }
        public ISprite CreateHiddenBlock()
        {
            return new InvisibleBlock(HiddenBlockSpriteSheet, SheetSize, nPos); 
        }
    }
}
