using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class BrickBlock
    {
        public int BrickBlockSpriteSheetCol { get; }
        public int BrickBlockSpriteSheetRow { get; }
        public int BrickBlockTotalFrames { get; }
        public int QuestionBlockSpriteSheetCol { get; }
        public int QuestionBlockSpriteSheetRow { get; }
        public int QuestionBlockTotalFrames { get; }
        public int UsedBlockSpriteSheetCol { get; }
        public int UsedBlockSpriteSheetRow { get; }
        public int UsedBlockTotalFrames { get; }


        private Texture2D BrickBlockSpriteSheet;
        private Texture2D QuestionBlockSpriteSheet;
        private Texture2D UsedBlockSpriteSheet;

        public void LoadContent(ContentManager content)
        {
            //UsedBlockSpriteSheet = content.Load<Texture2D>("UsedBlockSpriteSheet");
            //BrickBlockSpriteSheet = content.Load<Texture2D>("BrickBlockSpriteSheet");
            //QuestionBlockSpriteSheet = content.Load<Texture2D>("QuestionBlockSpriteSheet");
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
