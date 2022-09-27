using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace SprintZeroSpriteDrawing.Sprites.MarioActionSprites
{
	public class Crouching : ISprite
	{
		public Crouching()
		{

		}

		public Texture2D Sprite { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Microsoft.Xna.Framework.Vector2 Pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool IsVis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public int Draw(SpriteBatch batch)
		{
			throw new NotImplementedException();
		}

		public void SetVis(int nIsVis)
		{
			throw new NotImplementedException();
		}

		public void TogVis(int nIsVis)
		{
			throw new NotImplementedException();
		}

		public void Update()
		{
			throw new NotImplementedException();
		}
        public void Trigger() { }

		public void MoveY(int x)
		{
			throw new NotImplementedException();
		}

		public void MoveX(int x)
		{
			throw new NotImplementedException();
		}
	}
}
