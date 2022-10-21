using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
namespace SprintZeroSpriteDrawing.Sprites.SpriteFactory
{
    public class ProjectileSpriteFactory
    {
        public Vector2 nPos { get; set; }
        public Vector2 SheetSize;

        public Texture2D fireBallSpriteSheet;
        private static ProjectileSpriteFactory _spriteFactory;

        public static ProjectileSpriteFactory GetProjectileSpriteFactory()
        {
            if (_spriteFactory == null)
            {
                _spriteFactory = new ProjectileSpriteFactory();
            }
            return _spriteFactory;
        }

        public void LoadContent(ContentManager content) 
        {
            fireBallSpriteSheet = content.Load<Texture2D>("FireMario/FireballProjectile");     
        }

        /*public ISprite CreateFireball(Vector2 nPos)
        {
            //var projectile;
        }*/
    }
}
