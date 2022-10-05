﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
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
		
       

        public Texture2D spriteSheet;
        public Vector2 sheetSize;
        public Vector2 frameSize;
        

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
            return new Mario(SmallIdleSpriteSheet, new Vector2(1,1), nPos);
            
        }
        
       

	}
}
