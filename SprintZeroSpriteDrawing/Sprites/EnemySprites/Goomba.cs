using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Sprites.EnemySprites
{
    public class Goomba : Enemy
    {
        public Goomba(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
<<<<<<< HEAD
            Velocity = new Vector2(-1, 0);
            Acceleration = new Vector2(0, (float).065);
=======
>>>>>>> 28d7e41d9ea35516a97015da81fe51bf7332f912
        }
    }
}
