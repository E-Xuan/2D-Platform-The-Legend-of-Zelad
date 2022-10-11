using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;

namespace SprintZeroSpriteDrawing.Sprites.MarioSprites
{
    public class Mario : ICollideable
    {

        #region Mario Sprite Sheets
        public static Texture2D SmallMarioSpriteSheet;
        public static Texture2D BigMarioSpriteSheet;
        public static Texture2D FireMarioSpriteSheet;
        #endregion




        public SpriteEffects effects;
        private static Mario _mario;
        int Speed = 5;
        bool left = false;
        bool right = false;
        bool up = false;
        bool down = false;

        public IMarioState StatePowerup;
        public IMarioState StateAction;
        public int[] currState;

         public static Mario GetMario() {
             if(_mario == null)
             {
                _mario = new Mario(SmallMarioSpriteSheet, new Vector2(3, 3), new Vector2(0, 0));
             }
             return _mario;
         }

         private Mario(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
         {
            CollideableType = CType.AVATAR_SMALL;
            effects = SpriteEffects.None;
            LastFrame = 1;
            StartFrame = 0;
            StatePowerup = new SmallMario(this);
            StateAction = new MarioIdle(this);
            currState = new int[5];
            
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(TakeDamage, 0)), Direction.SIDE, CType.ENEMY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.IDLE)), Direction.SIDE, CType.ENEMY));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.FALLING)), Direction.TOP, CType.INVISIBLE));
            
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.IDLE)), Direction.BOTTOM, CType.NEUTRAL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.IDLE)), Direction.TOP, CType.NEUTRAL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.IDLE)), Direction.SIDE, CType.NEUTRAL));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(TakeItem, 0)), Direction.BOTTOM, CType.FRIENDLY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(TakeItem, 0)), Direction.TOP, CType.FRIENDLY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(TakeItem, 0)), Direction.SIDE, CType.FRIENDLY));
        }

        public void UpdateState()
        {
            int prevPowerup = (int)StatePowerup.prevPowerupState;
            int currPowerup = (int)StatePowerup.currPowerupState;
            currState[prevPowerup] = 0;
            currState[currPowerup] = (int)StateAction.currActionState;
        }

        public override void Update()
        {
            StatePowerup.Update();
            StateAction.Update();
            //THIS WAS ADDED TO DO THE PBI, WE HAVE CODE FOR SPRINT 3
            if (StateAction.currActionState == ActionState.IDLE)
                up = down = false;
            if (!up && !down)
                Velocity = new Vector2(Velocity.X, 0);
            if (down)
                Velocity = new Vector2(Velocity.X, 5);
            if (up)
                Velocity = new Vector2(Velocity.X, -5);
            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch, effects);
        }

        public static void LoadContent(ContentManager content)
        {
            SmallMarioSpriteSheet = content.Load<Texture2D>("SmallMario/SmallMarioSpriteSheet");
            BigMarioSpriteSheet = content.Load<Texture2D>("BigMario/BigMarioSpriteSheet");
            FireMarioSpriteSheet = content.Load<Texture2D>("FireMario/FireMarioSpriteSheet");
        }
        public void ChangePowerup(int powerup)
        {
            StatePowerup.ChangePowerupState(powerup);
        }
        public void ChangeAction(int action)
        {
            StateAction.ChangeActionState(action);
        }
        public void TakeItem(int powerup)
        {
            if((int)StatePowerup.currPowerupState + 1 < 3)
                ChangePowerup((int)StatePowerup.currPowerupState + 1);
        }
        public void TakeDamage(int powerup)
        {
            if (StatePowerup.currPowerupState != PowerupState.SMALL)
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

