using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
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

        public Vector2 position { get; set; }

        private Texture2D RunningSpriteSheet;
        private Texture2D JumpingSpriteSheet;
        private Texture2D IdleSpriteSheet;
        private Texture2D CrouchingSpriteSheet;

        private static MarioSpriteFactory sprite = new MarioSpriteFactory();
        public static MarioSpriteFactory Sprite;

        //Need Mario Sprites to implement further

        public MarioSpriteFactory()
		{
            //get{ return sprite; }
		}


	}
}
