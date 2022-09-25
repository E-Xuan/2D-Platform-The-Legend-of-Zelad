using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.MarioPowerUpSprites
{
    internal class FireMario
    {
        private Texture2D fireCrouch;
        private Texture2D fireIdle;
        private Texture2D fireJump;
        private Texture2D fireTurning;
        private Texture2D fireToSmall;
        private Texture2D fireWalk;
        public void LoadContent(ContentManager content)
        {
            fireCrouch = content.Load<Texture2D>("FireMario/fireCrouching");
            fireIdle = content.Load<Texture2D>("FireMario/fireIdle");
            fireJump = content.Load<Texture2D>("FireMario/fireJump");
            fireTurning = content.Load<Texture2D>("FireMario/fireTurning");
            fireToSmall = content.Load<Texture2D>("FireMario/fireToSmall");
            fireWalk = content.Load<Texture2D>("FireMario/fireWalk");
        }
    }
}
