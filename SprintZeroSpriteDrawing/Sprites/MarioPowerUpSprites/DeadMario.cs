using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.MarioPowerUpSprites
{
    internal class DeadMario
    {
        private Texture2D smallDead;
        
        public void LoadContent(ContentManager content)
        {
            smallDead = content.Load<Texture2D>("SmallMario/smallDying");
            
        }
    }
}
