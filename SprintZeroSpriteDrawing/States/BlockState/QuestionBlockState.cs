using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.States.BlockState
{
    public class QuestionBlockState : IBlockState
    {
        public ISprite sprite;
        public bool triggered;
        public bool Used { get { return triggered; } }

        public QuestionBlockState()
        {
            this.sprite = BlockSpriteFactory.Sprite.CreateQuestionBlock();
            triggered = false;
        }

        public void BeTriggered()
        {
            if (triggered == false)
            {
                //this.sprite = BlockSpriteFactory.Sprite.CreateBrickBlock();
                /*Need to a small bump up, and returned to a used state*/
                triggered = true;
            }
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch);
        }

    }
}
