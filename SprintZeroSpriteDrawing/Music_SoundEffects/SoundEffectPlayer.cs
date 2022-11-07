using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace SprintZeroSpriteDrawing.Music_SoundEffects
{
    public class SoundEffectPlayer
    {
        List<SoundEffect> soundEffects = new List<SoundEffect>();
        public enum Sounds
        {
            ONEUP,
            BREAKBLOCK,
            BUMP,
            COIN,
            FIREBALL,
            FLAGPOLE,
            GAMEOVER,
            JUMPSMALL,
            JUMPSUPER,
            KICK,
            DIE,
            PAUSE,
            PIPEPOWERDOWN,
            POWERUP,
            ITEM,
            STAGECLEAR,
            STOMP,
            WARNING,
        }

        public event EventHandler<EventArgs> PlaySoundEffect;

        private static SoundEffectPlayer _soundEffectPlayer;

        public static SoundEffectPlayer GetSoundEffectPlayer()
        {
            if(_soundEffectPlayer == null)
            {
                _soundEffectPlayer = new SoundEffectPlayer();
            }
            return _soundEffectPlayer;
        }

        protected virtual void OnSoundEffectPlayed(EventArgs sound)
        {
            PlaySoundEffect?.Invoke(this, sound);
        }

        public void LoadSoundEffects(ContentManager content)
        {
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/1-up"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/breakblock"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/bump"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/coin"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/fireball"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/flagpole"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/gameover"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/jump-small"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/jump-super"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/kick"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/mariodie"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/pause"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/pipe_powerdown"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/powerup"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/powerup_appears"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/stageClear"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/stomp"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/warning"));
        }
        public void PlaySounds(int sound, SoundEffect soundEffect)
        {
            soundEffects[sound].CreateInstance().Play();
        }
    }
}
