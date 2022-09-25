using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.MarioPowerUpSprites
{
    internal class BigMario
    {
        private Texture2D bigCrouch;
        private Texture2D bigIdle;
        private Texture2D bigJump;
        private Texture2D bigTurning;
        private Texture2D bigToSmall;
        private Texture2D bigWalk;
        public void LoadContent(ContentManager content)
        {
            bigCrouch = content.Load<Texture2D>("BigMario/bigCrouching");
            bigIdle = content.Load<Texture2D>("BigMario/bigIdle");
            bigJump = content.Load<Texture2D>("BigMario/bigJump");
            bigTurning = content.Load<Texture2D>("BigMario/bigTurning");
            bigToSmall = content.Load<Texture2D>("BigMario/bigToSmall");
            bigWalk = content.Load<Texture2D>("BigMario/bigWalk");
        }
    }
}
