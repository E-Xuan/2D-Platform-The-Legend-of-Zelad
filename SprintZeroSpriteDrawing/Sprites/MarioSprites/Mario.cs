using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace SprintZeroSpriteDrawing.Sprites.MarioSprites
{
    public class Mario : ICollideable
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
        bool up = false;
        bool down = false;
        public IMarioState StateAction;
        public IMarioState StatePowerup;
        public int[] currState;
        


        public int width;
        public int height;
        public Mario(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
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
            StateAction = new MarioIdle(this);
            StatePowerup = new SmallMario(this);
            currState = new int[5];
        }

        public void SetSprite(Texture2D nSprite)
        {
            Sprite = nSprite;
            this.FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);
        }

        public void UpdateState()
        {
            int prevPowerup = (int)StatePowerup.prevPowerupState;
            int currPowerup = (int)StatePowerup.currPowerupState;
            currState[prevPowerup] = 0;
            currState[currPowerup] = (int)StateAction.currActionState;

            switch (currState[currPowerup])
            {
                case (int)ActionState.IDLE:
                    
                    break;
                case (int)ActionState.RUNNING:
                    break;
                case (int)ActionState.WALKING:

                    break;
                case (int)ActionState.JUMPING:

                    break;
                case (int)ActionState.CROUCHING:

                    break;
            }
        }

        public int NextFrame()
        {
            return Frame++;
        }
		

		

		public void SetVis(int nIsVis)
		{
            IsVis = nIsVis > 0;
        }

		public void TogVis(int nIsVis)
		{
			IsVis = !IsVis;
		}

		public override void Update()
		{
            StatePowerup.Update();
            StateAction.Update();
            base.Update();
            

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
        public void ChangePowerup(int powerup)
        {
            this.StatePowerup.ChangePowerupState(powerup);
        }
        public void ChangeAction(int action)
        {
            this.StateAction.ChangeActionState(action);
        }
        public void FlipFacing(int flip) 
        {
            if (flip > 0)
                effects = SpriteEffects.FlipHorizontally;
            else
                effects = SpriteEffects.None;
        }

        /*public void ChangeState()
        {
            Sprite = MarioSpriteFactory.getSpriteFactory().swapSprite(State);
            SheetSize = MarioSpriteFactory.getSpriteFactory().swapSheetSize(State);
            FrameSize = MarioSpriteFactory.getSpriteFactory().swapFrameSize(State);
            LastFrame = (int)(SheetSize.X * SheetSize.Y);

        }
        */

       /* public void TakeDamage(int powerup)
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
       */
        /*public void IncreaseAction(int action)
        {
            if(State.action == 2)
            {
                State.action = 3; //jump
            }
            else if(State.action == 4 && down == true)
            {
                down = false;
            }
            else if(State.action == 4)
            {
                State.action = 2;
            }
            else if(State.action == 1)
            {
                State.action = 3;
            }
            else if(State.action == 3)
            {
                up = true;
            }
        }*/

        /*public void DecreaseAction(int action)
        {
            if(State.action == 3 && up == true) //jump
            {
                up = false;
            }
            else if (State.action == 3)
            {
                State.action = 2;
            }
            else if(State.action == 2){
                State.action = 4; //crounch
            }
            else if (State.action == 1)
            {
                State.action = 2;
            }
            else
            {
                down = true;
            }
        } */

        //action positive is right
       /* public void MoveAction(int action)
        {
            Frame = 0;
            if (action < 0)
            {
                if(effects == SpriteEffects.None && right == true)
                {
                    right = false;
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
            }*/
        }
    }

