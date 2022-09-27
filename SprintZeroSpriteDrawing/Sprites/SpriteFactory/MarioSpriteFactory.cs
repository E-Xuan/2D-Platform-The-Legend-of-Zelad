using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.MarioActionSprites
{
	public class MarioSpriteFactory
	{
		
        public int CrouchingSpriteSheetRow { get; }
		public int CrouchingSpriteSheetCol { get; }
		public int CrouchingFrames {get;}

        public int IdleSpriteSheetRow { get; }
        public int IdleSpriteSheetCol { get; }
        public int IdleFrames { get; }

        public int RunningSpriteSheetRow { get; }
        public int RunningSpriteSheetCol { get; }
        public int RunningFrames { get; }

        public int JumpingSpriteSheetRow { get; }
        public int JumpingSpriteSheetCol { get; }
        public int JumpingFrames { get; }

        public Texture2D spriteSheet;
        public Vector2 sheetSize;
        public (int powerup, int action) State;

        public Vector2 position { get; set; }

        #region Small Mario
        private Texture2D SmallRunningSpriteSheet;
        private Texture2D SmallJumpingSpriteSheet;
        private Texture2D SmallIdleSpriteSheet;
       
        #endregion

        #region Big Mario
        private Texture2D BigRunningSpriteSheet;
        private Texture2D BigJumpingSpriteSheet;
        private Texture2D BigIdleSpriteSheet;
        private Texture2D BigCrouchingSpriteSheet;
        #endregion

        #region Fire Mario
        private Texture2D FireRunningSpriteSheet;
        private Texture2D FireJumpingSpriteSheet;
        private Texture2D FireIdleSpriteSheet;
        private Texture2D FireCrouchingSpriteSheet;
        #endregion

        #region Dead Mario
        private Texture2D DeadMarioSpriteSheet;
        #endregion

        

        private static MarioSpriteFactory sprite;
        public static MarioSpriteFactory getSpriteFactory()
		{
            if(sprite == null)
            {
                sprite = new MarioSpriteFactory();
            }
            return sprite;
		}

         public void LoadContent(ContentManager content)
        {
            SmallRunningSpriteSheet = content.Load<Texture2D>("SmallMario/smallWalk");
            SmallJumpingSpriteSheet = content.Load<Texture2D>("SmallMario/smallJump");
            SmallIdleSpriteSheet = content.Load<Texture2D>("SmallMario/SmallIdle");

            BigCrouchingSpriteSheet = content.Load<Texture2D>("BigMario/bigCrouching");
            BigIdleSpriteSheet = content.Load<Texture2D>("BigMario/bigIdle");
            BigJumpingSpriteSheet = content.Load<Texture2D>("BigMario/bigJump");
            BigRunningSpriteSheet = content.Load<Texture2D>("BigMario/bigWalk");

            FireCrouchingSpriteSheet = content.Load<Texture2D>("FireMario/fireCrouching");
            FireIdleSpriteSheet = content.Load<Texture2D>("FireMario/fireIdle");
            FireJumpingSpriteSheet = content.Load<Texture2D>("FireMario/fireJump");
            FireRunningSpriteSheet = content.Load<Texture2D>("FireMario/fireWalk");

            DeadMarioSpriteSheet = content.Load<Texture2D>("SmallMario/smallDying");
        }

        public ISprite createMario(Vector2 nPos)
        {
            return new Mario(swapSprite(MarioCommand.Execute(), swapSheetSize(), nPos);
            
        }

        public Texture2D swapSprite((int powerup, int action)State)
        {
            
            if (State.powerup == 1 && State.action == 1) 
                {
                    spriteSheet = SmallRunningSpriteSheet;  
                }
            else if(State.powerup == 1 && State.action == 2)
            {
                spriteSheet = SmallIdleSpriteSheet;
            }
            else if (State.powerup == 1 && State.action == 3)
            {
                spriteSheet = SmallJumpingSpriteSheet;
            }
            else if (State.powerup == 1 && State.action == 4)
            {
                spriteSheet = SmallIdleSpriteSheet;
            }
            else if (State.powerup == 2 && State.action == 1)
            {
                spriteSheet = BigRunningSpriteSheet;
            }
            else if (State.powerup == 2 && State.action == 2)
            {
                spriteSheet = BigIdleSpriteSheet;
            }
            else if (State.powerup == 2 && State.action == 3)
            {
                spriteSheet = BigJumpingSpriteSheet;
            }
            else if (State.powerup == 2 && State.action == 4)
            {
                spriteSheet = BigCrouchingSpriteSheet;
            }
            else if (State.powerup == 3 && State.action == 1)
            {
                spriteSheet = FireRunningSpriteSheet;
            }
            else if (State.powerup == 3 && State.action == 2)
            {
                spriteSheet = FireIdleSpriteSheet;
            }
            else if (State.powerup == 3 && State.action == 3)
            {
                spriteSheet = FireJumpingSpriteSheet;
            }
            else if (State.powerup == 3 && State.action == 4)
            {
                spriteSheet = FireCrouchingSpriteSheet;
            }
            else if (State.powerup == 4)
            {
                spriteSheet = DeadMarioSpriteSheet;
            }


            return spriteSheet;
        }

        public Vector2 swapSheetSize()
        {
            if (State.powerup == 1 && State.action == 1)
            {
                sheetSize = new Vector2(3,1);
            }
            else if (State.powerup == 1 && State.action == 2)
            {
                sheetSize = new Vector2(1, 1);
            }
            else if (State.powerup == 1 && State.action == 3)
            {
                sheetSize = new Vector2(1, 1);
            }
            else if (State.powerup == 1 && State.action == 4)
            {
                sheetSize = new Vector2(1, 1);
            }
            else if (State.powerup == 2 && State.action == 1)
            {
                sheetSize = new Vector2(1, 1);
            }
            else if (State.powerup == 2 && State.action == 2)
            {
                sheetSize = new Vector2(1, 1);
            }
            else if (State.powerup == 2 && State.action == 3)
            {
                sheetSize = new Vector2(1, 1);
            }
            else if (State.powerup == 2 && State.action == 4)
            {
                sheetSize = new Vector2(1, 1);
            }
            else if (State.powerup == 3 && State.action == 1)
            {
                sheetSize = new Vector2(3, 1);
            }
            else if (State.powerup == 3 && State.action == 2)
            {
                sheetSize = new Vector2(1, 1);
            }
            else if (State.powerup == 3 && State.action == 3)
            {
                sheetSize = new Vector2(1, 1);
            }
            else if (State.powerup == 3 && State.action == 4)
            {
                sheetSize = new Vector2(1, 1);
            }
            else if (State.powerup == 4)
            {
                sheetSize = new Vector2(1, 1);
            }
            return sheetSize;
        }

	}
}
