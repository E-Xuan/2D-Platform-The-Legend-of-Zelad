using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace SprintZeroSpriteDrawing.Sprites.MarioSprites
{
    public class Mario : ICollideable
    {
        public Texture2D spriteSheet;
        public Vector2 sheetSize;
        public Vector2 frameSize;


        public Vector2 position { get; set; }

        #region Mario Sprite Sheets
        public Texture2D SmallMarioSpriteSheet;
        public Texture2D BigMarioSpriteSheet;
        public Texture2D FireMarioSpriteSheet;
        #endregion




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
        public IMarioState StatePowerup;
        public IMarioState StateAction;

        public int[] currState;
        public int width;
        public int height;

        /* private static Mario _mario;
         public static Mario mario
         {
             get
             {
                 if(_mario == null)
                 {
                     _mario = new Mario();
                 }
                 return _mario;
             }
         }
        */

        public Mario(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            mario = this;
            effects = SpriteEffects.None;
            IsVis = true;
            SubframeLimit = 20;
            AutoFrame = false;
            Sprite = nSprite;
            Pos = nPos;
            SheetSize = nSheetSize;
            LastFrame = 1;
            StartFrame = 0;
            StatePowerup = new SmallMario(this);
            StateAction = new MarioIdle(this);
            currState = new int[5];
            if (nSprite != null)
                FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);
            
        }


        public void SetSprite(Texture2D nSprite)
        {
            this.Sprite = nSprite;
            this.FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);
        }

        public void UpdateState()
        {
            int prevPowerup = (int)StatePowerup.prevPowerupState;
            int currPowerup = (int)StatePowerup.currPowerupState;
            currState[prevPowerup] = 0;
            currState[currPowerup] = (int)StateAction.currActionState;
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
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch, effects);
        }

        public void LoadContent(ContentManager content)
        {
            SmallMarioSpriteSheet = content.Load<Texture2D>("SmallMario/SmallMarioSpriteSheet");
            BigMarioSpriteSheet = content.Load<Texture2D>("BigMario/BigMarioSpriteSheet");
            FireMarioSpriteSheet = content.Load<Texture2D>("FireMario/FireMarioSpriteSheet");
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

        public void TakeDamage(int powerup)
        {
            if (StatePowerup.currPowerupState != PowerupState.DEAD)
            {
                ChangePowerup((int)PowerupState.SMALL);
            }
            else
            {
                ChangePowerup((int)PowerupState.DEAD);
            }
        }
       
        public void IncreaseAction(int action)
        {
            if(StateAction.currActionState == ActionState.IDLE)
            {
                ChangeAction((int)ActionState.JUMPING); //jump
            }
            else if(StateAction.currActionState == ActionState.CROUCHING && down == true)
            {
                down = false;
            }
            else if(StateAction.currActionState == ActionState.CROUCHING)
            {
                ChangeAction((int)ActionState.IDLE);
            }
            else if(StateAction.currActionState == ActionState.WALKING)
            {
                ChangeAction((int)ActionState.JUMPING);
            }
            else if(StateAction.currActionState == ActionState.JUMPING)
            {
                up = true;
            }
        }

        public void DecreaseAction(int action)
        {
            if(StateAction.currActionState == ActionState.JUMPING && up == true) //jump
            {
                up = false;
            }
            else if (StateAction.currActionState == ActionState.JUMPING)
            {
               ChangeAction((int)ActionState.IDLE);
            }
            else if(StateAction.currActionState == ActionState.IDLE){
                ChangeAction((int)ActionState.CROUCHING); //crounch
            }
            else if (StateAction.currActionState == ActionState.WALKING)
            {
                ChangeAction((int)ActionState.IDLE);
            }
            else
            {
                down = true;
            }
        }
       

        //action positive is right
       public void MoveAction(int action)
        {
            Frame = 0;
            if (action < 0)
            {
                if (effects == SpriteEffects.None && right == true)
                {
                    right = false;
                    ChangeAction((int)ActionState.IDLE);
                    
                }
                else if (effects == SpriteEffects.None)//right
                {
                    this.effects = SpriteEffects.FlipHorizontally;
                    ChangeAction((int)ActionState.IDLE);
                    
                }
                else
                {
                    ChangeAction((int)ActionState.WALKING);
                    left = true;
                }
            }
            else
            {
                if (effects == SpriteEffects.FlipHorizontally && left == true)
                {
                    left = false;
                    ChangeAction((int)ActionState.IDLE);
                }
                else if (effects == SpriteEffects.FlipHorizontally)//left
                {
                    this.effects = SpriteEffects.None;
                    ChangeAction((int)ActionState.IDLE);
                }
                else
                {
                    ChangeAction((int)ActionState.WALKING);
                    right = true;
                }
            }
        }
    }
}

