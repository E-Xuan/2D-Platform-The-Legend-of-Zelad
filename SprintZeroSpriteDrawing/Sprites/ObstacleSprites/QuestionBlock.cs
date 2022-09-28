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
    internal class QuestionBlock : Block
    {
        public QuestionBlockState QState;

        public QuestionBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base (nSprite, nSheetSize, nPos)
        {
            QState = new QuestionBlockState();
            LastFrame = 3;
        }
        public override void Collide()
        {
            QState.Collide();
            if (QState.GetState() == State.TAPPED)
            {
                LastFrame = 4;
                Frame = 3;
                AutoFrame = false;
            }
        }

        public override void Bump(int marioState)
        {
            if (QState.GetState() != State.TAPPED)
            {
                base.Bump(marioState);
            }
        }

        public override void Update()
        {
            base.Update();
            if (QState.GetState() != State.TAPPED && bumptime == 50)
            {
                QState.Collide(); 
                LastFrame = 5;
                Frame = 3;
                AutoFrame = false;
            }
        }
    }
}
