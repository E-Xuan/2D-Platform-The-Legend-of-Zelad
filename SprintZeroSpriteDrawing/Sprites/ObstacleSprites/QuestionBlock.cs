using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.States.BlockState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    internal class QuestionBlock : SpriteMA
    {
        public QuestionBlockState QState;

        public QuestionBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base (nSprite, nSheetSize, nPos)
        {
            QState = new QuestionBlockState();
                IsVis = true;
            LastFrame = 3;
        }
        public void Collide()
        {
            QState.Collide();
            if (QState.GetState() == State.TAPPED)
            {
                Frame = 4;
                AutoFrame = false;
            }
        }
    }
}
