using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.States.BlockState
{
    internal class BrickBolckState : IBlockState
    {
        private ISprite sprite;
        private bool triggered;
        public bool Used { get { return triggered; } }
        
        public BrickBolckState()
        {

        }

        public void BeTriggered()
        {

        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
        }

    }
}
