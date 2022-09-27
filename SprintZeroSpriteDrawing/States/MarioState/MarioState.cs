using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.States.MarioState
{
	public class MarioState : IMarioState
	{
		public ISprite sprite;

		public Tuple<int,int> state { get; set; }
		private static MarioState mario;


		public  MarioState()
        {
			//this.sprite = MarioSpriteFactory.getSpriteFactory().CreateMario(new Vector2(300, 300));
		}


		public void Update()
		{
			sprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			sprite.Draw(spriteBatch);
		}

		public void swapState()
		{
			
		}

		
	}
}
