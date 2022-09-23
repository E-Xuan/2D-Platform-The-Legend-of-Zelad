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
    public class BrickBolckState : IBlockState
    {
        private ISprite sprite;
        public bool triggered;
        public bool Used { get { return triggered; } }
        
        public BrickBolckState()
        {
            this.sprite = BlockSpriteFactory.Sprite.CreateBrickBlock();
            triggered = false;
        }

        public void BeTriggered()
        {
            if(triggered == false)
            {
                /*Need to spawn small bricks*/
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
