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
    internal class Block : SpriteMA
    {
        protected int bumptime = 51;

        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base (nSprite, nSheetSize, nPos)
        {
            IsVis = true;
        }
        public virtual void Collide()
        {
        }

        public virtual void Bump(int marioState)
        {
            if (bumptime >= 50) 
                bumptime = 0;
        }

        public override void Update()
        {
            if (bumptime < 25)
            {
                MoveY(-2);
                bumptime++;
            }
            else if (bumptime < 50)
            { 
                MoveY(2); 
                bumptime++;
            }
        }
    }
}
