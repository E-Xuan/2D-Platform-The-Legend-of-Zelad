using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.States.MarioState
{
	public class MarioActionState : IMarioState
	{
		private ISprite sprite;
		public bool transition;


		public MarioActionState()
		{
			//Need Mario Sprites in order to implement
			//this.sprite = MarioSpriteFactory.Sprite.CreateMario();
		}


		public void Update()
		{
			sprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			sprite.Draw(spriteBatch);
		}

		public void Transition()
		{
			throw new NotImplementedException();
		}
	}
}
