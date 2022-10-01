using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.MarioSprites
{
	public class Mario : ISprite
	{
        public SpriteEffects effects;
        public bool IsVis { get; set; }
        public Texture2D Sprite { get; set; }
        public Vector2 Pos { get; set; }
        public int Frame { get; set; }
        public int Subframe { get; set; }
        public int SubframeLimit { get; set; }
        public bool AutoFrame { get; set; }
        private int LastFrame;
        private Vector2 SheetSize;
        private Vector2 FrameSize;
        private Mario mario;
        int Speed = 5;
        bool left = false;
        bool right = false;
        public (int powerup, int action) State;
        


        public int width;
        public int height;
        public Mario(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos)
		{
            mario = this;
            effects = SpriteEffects.None;
			IsVis = true;
            SubframeLimit = 20;
            AutoFrame = true;
            Sprite = nSprite;
            Pos = nPos;
            SheetSize = nSheetSize;
            LastFrame = (int)(SheetSize.X * SheetSize.Y);
            if (nSprite != null)
                FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);
            State.powerup = 1;
            State.action = 2;
        }

        public void SetSprite(Texture2D nSprite)
        {
            Sprite = nSprite;
            FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);
        }

        public int NextFrame()
        {
            return Frame++;
        }
		

		public int Draw(SpriteBatch batch)
		{
            if (IsVis)
            {
                Rectangle Rect = new Rectangle((int)(Frame % (int)SheetSize.X * FrameSize.X), (int)(Frame / (int)SheetSize.X * FrameSize.Y),
                    (int)FrameSize.X, (int)FrameSize.Y);
                batch.Draw(Sprite, Pos, Rect, Color.White, 0, new Vector2(0, 0), 1, effects, 0);
                if (AutoFrame)
                    Subframe++;
                if (Subframe == SubframeLimit)
                {
                    Subframe = 0;
                    Frame = (Frame + 1) % LastFrame;
                }
                return Frame;
            }
            return -2;

        }

		public void SetVis(int nIsVis)
		{
            IsVis = nIsVis > 0;
        }

		public void TogVis(int nIsVis)
		{
			IsVis = !IsVis;
		}

		virtual public void Update()
		{
            if (left && Pos.X != 0)
            {
                MoveX(-Speed);
            }
            if (Pos.X == 0)
            {
                left = false;
            }
            if (right == true && Pos.X != 1865)
            {
                MoveX(Speed);
            }
            if (Pos.X == 1865)
            {
                right = false;
            }
            //Stuff and Things
        }

        public void MoveSprite(Vector2 displacement)
        {
            Pos = Vector2.Add(Pos, displacement);
        }
        public void MoveX(int pixels)
        {
            AutoFrame = true;
            Pos = Vector2.Add(Pos, new Vector2(pixels, 0));
        }
        public void MoveY(int pixels)
        {
            AutoFrame = false;
            Pos = Vector2.Add(Pos, new Vector2(0, pixels));
        }
        public void SetPowerup(int powerup)
        {
            State.powerup = powerup;
            ChangeState();
        }
        public void SetAction(int action)
        {
            State.action = action;
            ChangeState();
        }
        public void FlipFacing(int flip) 
        {
            if (flip > 0)
                effects = SpriteEffects.FlipHorizontally;
            else
                effects = SpriteEffects.None;
        }

        public void ChangeState()
        {
            Sprite = MarioSpriteFactory.getSpriteFactory().swapSprite(State);
            SheetSize = MarioSpriteFactory.getSpriteFactory().swapSheetSize(State);
            FrameSize = MarioSpriteFactory.getSpriteFactory().swapFrameSize(State);
            LastFrame = (int)(SheetSize.X * SheetSize.Y);

        }

        public void TakeDamage(int powerup)
        {
            if (State.powerup > 1 && State.powerup < 4)
            {
                State.powerup = 1;
            }
            else
            {
                State.powerup = 4;
            }
        }

        public void IncreaseAction(int action)
        {
            if(State.action == 2)
            {
                State.action = 3;
            }
            else if(State.action == 4)
            {
                State.action = 2;
            }
            else if(State.action == 1)
            {
                State.action = 3;
            }
        }

        public void DecreaseAction(int action)
        {
            if(State.action == 3)
            {
                State.action = 2;
            }
            else if(State.action == 2){
                State.action = 4;
            }
            else if (State.action == 1)
            {
                State.action = 2;
            }
        }

        //action positive is right
        public void MoveAction(int action)
        {
            Frame = 0;
            if (action < 0)
            {
                if(effects == SpriteEffects.None && right == true)
                {
                    right = false;
                    effects = SpriteEffects.FlipHorizontally;
                    State.action = 2;
                }
                else if (effects == SpriteEffects.None)//right
                {
                    effects = SpriteEffects.FlipHorizontally;
                    State.action = 2;
                }
                else
                {
                    State.action = 1;
                    left = true;
                }
            }
            else 
            {
                if(effects == SpriteEffects.FlipHorizontally && left == true)
                {
                    left = false;
                    effects = SpriteEffects.None;
                    State.action = 2;
                }
                else if (effects == SpriteEffects.FlipHorizontally)//left
                {
                    effects = SpriteEffects.None;
                    State.action = 2;
                }
                else
                {
                    State.action = 1;
                    right = true;
                }
            }
        }
    }
}
