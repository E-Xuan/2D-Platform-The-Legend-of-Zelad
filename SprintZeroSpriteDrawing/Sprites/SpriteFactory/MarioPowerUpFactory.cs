using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.MarioPowerUpSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.SpriteFactory
{
    public class MarioPowerUpFactory
    {
        public Vector2 nPos { get; set; }

        private Texture2D smallIdle;
        private Texture2D smallJump;
        private Texture2D smallWalk;
        private Texture2D smallTurning;

        private Texture2D bigCrouch;
        private Texture2D bigIdle;
        private Texture2D bigJump;
        private Texture2D bigTurning;
        private Texture2D bigToSmall;
        private Texture2D bigWalk;

        private Texture2D fireCrouch;
        private Texture2D fireIdle;
        private Texture2D fireJump;
        private Texture2D fireTurning;
        private Texture2D fireToSmall;
        private Texture2D fireWalk;

        private Texture2D smallDead;


        private static MarioPowerUpFactory sprite;

        public static MarioPowerUpFactory getFactory()
        {
            if (sprite == null)
            {
                sprite = new MarioPowerUpFactory();
            }
            return sprite;
        }

        public void LoadContent(ContentManager content)
        {

            smallIdle = content.Load<Texture2D>("SmallMario/SmallIdle");
            smallJump = content.Load<Texture2D>("SmallMario/smallJump");
            smallWalk = content.Load<Texture2D>("SmallMario/smallWalk");
            smallTurning = content.Load<Texture2D>("SmallMario/smallTurning");

            bigCrouch = content.Load<Texture2D>("BigMario/bigCrouching");
            bigIdle = content.Load<Texture2D>("BigMario/bigIdle");
            bigJump = content.Load<Texture2D>("BigMario/bigJump");
            bigTurning = content.Load<Texture2D>("BigMario/bigTurning");
            bigToSmall = content.Load<Texture2D>("BigMario/bigToSmall");
            bigWalk = content.Load<Texture2D>("BigMario/bigWalk");

            fireCrouch = content.Load<Texture2D>("FireMario/fireCrouching");
            fireIdle = content.Load<Texture2D>("FireMario/fireIdle");
            fireJump = content.Load<Texture2D>("FireMario/fireJump");
            fireTurning = content.Load<Texture2D>("FireMario/fireTurning");
            fireToSmall = content.Load<Texture2D>("FireMario/fireToSmall");
            fireWalk = content.Load<Texture2D>("FireMario/fireWalk");

            smallDead = content.Load<Texture2D>("SmallMario/smallDying");


        }

        public ISprite CreateSmallMario(Vector2 nPos)
        {
            return new SmallMario(smallIdle, new Vector2(1, 1), nPos);
        }
        public ISprite CreateBigMario(Vector2 nPos)
        {
            return new BigMario(bigIdle, new Vector2(1, 1), nPos);
        }
        public ISprite CreateDeadMario(Vector2 nPos)
        {
            return new DeadMario(smallDead, new Vector2(1, 1), nPos);
        }
        public ISprite CreateFireMario(Vector2 nPos)
        {
            return new FireMario(fireIdle, new Vector2(1, 1), nPos);
        }

    }
}
