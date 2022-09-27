using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
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

		public Tuple<int, int> state { get; set; }
		public Vector2 nPos;


		public MarioState()
		{
			this.sprite = MarioSpriteFactory.getSpriteFactory().createMario(nPos);
		}


		public void Update()
		{
			sprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			sprite.Draw(spriteBatch);
		}

		


	}
}
