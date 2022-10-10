using SprintZeroSpriteDrawing.Collision.BlockCollision;
using SprintZeroSpriteDrawing.Collision.MarioCollision;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Collision.CollisionManager
{
    public class EnemyCollisionManager
    {
        public Mario mario { get; set; }
        public Goomba gommba { get; set; }
        public GreenKoopa greenKoopa { get; set; }
        public RedKoopa redKoopa { get; set; }
    }
}
