using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Music_SoundEffects;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction
{
    public class LinkShield : IMarioState
    {
        public LinkShield(Mario nMario) : base(nMario)
        {

        }
        public LinkShield(Mario nMario, ActionState nState) : base(nMario, nState)
        {

        }
        public override void Enter()
        {
            CollisionManager.getCM().RegMoving(mario);
            var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
            soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
            soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.JUMPSUPER;
            currActionState = ActionState.SHEILD;
            mario.IsVis = true;
            mario.Velocity = new Vector2(0, 0);
            mario.Acceleration = new Vector2(0, 0);
            mario.Frame = 1;
            mario.AutoFrame = false;

        }
        public override void Update()
        {
            
        }

        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }


        public override void ChangeActionState(int state)
        {
            switch ((ActionState)state)
            {
                case ActionState.RUNNING:
                    mario.Velocity = new Vector2(mario.GetDirection(), mario.Velocity.Y);
                    break;
                case ActionState.WALKING:
                    mario.Velocity = new Vector2(mario.GetDirection(), mario.Velocity.Y);
                    break;
                case ActionState.IDLE:
                    mario.Velocity = new Vector2(0, mario.Velocity.Y);
                    break;
                case ActionState.FALLING:
                    Exit();
                    mario.StateAction = new MarioFalling(mario, previousActionState);
                    break;
                case ActionState.POLESLIDE:
                    Exit();
                    mario.StateAction = new MarioPoleslide(mario, currActionState);
                    break;
            }
        }
    }

}

