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
        public int BrickBlockSpriteSheetCol { get; }
        public int BrickBlockSpriteSheetRow { get; }
        public int BrickBlockTotalFrames { get; }
        public int QuestionBlockSpriteSheetCol { get; }
        public int QuestionBlockSpriteSheetRow { get; }
        public int QuestionBlockTotalFrames { get; } = 3;
        public int UsedBlockSpriteSheetCol { get; }
        public int UsedBlockSpriteSheetRow { get; }
        public int UsedBlockTotalFrames { get; }
        public Vector2 nPos { get; set; }


        private Texture2D BrickBlockSpriteSheet;
        private Texture2D QuestionBlockSpriteSheet;
        private Texture2D UsedBlockSpriteSheet;

        private static BlockSpriteFactory sprite = new BlockSpriteFactory();
        public static BlockSpriteFactory Sprite
        {
            get { return sprite; }
        }

        public void LoadContent(ContentManager content)
        {
            UsedBlockSpriteSheet = content.Load<Texture2D>("HitQuestionBlock(Overworld)");
            BrickBlockSpriteSheet = content.Load<Texture2D>("Obstacles/BrickBlock(Overworld)");
            QuestionBlockSpriteSheet = content.Load<Texture2D>("Obstacles/QuestionBlock(Overworld)");
        }

        public ISprite CreateBrickBlock()
        {
            return null;
            //return new BrickBlock(BrickBlockSpriteSheet, nPos);
        }


        public int BrickBlockWidth
        {
            get { return BrickBlockSpriteSheet.Width / BrickBlockSpriteSheetCol; }
        }
        public int BrickBlockHeight
        {
            get { return BrickBlockSpriteSheet.Height / BrickBlockSpriteSheetRow; }
        }
        public int QuestionBlockWidth
        {
            get { return QuestionBlockSpriteSheet.Width / QuestionBlockSpriteSheetCol; }
        }
        public int QuestionBlockHeight
        {
            get { return QuestionBlockSpriteSheet.Height / QuestionBlockSpriteSheetRow; }
        }
        public int UsedBlockWidth
        {
            get { return UsedBlockSpriteSheet.Width / UsedBlockSpriteSheetCol; }
        }
        public int UsedBlockHeight
        {
            get { return UsedBlockSpriteSheet.Height / UsedBlockSpriteSheetRow; }
        }

    }
}
