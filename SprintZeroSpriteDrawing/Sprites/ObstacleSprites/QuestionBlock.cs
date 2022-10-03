﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
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
        public QuestionBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base (nSprite, nSheetSize, nPos)
        {
            LastFrame = 3;
        }
    }
}
