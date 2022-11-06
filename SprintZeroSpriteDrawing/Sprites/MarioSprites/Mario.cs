﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using SprintZeroSpriteDrawing.Interfaces.ProjectileState;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;

namespace SprintZeroSpriteDrawing.Sprites.MarioSprites
{
    public class Mario : ICollideable
    {

        #region Mario Sprite Sheets
        public static Texture2D SmallMarioSpriteSheet;
        public static Texture2D BigMarioSpriteSheet;
        public static Texture2D FireMarioSpriteSheet;
        public static SpriteFont OverlayFont;
        #endregion


        public int Score = 0;
        public int Coins = 0;
        public int Lives = 5;
        public int time = 400;
        public SpriteEffects effects;
        private static Mario _mario;
        bool left = false;
        bool right = false;
        bool up = false;
        bool down = false;
        public bool fireBall { get; set; }

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
            
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Drag, 100)), Direction.BOTTOM, CType.NEUTRAL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.FALLING)), Direction.TOP, CType.NEUTRAL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Impact, (int)ActionState.FALLING)), Direction.SIDE, CType.NEUTRAL));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(CollectCoin, 1)), Direction.BOTTOM, CType.FRIENDLY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(CollectCoin, 1)), Direction.TOP, CType.FRIENDLY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(CollectCoin, 1)), Direction.SIDE, CType.FRIENDLY));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.BIG)), Direction.BOTTOM, CType.LEVELUP));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.BIG)), Direction.TOP, CType.LEVELUP));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.BIG)), Direction.SIDE, CType.LEVELUP));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.FIRE)), Direction.BOTTOM, CType.FLOWER));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.FIRE)), Direction.TOP, CType.FLOWER));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.FIRE)), Direction.SIDE, CType.FLOWER));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.DEAD)), Direction.BOTTOM, CType.BOUNDRY));
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
            batch.DrawString(OverlayFont, "Coins: " + Coins.ToString("000"), new Vector2(100, 100), Color.Black);
            batch.DrawString(OverlayFont, "Time: " + Coins.ToString("400"), new Vector2(800, 100), Color.Black); 
        }

        public static void LoadContent(ContentManager content)
        {
            SmallMarioSpriteSheet = content.Load<Texture2D>("SmallMario/SmallMarioSpriteSheet");
            BigMarioSpriteSheet = content.Load<Texture2D>("BigMario/BigMarioSpriteSheet");
            FireMarioSpriteSheet = content.Load<Texture2D>("FireMario/FireMarioSpriteSheet");
            OverlayFont = content.Load<SpriteFont>("Fonts/Arial");
        }

        public void Impact(int state)
        {
            Velocity = new Vector2(0, Velocity.Y);
        }

        public void ChangePowerup(int powerup)
        {
            StatePowerup.ChangePowerupState(powerup);
        }
        public void ChangeAction(int action)
        {
            StateAction.ChangeActionState(action);
        }
        public void Drag(int coeff)
        {
            Velocity = Vector2.Multiply(Velocity, new Vector2((float)(coeff/100.0), 0));
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
            else if(StateAction.currActionState == ActionState.CROUCHING)
            {
                ChangeAction((int)ActionState.IDLE);
            }
            else if(StateAction.currActionState == ActionState.WALKING)
            {
                ChangeAction((int)ActionState.JUMPING);
            }
        }

        public void DecreaseAction(int action)
        {
            if (StateAction.currActionState == ActionState.JUMPING)
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
        }
        public int GetDirection()
        {
            return effects == SpriteEffects.None ? 4 : -4;
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
            else if (action > 0)
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
            else
            {
                ChangeAction((int)ActionState.IDLE);
                right = false;
                left = false;
            }

        }

       public void CollectCoin(int coin)
       {
           Coins += coin;
           if (Coins >= 100)
           {
               Coins -= 100;
               Lives++;
           }
       }

       public void ShootFire(int Powerup)
        {
            if((int)(Mario.GetMario().StatePowerup.currPowerupState) == Powerup)
            {
                Fireball fire = FireballPool.GetFireballPool().Get();
                if(fire != null)
                {
                    fire.State = new ProjectileAppear((Projectile)fire);
                }
            }
        }
    }
}

