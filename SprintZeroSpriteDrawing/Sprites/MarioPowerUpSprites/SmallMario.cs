using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.MarioPowerUpSprites
{
    internal class SmallMario
    {
        private Texture2D smallIdle;
        private Texture2D smallJump;
        private Texture2D smallWalk;
        private Texture2D smallTurning;
        public void LoadContent(ContentManager content)
        {
            smallIdle = content.Load<Texture2D>("SmallMario/SmallIdle");
            smallJump = content.Load<Texture2D>("SmallMario/smallJump");
            smallWalk = content.Load<Texture2D>("SmallMario/smallWalk");
            smallTurning = content.Load<Texture2D>("SmallMario/smallTurning");
        }

    }
}
