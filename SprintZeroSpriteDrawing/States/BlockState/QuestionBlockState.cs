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
    public class QuestionBolckState : IBlockState
    {
        public ISprite sprite;
        public bool triggered;
        public Vector2 nPos;
        public bool Used { get { return triggered; } }

        public QuestionBolckState()
        {
            this.sprite = BlockSpriteFactory.getFactory().CreateQuestionBlock(nPos);
            triggered = false;
        }

        public void BeTriggered()
        {
            if (triggered == false)
            {
                this.sprite = BlockSpriteFactory.getFactory().CreateUsedBlock(nPos);
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
